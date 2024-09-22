void __fastcall LocalDiseaseUpdate(SPLocalDiseaseData localDisease, SPCountryData country, SPDiseaseData disease)
{
  float v6; // xmm0_4
  __int64 infectedPercent; // r9
  __int64 v8; // r8
  float zombieAwareness; // xmm7_4
  float v10; // xmm1_4
  float v11; // xmm1_4
  double v12; // xmm2_8
  float v13; // xmm1_4
  float v14; // xmm2_4
  float v15; // xmm1_4
  float v16; // xmm0_4
  __int64 v17; // rdx
  float v18; // xmm1_4
  __int64 v19; // rcx
  float v20; // xmm3_4
  float v21; // xmm0_4
  int totalImportance; // eax
  float resistanceRaw; // xmm3_4
  float apeResistance; // xmm2_4
  int coountry.wealthy; // ecx
  float localResistance; // xmm3_4
  float v27; // xmm2_4
  float v28; // xmm0_4
  float v29; // xmm1_4
  float v30; // xmm2_4
  float localSeverity; // xmm1_4
  float localSeveritySpecial; // xmm4_4
  float v33; // xmm5_4
  float localSeverityTrue; // xmm1_4
  int disease.diseaseType; // ebp
  float environmentalSeverity; // xmm1_4
  float SeverityPower; // xmm2_4
  float environmentalSeverityModified; // xmm0_4
  float environmentalSeverityModifiedPlus; // xmm0_4
  float severityRate; // xmm1_4
  float constK; // xmm0_4
  float infectedAwareness; // xmm6_4
  float deadAwareness; // xmm8_4
  float deadAwarenessModified; // xmm0_4
  float dangerAwareness; // xmm6_4
  int difficultyConst; // eax

  if ( *(_DWORD *)(country._borderStatus) )
    v6 = 1.0;
  else
    v6 = 0.050000001;
  *(float *)(localDisease.borderStatusValue) = v6;
  if ( *(_DWORD *)(disease._closedBordersSpreadEnhance) )
    *(float *)(localDisease.borderStatusValue) = v6 * 3.0;
  infectedPercent = *(_QWORD *)(a1 + 16) + *(_QWORD *)(a1 + 32);
  v8 = *(_QWORD *)(a1 + 264);
  zombieAwareness = 0.0;
  v10 = (double)(int)*(_QWORD *)(a1 + 8) / (double)(int)*(_QWORD *)(a2 + 24);
  *(float *)(localDisease.deadPercent) = v10;
  v11 = (double)(int)infectedPercent / (double)(int)*(_QWORD *)(a2 + 24);
  v12 = (double)(int)*(_QWORD *)(a1 + 24);
  *(float *)(localDisease.infectedPercent) = v11;
  v13 = v12 / (double)(int)*(_QWORD *)(a2 + 24);
  v14 = 0.0;
  *(float *)(localDisease.zombiePercent) = v13;
  *(float *)(a1 + 288) = (float)(int)*(_QWORD *)(a2 + 208) / (float)(int)*(_QWORD *)(a2 + 24);
  v15 = (float)(int)*(_QWORD *)(a2 + 200);
  v16 = (float)(int)*(_QWORD *)(a2 + 24);
  v17 = *(_QWORD *)(a1 + 272);
  *(float *)(a1 + 292) = v15 / v16;
  v18 = 0.0;
  v19 = *(_QWORD *)(a1 + 280);
  v20 = (float)(v19 + v8 + v17);
  if ( v20 >= 0.5 )
  {
    v21 = (float)(int)v17 / v20;
    v18 = (float)(int)v8 / v20;
    v14 = (float)(int)v19 / v20;
  }
  else
  {
    v21 = 1.0;
  }
  *(float *)(a1 + 320) = v14;
  *(float *)(a1 + 316) = v18;
  totalImportance = 0;
  *(float *)(a1 + 324) = v21;
  resistanceRaw = 0.0;
  *(_QWORD *)(a1 + 156) = 0i64;
  apeResistance = 1.0;
  *(_QWORD *)(a1 + 148) = 0i64;
  *(_QWORD *)(a1 + 140) = 0i64;
  *(_DWORD *)(a1 + 136) = 0;
  *(_QWORD *)(a1 + 304) = 0i64;
  *(_DWORD *)(a1 + 300) = 0;
  if (disease.diseaseType == SIMIAN_FLU)
  {
    if (coountry.wealthy)
    {
      totalImportance = 6;
      apeResistance = 0.9f;
      resistanceRaw = disease.wealthy * 6.0;
    }
    if (coountry.poverty)
    {
      totalImportance += 3;
      resistanceRaw = resistanceRaw + disease.poverty * 3.0;
      apeResistance = apeResistance * 1.1f;
    }
    if (coountry.urban)
    {
      totalImportance += 2;
      resistanceRaw = resistanceRaw + disease.urban * 2.0;
      apeResistance = apeResistance * 0.8f;
    }
    if (coountry.rural)
    {
      totalImportance += 2;
      resistanceRaw = resistanceRaw + disease.rural * 2.0;
      apeResistance = apeResistance * 1.2f;
    }
    if (coountry.hot)
    {
      totalImportance += 8;
      resistanceRaw = resistanceRaw + disease.hot * 8.0;
      apeResistance = apeResistance * 0.9f;
    }
    if (coountry.cold)
    {
      totalImportance += 10;
      resistanceRaw = resistanceRaw + disease.cold * 10.0;
      apeResistance = apeResistance * 0.9f;
    }
    if (coountry.humid)
    {
      totalImportance += 2;
      resistanceRaw = resistanceRaw + disease.humid * 2.0;
      apeResistance = apeResistance * 1.1f;
    }
    if (coountry.arid)
    {
      resistanceRaw = resistanceRaw + disease.arid * 2.0;
      apeResistance = apeResistance * 0.75f;
      totalImportance += 2;
    }
  }
  else
  {
    if ( coountry.wealthy )
    {
      totalImportance = 30;
      resistanceRaw = (float)(*(float *)(disease.wealthy) * 30.0) + 0.0;
    }
    if ( *(_DWORD *)(coountry.poverty) )
    {
      totalImportance += 3;
      resistanceRaw = resistanceRaw + (float)(*(float *)(disease.poverty) * 3.0);
    }
    if ( *(_DWORD *)(coountry.urban) )
    {
      totalImportance += 2;
      resistanceRaw = resistanceRaw + (float)(*(float *)(disease.urban) + *(float *)(disease.urban));
    }
    if ( *(_DWORD *)(coountry.rural) )
    {
      totalImportance += 2;
      resistanceRaw = resistanceRaw + (float)(*(float *)(disease.rural) + *(float *)(disease.rural));
    }
    if ( *(_DWORD *)(coountry.hot) )
    {
      totalImportance += 10;
      resistanceRaw = resistanceRaw + (float)(*(float *)(disease.hot) * 10.0);
    }
    if ( *(_DWORD *)(coountry.cold) )
    {
      totalImportance += 10;
      resistanceRaw = resistanceRaw + (float)(*(float *)(disease.cold) * 10.0);
    }
    if ( *(_DWORD *)(coountry.humid) )
    {
      totalImportance += 2;
      resistanceRaw = resistanceRaw + (float)(*(float *)(disease.humid) + *(float *)(disease.humid));
    }
    if ( *(_DWORD *)(coountry.arid) )
    {
      resistanceRaw = resistanceRaw + (float)(*(float *)(disease.arid) + *(float *)(disease.arid));
      totalImportance += 2;
    }
  }
LABEL_43:
  if ( apeResistance < 0.2 )
    apeResistance = 0.2;
  *(float *)(localDisease.apeSuitability) = apeResistance;
  if ( totalImportance )
    localResistance = resistanceRaw / (float)totalImportance;
  else
    localResistance = 1.0;
  v27 = *(float *)(a2 + 124) + *(float *)(a3 + 16);
  *(float *)(a1 + 92) = v27;
  if ( *(_DWORD *)(a1 + 200) )
  {
    v28 = *(float *)(a3 + 312);
    if ( *(_DWORD *)(a3 + 12) )
      v28 = v28 + *(float *)(a3 + 316);
    v29 = fmaxf(0.0, v28);
    v27 = (v29 - (float)(v29 * localDisease.infectedPercent)) + v27;
  }
  v30 = v27 * localResistance;
  *(float *)(a1 + 92) = v30;
  if ( v30 < 0.050000001 )
    *(_DWORD *)(a1 + 92) = 1028443341;
  localSeverity = disease.globalSeverity + country.govLocalSeverity;
  localDisease.localSeverity = localSeverity;
  localSeveritySpecial = localSeverity;
  if ( *(_DWORD *)(disease.diseaseType) == 8 && (*(_DWORD *)(a3 + 360) || *(_DWORD *)(a3 + 364)) )
  {
    localSeveritySpecial = localSeverity;
    if ( *(_DWORD *)(coountry.cold) )
    {
      localSeveritySpecial = localSeverity - (float)(localSeverity * 0.2);
      *(float *)(localDisease.localSeverity) = localSeveritySpecial;
    }
    if ( *(_DWORD *)(coountry.arid) )
    {
      localSeveritySpecial = localSeveritySpecial - (float)(localSeveritySpecial * 0.050000001);
      *(float *)(localDisease.localSeverity) = localSeveritySpecial;
    }
    if ( *(_DWORD *)(coountry.poverty) )
    {
      *(float *)(localDisease.localSeverity) = (float)(localSeveritySpecial * 0.050000001) + localSeveritySpecial;
      localSeveritySpecial = (float)(localSeveritySpecial * 0.050000001) + localSeveritySpecial;
    }
    if ( *(_DWORD *)(coountry.wealthy) )
    {
      localSeveritySpecial = localSeveritySpecial - (float)(localSeveritySpecial * 0.050000001);
      *(float *)(localDisease.localSeverity) = localSeveritySpecial;
    }
    if ( *(_DWORD *)(coountry.urban) )
    {
      *(float *)(localDisease.localSeverity) = (float)(localSeveritySpecial * 0.050000001) + localSeveritySpecial;
      localSeveritySpecial = (float)(localSeveritySpecial * 0.050000001) + localSeveritySpecial;
    }
    if ( *(_DWORD *)(coountry.rural) )
    {
      localSeveritySpecial = localSeveritySpecial - (float)(localSeveritySpecial * 0.050000001);
      *(float *)(localDisease.localSeverity) = localSeveritySpecial;
    }
  }
  v33 = *(float *)(a2 + 132) + *(float *)(a3 + 32);
  *(float *)(a1 + 100) = v33;
  *(float *)(a1 + 104) = *(float *)(a3 + 284) + *(float *)(a2 + 128);
  *(float *)(a1 + 516) = *(float *)(a3 + 1300) + *(float *)(a2 + 268);
  localSeverityTrue = localSeveritySpecial;
  *(float *)(a1 + 108) = (float)(int)infectedPercent / (float)(int)*(_QWORD *)(a2 + 24);
  if ( disease.diseaseType <= 8 )
  {
    if ( localSeveritySpecial < 0.05 )
    {
      *(_DWORD *)(localDisease.localSeverity) = 1028443341;
      localSeverityTrue = 0.05;
    }
  }
  else if ( localSeveritySpecial < 0.0 )
  {
    *(_DWORD *)(localDisease.localSeverity) = 0;
    localSeverityTrue = 0.0;
  }
  if ( v33 < 0.0 )
    *(_DWORD *)(a1 + 100) = 0;
  disease.diseaseType = disease.diseaseType;
  environmentalSeverity = localSeverityTrue - localResistance * country.govLocalSeverity;
  if ( disease.diseaseType == 8 )
    environmentalSeverity = fmaxf(disease.globalSeverity, 0.5);
  if ( totalInfected <= 10 )
    SeverityPower = 0.0;
  else
    SeverityPower = environmentalSeverity * environmentalSeverity / 100000.0;
  environmentalSeverityModified = environmentalSeverity;
  if ( disease.diseaseType == 8 )
  {
    environmentalSeverityModifiedPlus = environmentalSeverity * 0.5 + 16.0;
  }
  else
  {
    if ( disease.diseaseType == 7 )
      environmentalSeverityModified = environmentalSeverity * 0.9;
    environmentalSeverityModifiedPlus = environmentalSeverityModified + 30.0;
  }
  severityRate = environmentalSeverity / environmentalSeverityModifiedPlus;
  if ( disease.diseaseType == 8 )
    constK = 1.7;
  else
    constK = 1.5;
  infectedAwareness = localDisease.infectedPercent * localDisease.infectedPercent * constK * severityRate * severityRate + SeverityPower;
  if ( disease.diseaseType != 9 && disease.diseaseType == 8 )
    zombieAwareness = (localDisease.zombiePercent * 5.0) / (localDisease.zombiePercent + 0.2);
  if ( (*(_BYTE *)(a3 + 716) & 2) != 0 )
  {
    localDisease.localPriority = 0;
  }
  else
  {
    deadAwareness = (localDisease.deadPercent * 3.0) / (localDisease.deadPercent + 0.3);
    deadAwarenessModified = qword_180032C58() * deadAwareness;
    dangerAwareness = infectedAwareness + zombieAwareness;
    difficultyConst = 86;
    if ( disease.diseaseType != disease.EDiseaseType.PRION )
      difficultyConst = 96;
    localDisease.localPriority = 
                            fminf(
                              100.0,
                              (((dangerAwareness + deadAwarenessModified) * country.importance)
                                    * (difficultyConst + disease.difficultyVariable))
                            + localDisease.localBonusPriority);
  }
}

public Enum Disease.EDiseaseType
{
	