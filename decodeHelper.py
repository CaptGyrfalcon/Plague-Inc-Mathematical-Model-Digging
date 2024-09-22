import idaapi
import idc
import re
import os
import idautils

# 初始化日志文件
log_file_path = os.path.join(os.path.expanduser('~'), 'Desktop', 'debug.log')

def log_debug(message):
    with open(log_file_path, 'a') as log_file:
        log_file.write(message + '\n')

def get_csv_prefix():
    dll_name = idaapi.get_root_filename()
    if dll_name == 'PlagueExternal.dll':
        return 'SP'
    elif dll_name == 'PlagueExternalMP.dll':
        return 'MP'
    elif dll_name == 'PlagueExternalCOOP.dll':
        return 'COOP'
    return ''

def get_cs_file_paths():
    dll_name = idaapi.get_root_filename()
    prefix = get_csv_prefix()
    base_path = os.path.join(os.path.expanduser('~'), 'Desktop', 'PlagueLibrary', 'Handler')
    suffixes = ["CountryExternal", "DiseaseExternal", "LocalDiseaseExternal"]
    return [os.path.join(base_path, f"{prefix}{suffix}.cs") for suffix in suffixes]

def strip_comments_and_strings(pseudocode):
    pattern = re.compile(
        r'(//.*?$|/\*.*?\*/|"(?:\\.|[^"\\])*"|\'(?:\\.|[^\'\\])*\')', 
        re.DOTALL | re.MULTILINE
    )
    
    def replacer(match):
        return '' if match.group(0).startswith(('/', '"', "'")) else match.group(0)
    
    return re.sub(pattern, replacer, pseudocode)

def get_function_signatures(cs_file_paths):
    signatures = {}
    func_name_regex = re.compile(r'public (?:static )?\w+(?:<.*?>)?\s+(\w+)\s*\((.*?)\)')
    param_regex = re.compile(r'(\w+(?:<.*?>)?(?:\s*\*|\s*\[?\]?)?)\s+(\w+)')

    for cs_file_path in cs_file_paths:
        if not os.path.isfile(cs_file_path):
            continue
        with open(cs_file_path, 'r', encoding='utf-8') as file:
            content = file.read()
            content = strip_comments_and_strings(content)
            func_matches = func_name_regex.findall(content)
            for func_name, params in func_matches:
                param_dict = {}
                param_matches = param_regex.findall(params)
                for param_type, param_name in param_matches:
                    param_dict[param_name] = param_type.strip()
                signatures[func_name] = param_dict
    return signatures

def convert_param_label(param_type):
    label = param_type.replace('[', '').replace(']', '').replace('*', '').strip()
    if label.startswith("SP"):
        label = label[2:]
    elif label.startswith("MP"):
        label = label[2:]
    elif label.startswith("COOP"):
        label = label[4:]
    return label.replace('Data', '')

def create_offset_mapping(csv_path):
    offset_mapping = {}
    log_debug(f"Reading CSV file: {csv_path}")
    with open(csv_path, 'r') as f:
        next(f)  # Skip header
        for line in f:
            try:
                index, name, var_type, offset = line.strip().split(',')
                offset_mapping[int(offset)] = name
                log_debug(f"Loaded offset: {offset} -> {name}")
            except ValueError:
                log_debug(f"Error parsing line: {line.strip()}")
    return offset_mapping

def get_type_size(type_str):
    if type_str is None:
        return 4  # 默认为4字节
    if 'double' in type_str or '__int64' in type_str or 'long long' in type_str or '_QWORD' in type_str:
        return 8
    elif 'float' in type_str or 'long' in type_str or 'int' in type_str or '_DWORD' in type_str:
        return 4
    elif 'short' in type_str or '_WORD' in type_str:
        return 2
    elif 'char' in type_str or 'bool' in type_str or '_BYTE' in type_str:
        return 1
    else:
        return 4  # 默认为4字节

def replace_offsets(pseudocode, obj_name, offset_mapping, param_type):
    if param_type is None:
        log_debug(f"Warning: param_type is None for {obj_name}")
        param_type = "int"  # 设置一个默认类型

    def replacer(match):
        try:
            offset = int(match.group(1))
            if offset in offset_mapping:
                replacement = f"{obj_name}.{offset_mapping[offset]}"
                log_debug(f"Replacing: {match.group(0)} -> {replacement}")
                return replacement
        except ValueError:
            pass
        return match.group(0)
    
    def array_replacer(match):
        try:
            index = int(match.group(1))
            type_size = get_type_size(param_type)
            byte_offset = index * type_size
            if byte_offset in offset_mapping:
                replacement = f"{obj_name}.{offset_mapping[byte_offset]}"
                log_debug(f"Replacing array access: {match.group(0)} -> {replacement}")
                return replacement
        except ValueError:
            pass
        return match.group(0)
    
    def pointer_arithmetic_replacer(match):
        try:
            type_str = match.group(1)
            pointer_offset = int(match.group(2))
            type_size = get_type_size(type_str)
            byte_offset = pointer_offset * type_size
            if byte_offset in offset_mapping:
                replacement = f"{obj_name}.{offset_mapping[byte_offset]}"
                log_debug(f"Replacing pointer arithmetic: {match.group(0)} -> {replacement}")
                return replacement
        except ValueError:
            pass
        return match.group(0)

    # 替换 *(type *)(a1 + offset) 形式
    pattern1 = rf'\*\s*\(\s*(?:_DWORD|_QWORD|float|double|int|__int64)\s*\*\)\s*\(\s*{obj_name}\s*\+\s*(\d+)\s*\)'
    pseudocode = re.sub(pattern1, replacer, pseudocode)
    
    # 替换 [type *]指针类型偏移形式
    pattern2 = rf'\[\s*(?:_DWORD|_QWORD|float|double|int|__int64)\s*\*\]\s*\(\s*{obj_name}\s*\+\s*(\d+)\s*\)'
    pseudocode = re.sub(pattern2, replacer, pseudocode)
    
    # 替换 a1[index] 形式
    pattern3 = rf'{obj_name}\[(\d+)\]'
    pseudocode = re.sub(pattern3, array_replacer, pseudocode)

    # 替换直接偏移形式 (a1 + offset)
    pattern4 = rf'\(\s*{obj_name}\s*\+\s*(\d+)\s*\)'
    pseudocode = re.sub(pattern4, replacer, pseudocode)

    # 替换指针算术形式 *((_QWORD *)a2 + 4)
    pattern5 = rf'\*\s*\(\s*\((_[A-Z]+)\s*\*\s*\)\s*{obj_name}\s*\+\s*(\d+)\s*\)'
    pseudocode = re.sub(pattern5, pointer_arithmetic_replacer, pseudocode)

    return pseudocode

def get_output_path():
    dll_name = idaapi.get_root_filename()
    dll_name_without_ext = os.path.splitext(dll_name)[0]
    function_name = idc.get_func_name(idc.here())

    if not function_name:
        function_name = "unknown_function"

    output_dir = os.path.join(os.path.expanduser('~'), 'Desktop', 'PlagueLibrary', dll_name_without_ext)
    if not os.path.exists(output_dir):
        os.makedirs(output_dir)

    output_path = os.path.join(output_dir, f"{function_name}.c")
    return output_path

def parse_function_signature(pseudocode):
    # 匹配函数签名
    signature_pattern = re.compile(r'^(\w+(?:\s+\w+)*)\s+(\w+)\s*\((.*?)\)')
    match = signature_pattern.match(pseudocode.split('\n')[0])
    
    if not match:
        return None, None, []
    
    return_type, func_name, params_str = match.groups()
    
    # 解析参数
    params = []
    if params_str:
        param_pattern = re.compile(r'([\w\s\*]+?)\s*(a\d+)(?:,|$)')
        params = param_pattern.findall(params_str)
    
    return return_type, func_name, params

def get_function_name(name):
    if name.startswith("qword_") or name.startswith("dword_"):
        try:
            address = int(name.split('_')[1], 16)
            xrefs = list(idautils.XrefsTo(address))
            if xrefs:
                for xref in xrefs:
                    func = idaapi.get_func(xref.frm)
                    if func:
                        func_name = idc.get_func_name(func.start_ea)
                        if func_name.startswith("Set") and func_name.endswith("Function"):
                            return func_name[3:-8]  # Remove "Set" prefix and "Function" suffix
        except ValueError:
            log_debug(f"Error parsing address from {name}")
    return name

def replace_function_names(pseudocode):
    def replacer(match):
        original_name = match.group(0)
        new_name = get_function_name(original_name)
        if new_name != original_name:
            log_debug(f"Replaced function name: {original_name} -> {new_name}")
        return new_name

    pattern = r'(qword_[0-9A-F]+|dword_[0-9A-F]+)'
    return re.sub(pattern, replacer, pseudocode)

def remove_unnecessary_casts(pseudocode):
    # 移除简单的数值类型转换
    pattern = r'\((float|double|int|long|long long|short|char)\s*\)'
    return re.sub(pattern, '', pseudocode)

def process_pseudocode():
    current_ea = idc.here()
    decompiled_code = idaapi.decompile(current_ea)
    
    if not decompiled_code:
        log_debug("Error: Cannot decompile the current function.")
        return

    pseudocode_str = str(decompiled_code)
    return_type, func_name, params = parse_function_signature(pseudocode_str)
    
    if not func_name:
        log_debug("Error: Cannot parse function signature.")
        return
    
    log_debug(f"Parsed function signature: {return_type} {func_name}({', '.join([f'{t.strip()} {n}' for t, n in params])})")
    
    pseudocode_str = strip_comments_and_strings(pseudocode_str)
    
    cs_file_paths = get_cs_file_paths()
    signatures = get_function_signatures(cs_file_paths)
    
    if func_name not in signatures:
        log_debug(f"Error: Function signature for '{func_name}' not found in any CS file.")
        return

    cs_param_mapping = list(signatures[func_name].items())
    
    cs_signature = f"{func_name}({', '.join([f'{t} {n}' for n, t in cs_param_mapping])})"
    log_debug(f"C# function signature found: {cs_signature}")
    
    for i, ((cs_param_name, cs_param_type), (ida_param_type, ida_param_name)) in enumerate(zip(cs_param_mapping, params)):
        translated_label = convert_param_label(cs_param_type)
        csv_prefix = get_csv_prefix()
        csv_path = rf'C:\Users\admin\Desktop\PIDigProgram\Plague-Inc-Mathematical-Model-Digging\MemoryOffset\{csv_prefix}{translated_label}Data.csv'

        log_debug(f"Processing parameter {i+1}: {cs_param_name} ({cs_param_type})")
        log_debug(f"IDA parameter type: {ida_param_type}")

        if os.path.exists(csv_path):
            log_debug(f"CSV file found: {csv_path}")
            offset_mapping = create_offset_mapping(csv_path)
            pseudocode_str = replace_offsets(pseudocode_str, ida_param_name, offset_mapping, ida_param_type)
        else:
            log_debug(f"CSV file does not exist: {csv_path}")

    for i, ((cs_param_name, _), (_, ida_param_name)) in enumerate(zip(cs_param_mapping, params)):
        new_param_name = cs_param_name[0].lower() + cs_param_name[1:]
        pseudocode_str = pseudocode_str.replace(ida_param_name, new_param_name)
        log_debug(f"Replaced parameter name: {ida_param_name} -> {new_param_name}")

    pseudocode_str = replace_function_names(pseudocode_str)

    signature_comment = f"// Original function: {func_name}({', '.join([f'{t.strip()} {n}' for t, n in params])})\n"
    pseudocode_str = signature_comment + pseudocode_str

    # 移除不必要的类型转换
    pseudocode_str = remove_unnecessary_casts(pseudocode_str)

    log_debug("Modified pseudocode:")
    log_debug(pseudocode_str)

    output_path = get_output_path()
    with open(output_path, 'w') as output_file:
        output_file.write(pseudocode_str)

    log_debug(f"Modified pseudocode written to: {output_path}")

if __name__ == "__main__":
    process_pseudocode()