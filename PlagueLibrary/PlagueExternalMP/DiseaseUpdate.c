__int64 __fastcall DiseaseUpdate(double *a1, int a2)
{
  double v4; // xmm8_8
  int v5; // edi
  __int64 v6; // rcx
  double v7; // xmm1_8
  double v8; // xmm6_8
  __int64 v9; // rcx
  double v10; // xmm7_8
  __int64 v11; // rcx
  double v12; // xmm0_8
  double v13; // xmm5_8
  double v14; // xmm4_8
  double v15; // xmm6_8
  double v16; // xmm1_8
  double v17; // xmm3_8
  int v18; // eax
  double v19; // xmm1_8
  double v20; // xmm3_8
  int v21; // eax
  int v22; // eax
  double v23; // xmm3_8
  double v24; // xmm4_8
  void *v25; // rsi
  unsigned int *v26; // rdx
  int v27; // r11d
  unsigned int v28; // r9d
  __int64 v29; // r10
  _QWORD *v30; // r8
  __int64 v31; // r14
  int v32; // esi
  _DWORD *v33; // rdx
  __int64 v34; // rcx
  int v35; // eax
  float v36; // xmm0_4
  __int64 result; // rax
  float v38; // xmm3_4
  double v39; // xmm1_8
  double v40; // xmm0_8
  double v41; // xmm1_8
  double v42; // xmm0_8
  float v43; // xmm2_4
  float v44; // xmm3_4
  double v45; // xmm0_8

  v4 = 0.0;
  v5 = 0;
  v7 = (double)(int)qword_180021C88(0LL, 5LL) * a1[55] * fmax(0.2000000029802322, a1[19]) + disease.globalLethalityMax;
  disease.globalLethalityMax = v7;
  if ( v7 < 0.0 )
    disease.globalLethalityMax = 0.0;
  v8 = qword_180021C90(v6);
  v10 = qword_180021C90(v9);
  v12 = qword_180021C90(v11);
  v13 = a1[7];
  v14 = a1[2] + fmax(v8 * a1[62] * (a1[3] - a1[2]), a1[63]);
  v15 = a1[5];
  v16 = disease._evoPoints + fmax(v10 * disease.cureRequirements * (v15 - disease._evoPoints), a1[65]);
  v17 = a1[6] + fmax(v12 * a1[66] * (v13 - a1[6]), a1[67]);
  if ( v13 < 0.0 )
  {
    a1[7] = 0.0;
    v13 = 0.0;
  }
  v18 = *((_DWORD *)a1 + 254);
  v19 = fmin(v16, v15);
  v20 = fmin(v17, v13);
  a1[2] = fmin(v14, a1[3]);
  disease._evoPoints = v19;
  a1[6] = v20;
  if ( v18 == -1 && v20 > 0.0 )
  {
    a1[6] = 0.0;
    v21 = qword_180021C88(2LL, 6LL);
    v20 = a1[6];
    v19 = disease._evoPoints;
LABEL_10:
    *((_DWORD *)a1 + 254) = v21;
    goto LABEL_11;
  }
  if ( v18 > 0 )
  {
    a1[6] = 0.0;
    v21 = v18 - 1;
    v20 = 0.0;
    goto LABEL_10;
  }
LABEL_11:
  disease.globalInfectiousnessMax = v19 + v20;
  v22 = qword_180021C88(0LL, 100LL);
  if ( *((int *)a1 + 51) < 40 && *((__int64 *)a1 + 103) < 25 )
  {
    v23 = a1[60];
    v24 = 10.0;
    if ( fmax(2.0, v23 + 2.0) <= 10.0 )
      v24 = fmax(2.0, v23 + 2.0);
    if ( v24 > (double)v22 )
    {
      v25 = operator new(0x100uLL);
      sub_1800011F0((int)v25, (int)"NEXUS INFECTION SPREAD: %d");
      if ( qword_180021C98 )
        qword_180021C98(v25);
      v26 = *(unsigned int **)(qword_180021C78 + 8LL * *((int *)a1 + 371));
      qword_180021C60(*v26, v26, 0LL, *(unsigned int *)a1, 1);
    }
  }
  v27 = dword_180021C70;
  v28 = 0;
  a1[107] = 0.0;
  a1[108] = 0.0;
  disease.globalCureResearch = 0.0;
  a1[109] = 0.0;
  a1[103] = 0.0;
  a1[105] = 0.0;
  a1[106] = 0.0;
  a1[119] = 0.0;
  a1[118] = 0.0;
  a1[116] = 0.0;
  disease.globalAirRate = 0.0;
  *((_DWORD *)a1 + 258) = 0;
  a1[113] = 0.0;
  disease.globalCureResearchThisTurn = 0.0;
  a1[111] = 0.0;
  a1[110] = 0.0;
  a1[14] = 0.0;
  if ( v27 > 0 )
  {
    v29 = (unsigned int)v27;
    v30 = (_QWORD *)qword_180021C78;
    v31 = qword_180021C68;
    v32 = v27 * *(_DWORD *)a1;
    do
    {
      v33 = (_DWORD *)*v30;
      v34 = *(_QWORD *)(v31 + 8LL * (v32 + *(_DWORD *)*v30));
      if ( v34 )
      {
        *((_QWORD *)a1 + 105) += *((_QWORD *)v33 + 6);
        *((_QWORD *)a1 + 106) += *(_QWORD *)(v34 + 8);
        *((_QWORD *)disease.globalCureResearch) += *(_QWORD *)(v34 + 16);
        *((_QWORD *)a1 + 103) += *(_QWORD *)(v34 + 32) + *(_QWORD *)(v34 + 16);
        *((_QWORD *)a1 + 108) += *((_QWORD *)v33 + 5);
        *((_QWORD *)a1 + 109) += *((_QWORD *)v33 + 4)
                               - *((_QWORD *)v33 + 33)
                               - *(_QWORD *)(v34 + 16)
                               - *((_QWORD *)v33 + 6)
                               - *(_QWORD *)(v34 + 32);
        a1[116] = *(double *)(v34 + 72) * *((double *)v33 + 8) + a1[116];
        a1[14] = *(double *)(v34 + 88) + a1[14];
        a1[118] = *(double *)(v34 + 96) + a1[118];
        a1[119] = *((double *)v33 + 7) + a1[119];
        if ( *(double *)(v34 + 104) > 3.0 )
          *((_DWORD *)a1 + 242) = 1;
        *((_DWORD *)disease.geneticDrift) += *(_DWORD *)(v34 + 400);
        *((_DWORD *)a1 + 258) += *(_DWORD *)(v34 + 408);
        *((_DWORD *)a1 + 257) += *(_DWORD *)(v34 + 404);
        if ( (__int64)(*(_QWORD *)(v34 + 32) + *(_QWORD *)(v34 + 16)) > 0 )
          ++v28;
      }
      ++v30;
      --v29;
    }
    while ( v29 );
  }
  *((_DWORD *)disease._transmissionCostIncrease) = v28;
  *((_DWORD *)a1 + 253) = v27 - v28;
  v35 = qword_180021C88(0LL, 100LL);
  if ( a1[117] > 0.0 )
  {
    LOBYTE(v5) = *((_DWORD *)a1 + 140) >= 2;
    if ( (double)v5 * (a1[19] * 60.0) + 4.0 > (double)v35 )
      disease.cureCompletePercent = disease.cureCompletePercent + 1.0;
  }
  v36 = floorf(fmin(200.0, a1[116] / (double)dword_180021C70 + disease.cureCompletePercent));
  result = (unsigned int)dword_180021C70;
  v38 = (float)(int)*((_QWORD *)a1 + 106);
  v39 = v36;
  v40 = (double)dword_180021C70;
  a1[116] = v39;
  v41 = a1[118] / v40;
  v42 = a1[119];
  a1[118] = v41;
  *(float *)&v41 = (float)(int)*((_QWORD *)a1 + 103);
  v43 = (float)(int)*((_QWORD *)a1 + 105);
  a1[119] = v42 / (double)(int)result;
  a1[19] = (float)(*(float *)&v41 / (float)a2);
  a1[122] = (float)(v43 / (float)a2);
  a1[125] = (float)(v38 / (float)a2);
  v44 = (float)(int)*((_QWORD *)a1 + 109) / (float)a2;
  v45 = disease._closedBordersSpreadEnhance;
  a1[123] = (float)((float)(int)*((_QWORD *)a1 + 108) / (float)a2);
  a1[124] = v44;
  if ( v45 > 0.0 )
    v4 = a1[13] / v45;
  a1[15] = v4;
  a1[196] = (float)((float)((float)(int)*((_QWORD *)a1 + 106) * 150.0) / (float)a2);
  return result;
}
