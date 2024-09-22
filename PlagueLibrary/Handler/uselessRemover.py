import os
import re

def process_cs_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        content = file.read()

    # 删除注释
    content = re.sub(r'//.*?$|/\*.*?\*/', '', content, flags=re.MULTILINE | re.DOTALL)

    # 删除带attribute的签名
    content = re.sub(r'\[.*?\]', '', content)

    # 提取函数签名并删除函数体
    pattern = r'(public|private|protected|internal|static)?\s+[\w<>[\],\s]+\s+\w+\s*\([^)]*\)\s*(?={)'
    matches = re.finditer(pattern, content)

    new_content = []
    for match in matches:
        signature = match.group().strip() + ';'
        new_content.append(signature)

    return '\n'.join(new_content)

def main():
    current_dir = os.getcwd()
    for filename in os.listdir(current_dir):
        if filename.endswith('.cs'):
            file_path = os.path.join(current_dir, filename)
            processed_content = process_cs_file(file_path)
            
            with open(file_path, 'w', encoding='utf-8') as file:
                file.write(processed_content)
            
            print(f"Processed: {filename}")

if __name__ == '__main__':
    main()