void __fastcall LocalDiseaseUpdateSecond_Vampire(__int64 a1, __int64 a2, __int64 a3)
{
  __int64 v6; // rcx
  float v7; // xmm6_4
  float v8; // xmm2_4
  int v9; // eax
  float v10; // xmm2_4
  float v11; // xmm3_4
  float v12; // xmm0_4
  float v13; // xmm1_4
  float v14; // xmm3_4
  float v15; // xmm7_4
  float v16; // xmm2_4
  float v17; // xmm7_4
  float v18; // xmm9_4
  float v19; // xmm11_4
  float v20; // xmm10_4
  float v21; // xmm7_4
  double v22; // xmm0_8

  v6 = *(_QWORD *)(a1 + 16) + *(_QWORD *)(a1 + 32);
  v7 = 0.0;
  v8 = 0.0;
  v9 = 0;
  if ( *(_DWORD *)(country.wealthy) )
  {
    v9 = 37;
    v8 = (float)(fmaxf(0.0, (float)(*(float *)(a3 + 1112) * *(float *)(a3 + 1080)) + *(float *)(a3 + 240)) * 37.0) + 0.0;
  }
  if ( *(_DWORD *)(country.poverty) )
  {
    v9 += 4;
    v8 = v8 + (float)(*(float *)(a3 + 244) * 4.0);
  }
  if ( *(_DWORD *)(country.urban) )
  {
    v9 += 3;
    v8 = v8 + (float)(*(float *)(a3 + 248) * 3.0);
  }
  if ( *(_DWORD *)(country.rural) )
  {
    v9 += 3;
    v8 = v8 + (float)(*(float *)(a3 + 252) * 3.0);
  }
  if ( *(_DWORD *)(country.hot) )
  {
    v9 += 12;
    v8 = v8 + (float)(fmaxf(0.0, (float)(*(float *)(a3 + 1116) * *(float *)(a3 + 1108)) + *(float *)(a3 + 256)) * 12.0);
  }
  if ( *(_DWORD *)(country.cold) )
  {
    v9 += 12;
    v8 = v8 + (float)(fmaxf(0.0, (float)(*(float *)(a3 + 1104) * *(float *)(a3 + 1064)) + *(float *)(a3 + 260)) * 12.0);
  }
  if ( *(_DWORD *)(country.humid) )
  {
    v9 += 3;
    v8 = v8 + (float)(*(float *)(a3 + 264) * 3.0);
  }
  if ( *(_DWORD *)(country.arid) )
  {
    v9 += 3;
    v8 = v8 + (float)(*(float *)(a3 + 268) * 3.0);
  }
  if ( v9 )
    v10 = v8 / (float)v9;
  else
    v10 = 1.0;
  v11 = *(float *)(a2 + 124) + *(float *)(a3 + 16);
  *(float *)(a1 + 92) = v11;
  if ( *(_DWORD *)(a1 + 200) )
  {
    v12 = *(float *)(a3 + 312);
    if ( *(_DWORD *)(a3 + 12) )
      v12 = v12 + *(float *)(a3 + 316);
    v13 = fmaxf(0.0, v12);
    v11 = (float)(v13 - (float)((float)(v13 * *(float *)(a1 + 116)) * 3.0)) + v11;
  }
  v14 = v11 * v10;
  *(float *)(a1 + 92) = v14;
  if ( v14 < 0.050000001 )
  {
    if ( *(float *)(a3 + 20) <= 0.0 )
      *(_DWORD *)(a1 + 92) = 0;
    else
      *(_DWORD *)(a1 + 92) = 1028443341;
  }
  v15 = *(float *)(a3 + 24) + *(float *)(a2 + 136);
  *(float *)(a1 + 96) = v15;
  v16 = *(float *)(a2 + 132) + *(float *)(a3 + 32);
  *(float *)(a1 + 100) = v16;
  *(float *)(a1 + 104) = *(float *)(a3 + 284) + *(float *)(a2 + 128);
  *(float *)(a1 + 108) = (float)(int)v6 / (float)(int)*(_QWORD *)(a2 + 24);
  if ( v15 < 0.0 )
  {
    *(_DWORD *)(a1 + 96) = 0;
    v15 = 0.0;
  }
  if ( v16 < 0.0 )
    *(_DWORD *)(a1 + 100) = 0;
  v17 = v15 - *(float *)(a2 + 136);
  if ( v6 > 10 )
    v7 = (float)(v17 * v17) / 100000.0;
  v18 = *(float *)(a1 + 116);
  v19 = *(float *)(a1 + 112);
  v20 = *(float *)(a1 + 120) * 100.0;
  v21 = v17 / (float)(v17 + 30.0);
  if ( (*(_BYTE *)(a3 + 716) & 2) != 0 )
  {
    *(_DWORD *)(a1 + 72) = 0;
  }
  else
  {
    v22 = qword_180032C58(v6);
    *(float *)(a1 + 72) = sub_18001DA38(
                            fminf(
                              200.0,
                              (float)((float)((float)((float)((float)((float)(v19 * 3.0) / (v19 + 0.3))
                                                            + (float)((float)((float)((float)((float)(v18 * v18) * 1.7)
                                                                                    * v21)
                                                                            * v21)
                                                                    + v7))
                                                    + (float)(*(float *)&v22 * v20))
                                            * *(float *)(a2 + 52))
                                    * (float)(*(float *)(a3 + 356) + 96.0))
                            + *(float *)(a1 + 76)));
  }
}