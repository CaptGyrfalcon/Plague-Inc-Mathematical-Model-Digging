__int64 __fastcall DiseaseInitialise(__int64 a1)
{
  bool v1; // zf
  int v3; // eax
  float v4; // xmm0_4
  float v5; // xmm1_4
  float v6; // xmm0_4
  float v7; // xmm1_4
  float v8; // xmm0_4
  float v9; // xmm1_4
  float v10; // xmm0_4
  float v11; // xmm1_4
  float v12; // xmm0_4
  float v13; // xmm1_4
  float v14; // xmm0_4
  float v15; // xmm1_4
  float v16; // xmm0_4
  float v17; // xmm1_4
  float v18; // xmm0_4
  double v19; // xmm1_8
  double v20; // xmm0_8
  __m128i v21; // xmm1
  float v22; // xmm0_4
  double v23; // xmm0_8
  float v24; // xmm0_4
  float v25; // xmm1_4
  float v26; // xmm0_4
  float v27; // xmm1_4
  float v28; // xmm0_4
  float v29; // xmm1_4
  float v30; // xmm0_4
  float v31; // xmm1_4
  float v32; // xmm0_4
  float v33; // xmm1_4
  double v34; // xmm0_8
  float v35; // xmm0_4
  float v36; // xmm1_4
  float v37; // xmm0_4
  float v38; // xmm1_4
  float v39; // xmm0_4
  float v40; // xmm1_4
  float v41; // xmm0_4
  float v42; // xmm1_4
  float v43; // xmm0_4
  float v44; // xmm1_4
  double v45; // xmm0_8
  double v46; // xmm0_8
  void *v47; // rdi
  void *v48; // rdi
  int v49; // ecx
  float v50; // xmm0_4
  float v51; // xmm1_4
  int v52; // eax
  int v53; // edx
  int v54; // eax
  float v55; // xmm1_4
  float v56; // xmm0_4
  float v57; // xmm1_4
  int v58; // eax
  __int64 v59; // r8
  __int64 result; // rax
  __int64 v61; // rdx

  v1 = *(_DWORD *)(a1 + 1324) == 0;
  *(_DWORD *)(a1 + 164) = 1065353216;
  if ( v1 )
  {
    v3 = *(_DWORD *)(a1 + 352);
    if ( v3 )
    {
      switch ( v3 )
      {
        case 1:
          v21 = _mm_cvtsi32_si128(*(_DWORD *)(disease.droneThreshold));
          v22 = *(float *)(disease.globalInfectiousnessMax) + 1.0;
          ++*(_DWORD *)(disease.aaCostModifier);
          *(_DWORD *)(disease.infectedPointsPot) = 23;
          *(_DWORD *)(disease.difficultyVariable) = 4;
          *(_DWORD *)(disease.fortDifficultyModifier) = 0.9;
          *(float *)(disease.globalInfectiousnessMax) = v22;
          v23 = *(float *)(disease.labBaseResearch);
          *(_DWORD *)(disease.droneThreshold) = (int)(_mm_cvtepi32_pd(v21).m128d_f64[0] * 1.08);
          *(float *)(disease.labBaseResearch) = v23 * 0.82;
          break;
        case 2:
          v24 = *(float *)(disease.globalInfectiousnessMax) + 1.0;
          v25 = *(float *)(disease.wealthy) - 0.15000001;
          *(_DWORD *)(disease.apeMaxLabs) += 2;
          *(_DWORD *)(disease.infectedPointsPot) = 20;
          *(_DWORD *)(disease.difficultyVariable) = 10;
          *(float *)(disease.globalInfectiousnessMax) = v24;
          v26 = *(float *)(disease.poverty) - 0.30000001;
          *(float *)(disease.wealthy) = v25;
          v27 = *(float *)(disease.urban) - 0.2;
          *(_DWORD *)(disease.fortDifficultyModifier) = 0.75;
          *(float *)(disease.poverty) = v26;
          v28 = *(float *)(disease.rural) - 0.2;
          *(float *)(disease.urban) = v27;
          v29 = *(float *)(disease.hot) - 0.1;
          *(float *)(disease.rural) = v28;
          v30 = *(float *)(disease.cold) - 0.1;
          *(float *)(disease.hot) = v29;
          v31 = *(float *)(disease.humid) - 0.2;
          *(float *)(disease.cold) = v30;
          v32 = *(float *)(disease.arid) - 0.2;
          *(float *)(disease.humid) = v31;
          v33 = *(float *)(disease.cureRequirementBase);
          *(float *)(disease.arid) = v32;
          *(float *)(disease.labBaseResearch) = *(float *)(disease.labBaseResearch) * 1.15;
          v34 = (double)(int)*(_QWORD *)(disease.vampireConversionPotTrigger);
          *(float *)(disease.cureRequirementBase) = v33 - (float)(v33 * 0.23999999);
          *(_QWORD *)(disease.vampireConversionPotTrigger) = (unsigned int)(int)(v34 * 1.15);
          break;
        case 3:
          v35 = *(float *)(disease.globalInfectiousnessMax) + 1.0;
          v36 = *(float *)(disease.wealthy) - 0.17;
          *(_DWORD *)(disease.apeMaxLabs) += 4;
          *(_DWORD *)(disease.infectedPointsPot) = 19;
          *(_DWORD *)(disease.difficultyVariable) = 14;
          *(float *)(disease.globalInfectiousnessMax) = v35;
          v37 = *(float *)(disease.poverty) - 0.30000001;
          *(float *)(disease.wealthy) = v36;
          v38 = *(float *)(disease.urban) - 0.2;
          *(_DWORD *)(disease.fortDifficultyModifier) = 0.5;
          *(_DWORD *)(a1 + 160) = 1;
          *(float *)(disease.poverty) = v37;
          v39 = *(float *)(disease.rural) - 0.2;
          *(float *)(disease.urban) = v38;
          v40 = *(float *)(disease.hot) - 0.1;
          *(float *)(disease.rural) = v39;
          v41 = *(float *)(disease.cold) - 0.1;
          *(float *)(disease.hot) = v40;
          v42 = *(float *)(disease.humid) - 0.2;
          *(float *)(disease.cold) = v41;
          v43 = *(float *)(disease.arid) - 0.2;
          *(float *)(disease.humid) = v42;
          v44 = *(float *)(disease.cureRequirementBase);
          *(float *)(disease.arid) = v43;
          v45 = *(float *)(disease.labBaseResearch);
          *(float *)(disease.cureRequirementBase) = v44 - (float)(v44 * 0.23999999);
          *(float *)&v45 = v45 * 1.4;
          *(_DWORD *)(disease.labBaseResearch) = LODWORD(v45);
          v46 = (double)(int)*(_QWORD *)(disease.vampireConversionPotTrigger);
          *(_DWORD *)(disease.droneThreshold) = (int)((double)*(int *)(disease.droneThreshold) * 0.85);
          *(_QWORD *)(disease.vampireConversionPotTrigger) = (unsigned int)(int)(v46 * 1.2);
          break;
        default:
          v47 = operator new(0x100ui64);
          sub_180002900((int)v47, (int)"Unknown difficulty: %d");
          if ( qword_180032C60 )
            qword_180032C60(v47);
          break;
      }
    }
    else
    {
      v4 = *(float *)(disease.globalInfectiousnessMax) + 5.0;
      v5 = *(float *)(disease.wealthy) + 0.40000001;
      *(_DWORD *)(disease.aaCostModifier) += 3;
      --*(_DWORD *)(disease.apeMaxLabs);
      *(_DWORD *)(disease.infectedPointsPot) = 27;
      *(float *)(disease.globalInfectiousnessMax) = v4;
      v6 = *(float *)(disease.poverty) + 0.2;
      *(float *)(disease.wealthy) = v5;
      v7 = *(float *)(disease.urban) + 0.1;
      *(_DWORD *)(disease.difficultyVariable) = 1;
      *(_DWORD *)(disease.fortDifficultyModifier) = 1.6;
      *(float *)(disease.poverty) = v6;
      v8 = *(float *)(disease.rural) + 0.1;
      *(float *)(disease.urban) = v7;
      v9 = *(float *)(disease.hot) + 0.30000001;
      *(float *)(disease.rural) = v8;
      v10 = *(float *)(disease.cold) + 0.5;
      *(float *)(disease.hot) = v9;
      v11 = *(float *)(disease.humid) + 0.1;
      *(float *)(disease.cold) = v10;
      v12 = *(float *)(disease.arid) + 0.1;
      *(float *)(disease.humid) = v11;
      v13 = *(float *)(disease.cureRequirementBase);
      *(float *)(disease.arid) = v12;
      v14 = (float)(v13 * 0.28999999) + v13;
      v15 = *(float *)(disease.seaTransmission) + 1.5;
      *(float *)(disease.cureRequirementBase) = v14;
      v16 = *(float *)(disease.landTransmission) + 1.0;
      *(float *)(disease.seaTransmission) = v15;
      v17 = *(float *)(disease.apeStrength) + 1.0;
      *(float *)(disease.landTransmission) = v16;
      v18 = *(float *)(disease.airTransmission) + 1.0;
      *(float *)(disease.apeStrength) = v17;
      v19 = (double)*(int *)(disease.droneThreshold);
      *(float *)(disease.airTransmission) = v18;
      v20 = *(float *)(disease.labBaseResearch) * 0.67;
      *(_DWORD *)(disease.droneThreshold) = (int)(v19 * 1.2);
      *(float *)&v20 = v20;
      *(_DWORD *)(disease.labBaseResearch) = LODWORD(v20);
      *(float *)&v20 = *(float *)(disease.apeSurvival) + 0.1;
      *(_DWORD *)(disease.apeSurvival) = LODWORD(v20);
      *(float *)&v20 = *(float *)(disease.apeHordeSpeed) * 1.15;
      *(_DWORD *)(disease.apeHordeSpeed) = LODWORD(v20);
      *(_QWORD *)(disease.vampireConversionPotTrigger) = (unsigned int)(int)((double)(int)*(_QWORD *)(disease.vampireConversionPotTrigger) * 0.8);
    }
  }
  v48 = operator new(0x100ui64);
  sub_180002900((int)v48, (int)"BASE MULTIPLIER: %.2f");
  if ( qword_180032C60 )
    qword_180032C60(v48);
  v49 = *(_DWORD *)(a1 + 696);
  v50 = *(float *)(a1 + 348) + *(float *)(disease.infectedPointsPot);
  *(float *)(disease.cureRequirementBase) = (float)(*(float *)(disease.cureRequirementBase) * *(float *)(a1 + 344)) + *(float *)(disease.cureRequirementBase);
  *(float *)(disease.infectedPointsPot) = v50;
  if ( v49 == 2 && !*(_DWORD *)(a1 + 352) )
  {
    v51 = *(float *)(disease.landTransmission) + 15.0;
    *(float *)(disease.globalInfectiousnessMax) = *(float *)(disease.globalInfectiousnessMax) + 3.0;
    *(float *)(disease.landTransmission) = v51;
  }
  if ( v49 == 8 )
  {
    v52 = qword_180032C50(1i64, 10i64);
    v49 = *(_DWORD *)(a1 + 696);
    *(_DWORD *)(a1 + 380) = v52 + 35;
  }
  if ( v49 == 11 )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax) = 0;
    *(_DWORD *)(a1 + 456) = 1088421888;
    *(_DWORD *)(a1 + 468) = 1117782016;
  }
  v53 = 7;
  if ( v49 == 7 )
  {
    v54 = *(_DWORD *)(a1 + 352);
    v49 = 7;
    if ( !v54 )
    {
      v55 = *(float *)(disease.wealthy) + 0.1;
      *(float *)(disease.infectedPointsPot) = *(float *)(disease.infectedPointsPot) + 5.0;
      v56 = *(float *)(disease.cold);
      *(float *)(disease.wealthy) = v55;
      v57 = *(float *)(disease.globalInfectiousnessMax) + 2.0;
      *(float *)(disease.cold) = v56 + 0.2;
      *(float *)(disease.globalInfectiousnessMax) = v57;
      goto LABEL_31;
    }
    if ( v54 >= 2 )
      *(float *)(a1 + 28) = *(float *)(a1 + 28) + 2.0;
  }
  if ( v49 == 12 )
  {
    v58 = *(_DWORD *)(a1 + 352);
    if ( v58 )
    {
      if ( v58 == 3 )
        *(float *)(disease.globalInfectiousnessMax) = *(float *)(disease.globalInfectiousnessMax) + 5.0;
    }
    else
    {
      *(float *)(a1 + 28) = *(float *)(a1 + 28) + 5.0;
    }
  }
LABEL_31:
  if ( (*(_BYTE *)(a1 + 716) & 1) != 0 )
    *(float *)(a1 + 52) = *(float *)(a1 + 52) + 1.0;
  v59 = (unsigned int)(v49 - 1);
  if ( v49 == 1 )
  {
    v53 = 3;
  }
  else
  {
    v59 = (unsigned int)(v49 - 7);
    if ( v49 == 7 )
    {
      v53 = 6;
    }
    else
    {
      v59 = (unsigned int)(v49 - 8);
      if ( v49 != 8 )
      {
        if ( v49 == 9 )
          v53 = 4;
        else
          v53 = -2;
      }
    }
  }
  *(_DWORD *)(disease.globalInfectiousnessMax4) = v53;
  result = 1i64;
  *(_DWORD *)(a1 + 212) = v53;
  *(_DWORD *)(a1 + 220) = v53;
  v61 = *(unsigned int *)(a1 + 352);
  *(_DWORD *)(disease.globalInfectiousnessMax8) = 1;
  if ( !(_DWORD)v61 )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax8) = 0;
    result = 0i64;
  }
  if ( (_DWORD)v61 == 1 )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax8) = 0;
    result = 0i64;
  }
  if ( *(_DWORD *)(a1 + 492) )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax8) = 1;
    result = 1i64;
  }
  if ( v49 == 1 )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax8) = 1;
    result = 1i64;
  }
  if ( v49 == 7 )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax8) = 1;
    result = 1i64;
  }
  if ( v49 == 8 )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax8) = 1;
    result = 1i64;
  }
  if ( v49 == 9 )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax8) = 1;
    result = 1i64;
  }
  if ( v49 == 11 )
  {
    *(_DWORD *)(disease.globalInfectiousnessMax8) = 1;
    result = 1i64;
  }
  *(_DWORD *)(a1 + 216) = result;
  *(_DWORD *)(a1 + 224) = result;
  if ( *(_DWORD *)(a1 + 1324) )
    result = sub_180003B30(a1, v61, v59, 0i64);
  return result;
}