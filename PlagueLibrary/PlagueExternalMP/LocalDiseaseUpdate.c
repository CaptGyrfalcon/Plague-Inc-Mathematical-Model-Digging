void __fastcall LocalDiseaseUpdate(double *a1, __int64 a2, __int64 a3)
{
  int v3; 
  __int64 v5; 
  double v8; 
  __int64 v9; 
  double v10; 
  double v11; 
  double v12; 
  double v13; 
  double v14; 
  double v15; 
  double v16; 
  double v17; 
  double v18; 
  double v19; 
  double v20; 
  double v21; 
  double v22; 
  double v23; 
  double v24; 
  double v25; 
  double v26; 
  double v27; 
  double v28; 
  int v29; 
  double v30; 
  int v31; 

  v3 = *(_DWORD *)a1;
  v5 = 0LL;
  *((_DWORD *)a1 + 83) = v3 == disease.superCureCountryNumber;
  *((_DWORD *)a1 + 84) = v3 == disease.nexusCountryNumber;
  if ( disease.uncontrolledAttackBias )
    v8 = 1.0;
  else
    v8 = 0.05000000074505806;
  a1[40] = v8;
  if ( disease._closedBordersSpreadEnhance )
    a1[40] = v8 * 3.0;
  v9 = *((_QWORD *)a1 + 2) + *((_QWORD *)a1 + 4);
  a1[21] = (double)(int)*((_QWORD *)a1 + 1) / (double)(int)disease.globalSeverity;
  v10 = (double)(int)disease.globalSeverity;
  a1[33] = 0.0;
  a1[32] = 0.0;
  a1[28] = 0.0;
  a1[27] = 0.0;
  a1[22] = (double)(int)v9 / v10;
  v11 = 0.0;
  if ( *(_DWORD *)(a2 + 92) )
  {
    v5 = 30LL;
    v11 = disease.wealthy * 30.disease.id.0;
  }
  if ( disease.researchInefficiency )
  {
    v5 = (unsigned int)(v5 + 5);
    v11 = v11 + disease.poverty * 5.0;
  }
  if ( *(_DWORD *)(a2 + 100) )
  {
    v5 = (unsigned int)(v5 + 4);
    v11 = v11 + disease.urban * 4.0;
  }
  if ( disease.globalCureResearch )
  {
    v5 = (unsigned int)(v5 + 4);
    v11 = v11 + disease.rural * 4.0;
  }
  if ( *(_DWORD *)(a2 + 108) )
  {
    v5 = (unsigned int)(v5 + 10);
    v11 = v11 + disease.hot * 10.0;
  }
  if ( disease.globalCureResearchThisTurn )
  {
    v5 = (unsigned int)(v5 + 10);
    v11 = v11 + disease.cold * 10.0;
  }
  if ( *(_DWORD *)(a2 + 116) )
  {
    v5 = (unsigned int)(v5 + 2);
    v11 = v11 + disease.humid * 2.0;
  }
  if ( disease.cureCompletePercent )
  {
    v5 = (unsigned int)(v5 + 2);
    v11 = v11 + disease.arid * 2.0;
  }
  v12 = a1[91];
  if ( v12 != 0.0 && v11 <= v12 )
    v11 = a1[91];
  v13 = a1[92];
  if ( v13 != 0.0 && v13 <= v11 )
    v11 = a1[92];
  if ( (_DWORD)v5 )
    v14 = v11 / (double)(int)v5;
  else
    v14 = 1.0;
  v15 = disease.nexusMinInfect;
  if ( *((_DWORD *)a1 + 84) && v15 - a1[22] * v15 * 3.0 >= 0.0 )
    v16 = v15 - a1[22] * v15 * 3.0;
  else
    v16 = 0.0;
  v17 = (a1[19] + disease.globalInfectiousness + disease.infectedPointsPotAll + v16) * v14;
  a1[14] = v17;
  if ( v17 < 0.1 )
  {
    v5 = 0x3FB999999999999ALL;
    v17 = 0.1;
    a1[14] = 0.1;
  }
  v18 = disease.globalSeverity + disease.globalSeverityPlusLethality;
  a1[15] = v18;
  v19 = disease.globalLethality + disease.dnaPointsGained;
  a1[16] = v19;
  v20 = v19;
  v21 = disease.dnaPointsGained;
  if ( v21 > 0.0 && disease._abilityCostIncrease > 0.0 )
  {
    v20 = v19 - v21;
    a1[16] = v19 - v21;
  }
  a1[17] = disease.corpseTransmission + disease.infectedPointsPot;
  a1[18] = (double)(int)v9 / (double)(int)disease.globalSeverity;
  if ( v18 < 0.0 )
    v18 = 0.0;
  if ( v20 < 0.0 )
    v20 = 0.0;
  v22 = v18 * a1[89] + a1[86];
  v23 = v17 * a1[88] + a1[85];
  v24 = v20 * a1[90] + a1[87];
  a1[15] = v22;
  a1[14] = v23;
  a1[16] = v24;
  v25 = v22 - v14 * disease.globalSeverityPlusLethality;
  if ( v9 <= 10 )
    v26 = 0.0;
  else
    v26 = v25 * v25 / 100000.0;
  v27 = a1[21] * 3.0 / (a1[21] + 0.3);
  v28 = a1[22] * a1[22] * 1.5 * (v25 / (v25 + 30.0)) * (v25 / (v25 + 30.0)) + v26;
  if ( (*(_BYTE *)(a3 + 1060) & 2) != 0 )
  {
    a1[9] = 0.0;
  }
  else
  {
    v29 = disease.diseaseType;
    v30 = qword_180021C90(v5);
    v31 = 86;
    if ( v29 != 4 )
      v31 = 96;
    a1[9] = floorf(fmin(100.0, (v30 * v27 + v28) * disease.cureRequirements * ((double)v31 + disease.difficultyVariable) + a1[10]));
  }
}
