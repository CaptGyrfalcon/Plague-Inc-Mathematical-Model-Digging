void __fastcall LocalDiseaseUpdate(CoopLocalDisease localDisease, CoopCountry country, CoopDisease disease)
{
  int v3; // er9
  double v5; // xmm0_8
  __int64 v6; // rcx
  int v7; // eax
  double v8; // xmm0_8
  double v9; // xmm2_8
  double v10; // xmm0_8
  double v11; // xmm0_8
  double localResistance; // xmm2_8
  double v13; // xmm4_8
  double v14; // xmm4_8
  double v15; // xmm1_8
  double v16; // xmm4_8
  double v17; // xmm7_8
  double v18; // xmm5_8
  double v19; // xmm8_8
  double v20; // xmm6_8
  double v21; // xmm5_8
  float v22; // xmm0_4

  v3 = *(_DWORD *)a1;
  *((_DWORD *)a1 + 83) = *(_DWORD *)a1 == *(_DWORD *)(a3 + 1488);
  *((_DWORD *)a1 + 84) = v3 == *(_DWORD *)(a3 + 1484);
  if ( *(_DWORD *)(a2 + 208) )
    v5 = 1.0;
  else
    v5 = 0.05000000074505806;
  a1[40] = v5;
  if ( *(_DWORD *)(a3 + 8) )
    a1[40] = v5 * 3.0;
  v6 = *((_QWORD *)a1 + 2) + *((_QWORD *)a1 + 4);
  v7 = 0;
  a1[21] = (double)(int)*((_QWORD *)a1 + 1) / (double)(int)*(_QWORD *)(a2 + 32);
  v8 = (double)(int)*(_QWORD *)(a2 + 32);
  a1[33] = 0.0;
  a1[32] = 0.0;
  a1[28] = 0.0;
  a1[27] = 0.0;
  localDisease.infectedPercent = (double)(int)v6 / v8;
  v9 = 0.0;
  if ( *(_DWORD *)(a2 + 92) )
  {
    v7 = 30;
    v9 = *(double *)(a3 + 344) * 30.0 + 0.0;
  }
  if ( *(_DWORD *)(a2 + 96) )
  {
    v7 += 5;
    v9 = v9 + *(double *)(a3 + 352) * 5.0;
  }
  if ( *(_DWORD *)(a2 + 100) )
  {
    v7 += 4;
    v9 = v9 + *(double *)(a3 + 360) * 4.0;
  }
  if ( *(_DWORD *)(a2 + 104) )
  {
    v7 += 4;
    v9 = v9 + *(double *)(a3 + 368) * 4.0;
  }
  if ( *(_DWORD *)(a2 + 108) )
  {
    v7 += 10;
    v9 = v9 + *(double *)(a3 + 376) * 10.0;
  }
  if ( *(_DWORD *)(a2 + 112) )
  {
    v7 += 10;
    v9 = v9 + *(double *)(a3 + 384) * 10.0;
  }
  if ( *(_DWORD *)(a2 + 116) )
  {
    v7 += 2;
    v9 = v9 + *(double *)(a3 + 392) * 2.0;
  }
  if ( *(_DWORD *)(a2 + 120) )
  {
    v7 += 2;
    v9 = v9 + *(double *)(a3 + 400) * 2.0;
  }
  v10 = a1[91];
  if ( v10 != 0.0 && v9 <= v10 )
    v9 = a1[91];
  v11 = a1[92];
  if ( v11 != 0.0 && v11 <= v9 )
    v9 = a1[92];
  if ( v7 )
    localResistance = v9 / (double)v7;
  else
    localResistance = 1.0;
  v13 = disease.nexusMinInfect;
  if ( *((_DWORD *)a1 + 84) && v13 - localDisease.infectedPercent * v13 * 3.0 >= 0.0 )
    v14 = v13 - localDisease.infectedPercent * v13 * 3.0;
  else
    v14 = 0.0;
  v15 = ((country.infectBoostCount + 1.0) * disease.globalInfectiousness + localDisease.diseaseSpecificLocalInfectiousness + country.govLocalInfectiousness + v14) * localResistance
      + country.infectBoostCount * 15.0;
  localDisease.localInfectiousness = v15;
  if ( v15 < 0.1 )
  {
    v15 = 0.1;
    localDisease.localInfectiousness = 0.1;
  }
  v16 = *(double *)(a3 + 32) + *(double *)(a2 + 192);
  a1[15] = v16;
  v17 = (country.lethalBoostCount + 1.0) * disease.globalLethality
      + country.govLocalLethality
      + country.lethalBoostCount * 15.0;
  a1[16] = v17;
  v18 = v17;
  v19 = *(double *)(country.govLocalLethality);
  if ( v19 > 0.0 && *(double *)(a2 + 248) > 0.0 )
  {
    v18 = v17 - v19;
    a1[16] = v17 - v19;
  }
  a1[17] = *(double *)(a3 + 432) + *(double *)(a2 + 176);
  a1[18] = (double)(int)v6 / (double)(int)*(_QWORD *)(a2 + 32);
  if ( v16 < 0.0 )
    v16 = 0.0;
  if ( v18 < 0.0 )
    v18 = 0.0;
  v20 = v15 * a1[88] + a1[85];
  v21 = v18 * a1[90] + a1[87];
  a1[15] = v16 * a1[89] + a1[86];
  localDisease.localInfectiousness = v20;
  a1[16] = v21;
  if ( (*(_BYTE *)(a3 + 1060) & 2) != 0 )
  {
    a1[9] = 0.0;
  }
  else
  {
    qword_180021C90(v6, 0i64);
    v22 = sub_18000771C(96i64);
    a1[9] = v22;
    if ( v22 > 200.0 )
      a1[9] = 200.0;
  }
}