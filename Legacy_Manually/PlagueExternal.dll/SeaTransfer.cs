_BOOL8 __fastcall SeaTransfer(__int64 a1, __int64 a2, __int64 a3, __int64 a4)
{
  double v8; // xmm0_8
  float v9; // xmm6_4
  int v10; // ebx
  int v11; // edx
  __int64 v12; // rcx
  int v13; // eax
  bool v14; // cc
  double v15; // xmm0_8
  int v16; // ebx
  int v17; // edx

  if ( *(_DWORD *)(a1 + 696) == 8 )
  {
    v8 = qword_180032C58(a1);
    v9 = *(float *)&v8;
    v10 = qword_180032C50(0i64, 100i64);
    v11 = qword_180032C50(0i64, 100i64);
    v12 = *(_QWORD *)(a2 + 16) + *(_QWORD *)(a2 + 32);
    if ( v10 < 1 )
    {
      v13 = 5000;
      return (float)((float)((float)((float)((float)((float)((float)(int)v12 / (float)(int)*(_QWORD *)(a3 + 24)) * 100.0)
                                           * *(float *)(a1 + 76))
                                   * *(float *)(a1 + 276))
                           * v9)
                   * (float)v13) >= fmax(10.0 - *(float *)(a4 + 92) / 10.0, 1.0)
          || *(_DWORD *)(a1 + 696) == 8 && *(float *)(a2 + 116) > 0.99989998;
    }
    v13 = 1;
    v14 = v11 < 1;
  }
  else
  {
    v15 = qword_180032C58(a1);
    v9 = *(float *)&v15;
    v16 = qword_180032C50(0i64, 100i64);
    v17 = qword_180032C50(0i64, 100i64);
    v12 = *(_QWORD *)(a2 + 16) + *(_QWORD *)(a2 + 32);
    if ( v16 < 1 )
    {
      v13 = 5000;
      return (float)((float)((float)((float)((float)((float)((float)(int)v12 / (float)(int)*(_QWORD *)(a3 + 24)) * 100.0)
                                           * *(float *)(a1 + 76))
                                   * *(float *)(a1 + 276))
                           * v9)
                   * (float)v13) >= fmax(10.0 - *(float *)(a4 + 92) / 10.0, 1.0)
          || *(_DWORD *)(a1 + 696) == 8 && *(float *)(a2 + 116) > 0.99989998;
    }
    v13 = 1;
    v14 = v17 < 5;
  }
  if ( v14 )
    v13 = 100;
  return (float)((float)((float)((float)((float)((float)((float)(int)v12 / (float)(int)*(_QWORD *)(a3 + 24)) * 100.0)
                                       * *(float *)(a1 + 76))
                               * *(float *)(a1 + 276))
                       * v9)
               * (float)v13) >= fmax(10.0 - *(float *)(a4 + 92) / 10.0, 1.0)
      || *(_DWORD *)(a1 + 696) == 8 && *(float *)(a2 + 116) > 0.99989998;
}