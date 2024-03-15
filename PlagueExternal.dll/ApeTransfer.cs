__int64 __fastcall ApeTransfer(__int64 a1, __int64 a2, __int64 a3, __int64 a4, __int64 a5)
{
  double v8; // xmm0_8
  int v9; // ebx
  int v10; // ecx
  int v11; // eax
  float v12; // xmm8_4
  float v13; // xmm6_4
  __int64 v14; // rbx
  int v15; // eax
  __int64 result; // rax

  if ( *(__int64 *)(a5 + 216) <= 0 )
    goto LABEL_10;
  v8 = qword_180032C58(a1);
  v9 = qword_180032C50(0i64, 100i64);
  v10 = qword_180032C50(0i64, 100i64);
  if ( v9 >= 1 )
  {
    v11 = 1;
    if ( v10 < 2 )
      v11 = 100;
  }
  else
  {
    v11 = 1000;
  }
  v12 = (float)((float)((float)((float)(int)*(_QWORD *)(a4 + 280) / (float)(int)*(_QWORD *)(a5 + 216)) * 100.0)
              * *(float *)&v8)
      * (float)v11;
  v13 = (float)(*(float *)(a1 + 760) / 100.0) * *(float *)(a2 + 368);
  v14 = (int)qword_180032C50(0i64, 100i64);
  v15 = qword_180032C50(0i64, 13i64);
  if ( v12 < fmaxf(100.0 - v13, 20.0) || v14 >= *(_QWORD *)(a4 + 280) || v15 >= 1 )
LABEL_10:
    result = 0i64;
  else
    result = 1i64;
  return result;
}