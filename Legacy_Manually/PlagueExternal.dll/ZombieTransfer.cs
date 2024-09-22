_BOOL8 __fastcall ZombieTransfer(__int64 a1, __int64 a2, __int64 a3, __int64 a4, __int64 a5)
{
  float v8; // xmm7_4
  double v9; // xmm0_8
  bool v10; // cc
  int v11; // eax

  v8 = *(float *)(a2 + 188) * *(float *)(a4 + 188);
  v9 = qword_180032C58(a1);
  v10 = (int)qword_180032C50(0i64, 100i64) < 1;
  v11 = 1;
  if ( v10 )
    v11 = 1000;
  return (float)((float)((float)((float)((float)((float)((float)((float)(int)*(_QWORD *)(a4 + 24) * 100.0)
                                                       / (float)(int)*(_QWORD *)(a5 + 24))
                                               * *(float *)(a1 + 80))
                                       * *(float *)(a1 + 272))
                               * v8)
                       * *(float *)&v9)
               * (float)v11) >= fmaxf(13.0 - *(float *)(a2 + 96), 1.0);
}