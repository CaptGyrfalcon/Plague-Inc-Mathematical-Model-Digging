__int64 __fastcall LocalDiseaseUpdateSecond(__int64 a1, __int64 a2, __int64 a3)
{
  __int64 allInfected; // rbp
  int v7; // eax
  float v8; // xmm0_4
  float v9; // xmm0_4
  __int64 v10; // rax
  double v11; // xmm3_8
  __int64 v12; // xmm2_8
  double v13; // xmm0_8
  float v14; // xmm2_4
  float v15; // xmm3_4
  float v16; // xmm1_4
  __int64 v17; // rax
  float v18; // xmm11_4
  float v19; // xmm2_4
  float v20; // xmm2_4
  float v21; // xmm11_4
  float v22; // xmm10_4
  __int64 v23; // rcx
  double v24; // xmm0_8
  __int64 v25; // rcx
  double v26; // xmm0_8
  float allInfected; // xmm12_4
  int v28; // eax
  float v29; // xmm7_4
  double v30; // xmm0_8
  double v31; // xmm0_8
  double v32; // xmm0_8
  float v33; // xmm6_4
  __int64 v34; // rcx
  double v35; // xmm0_8
  double v36; // xmm0_8
  __int64 v37; // rcx
  double v38; // xmm0_8
  float v39; // xmm1_4
  float v40; // xmm0_4
  __int64 result; // rax

  allInfected = *(_QWORD *)(localDisease.controlledInfected) + *(_QWORD *)(localDisease.uncontrolledInfected);
  v7 = *(_DWORD *)(a3 + 696);
  if ( v7 == 5 )
  {
    *(_DWORD *)(a1 + 84) = 1065353216;
    v8 = 1.0;
    v7 = *(_DWORD *)(a3 + 696);
  }
  else
  {
    v8 = *(float *)(a1 + 84);
  }
  v9 = (float)(v8 * *(float *)(a2 + 56)) * *(float *)(a2 + 48);
  if ( v7 == 9 )
  {
    v10 = *(_QWORD *)(a1 + 272) / *(__int64 *)(a3 + 936);
    v11 = v9;
    if ( *(int *)(a3 + 352) <= 1 )
    {
      v12 = 0x4000000000000000i64;
      v13 = (double)(60 * (int)v10 + 1);
    }
    else
    {
      v12 = 0x4010000000000000i64;
      v13 = (float)((float)((float)(*(float *)(a3 + 356) + 65.0) * (float)(int)v10) + 1.0);
    }
    v9 = v11 * fmin(*(double *)&v12, v13);
  }
  *(float *)(a1 + 80) = v9;
  if ( *(float *)(a1 + 72) <= 0.0 )
    *(_DWORD *)(a1 + 88) = 0;
  else
    *(float *)(a1 + 88) = *(float *)(a1 + 88) + 1.0;
  v14 = (float)(int)*(_QWORD *)(a2 + 24);
  v15 = *(float *)(a1 + 92) / 100.0;
  v16 = (float)((float)(int)*(_QWORD *)(a2 + 16) * *(float *)(a2 + 60)) / v14;
  if ( *(_DWORD *)(a3 + 696) == 9 )
    v16 = fmax(v16, 0.1);
  v17 = *(_QWORD *)(a2 + 40);
  v18 = 0.0;
  v19 = fmaxf(0.0, (float)((float)(int)v17 * *(float *)(a1 + 104)) / v14);
  if ( v17 > 0 )
    v18 = *(float *)(a1 + 516);
  v20 = (float)(v19 * v15) + (float)(v16 * v15);
  v21 = v18 * v15;
  v22 = (float)((float)(*(float *)(a1 + 100) * *(float *)(a1 + 100)) * *(float *)(a1 + 100)) / 500000.0;
  if ( *(_DWORD *)(disease.cureFlag) )
  {
    if ( localDisease.zombie <= 0 )
      v24 = IntRand(0, 6);
    else
      v24 = FloatRand(0i64);
    localDisease.cureRollout = IntRand(0, 6) + localDisease.cureRollout;
    localDisease.H2I = 
                         - (
						 localDisease.cureRollout * localDisease.cureRollout / 10000.0
                                                 * allInfected
                                         * country.importance
                                 + localDisease.cureRollout * FloatRand(0f, 1f)
								 );
  }
  else
  {
    allInfected = (float)(int)allInfected;
    *(_DWORD *)(localDisease.cureRollout) = 0;
    v28 = *(_DWORD *)(a3 + 696);
    v29 = (float)(int)allInfected * v20;
    if ( v28 == 8 )
    {
      v30 = FloatRand(0i64);
      *(float *)(localDisease.H2I) = (float)((float)(v29 * *(float *)&v30) * (float)(1.1 - *(float *)(a1 + 116)))
                           + *(float *)(localDisease.H2I);
    }
    else if ( v28 == 9 )
    {
      v31 = FloatRand(0i64);
      *(float *)(localDisease.H2I) = (float)((float)(1.1 - (float)(*(float *)(a1 + 288) + *(float *)(a1 + 116)))
                                   * (float)(v29 * *(float *)&v31))
                           + *(float *)(localDisease.H2I);
    }
    else
    {
      v32 = FloatRand(0i64);
      v33 = *(float *)&v32;
      v35 = FloatRand(v34);
      *(float *)(localDisease.H2I) = (float)((float)((float)((float)((float)(int)*(_QWORD *)(a2 + 40) * v21) * *(float *)&v35)
                                           * (float)(1.0 - *(float *)(a1 + 116)))
                                   + (float)((float)(v29 * v33) * (float)(1.2 - *(float *)(a1 + 116))))
                           + *(float *)(localDisease.H2I);
    }
  }
  v36 = FloatRand(v25);
  *(float *)(a1 + 140) = (float)(*(float *)&v36 * v22) * sub_18001DA38(allInfected);
  v38 = FloatRand(v37);
  if ( *(float *)(a3 + 32) > 0.0 && (allInfected > 0 || *(_DWORD *)(a3 + 696) == 8) && !*(_DWORD *)(a3 + 364) )
    *(float *)(a1 + 140) = (float)(*(float *)&v38 * *(float *)(a1 + 132)) + *(float *)(a1 + 140);
  v39 = *(float *)(a1 + 132);
  v40 = (float)(*(float *)(a1 + 140) / 1000.0) - v39;
  if ( v40 > v39 )
  {
    *(float *)(a1 + 132) = v40;
    v39 = v40;
  }
  if ( *(_QWORD *)(a2 + 40) > allInfected + 2 && v39 < 1.0 && *(float *)(a3 + 32) > 0.0 && (allInfected > 0 || *(_DWORD *)(a3 + 696) == 8) )
    *(float *)(a1 + 132) = v39 + 2.0;
  result = *(unsigned int *)(a3 + 696);
  if ( (_DWORD)result == 8 )
  {
    LocalZombieUpdate(a1, a2, a3);
    result = *(unsigned int *)(a3 + 696);
  }
  if ( (_DWORD)result == 9 )
    result = LocalSimianUpdate(a1, a2, a3);
  return result;
}