__int64 __fastcall DiseasePostLocalUpdate(__int64 a1, int World.instance.totalPopulation)
{
  float v2; // xmm1_4
  float v4; // xmm2_4
  float v5; // xmm0_4
  int disease.diseaseType; // ecx
  int v7; // eax
  float v8; // xmm1_4
  float v9; // xmm0_4
  float diseaseTypeInfectBonus; // xmm6_4
  float v11; // xmm1_4
  float v12; // xmm4_4
  float v13; // xmm10_4
  float disease.globalSeverity; // xmm3_4
  __int64 disease.infectedThisTurn; // rax
  double v16; // xmm1_8
  float rawInfectedPoints; // xmm2_4
  float v18; // xmm2_4
  float v19; // xmm0_4
  float v20; // xmm1_4
  float v21; // xmm0_4
  float v22; // xmm0_4
  float v23; // xmm2_4
  float v24; // xmm9_4
  float v25; // xmm1_4
  double v26; // xmm0_8
  double v27; // xmm0_8
  float pointToRelease; // xmm6_4
  int v29; // ebx
  __int64 v30; // rcx
  double v31; // xmm0_8
  float v32; // xmm1_4
  double v33; // xmm0_8
  double v34; // xmm0_8
  float v35; // xmm0_4
  float v36; // xmm0_4
  float v37; // xmm0_4
  float v38; // xmm1_4
  float v39; // xmm0_4
  __int64 result; // rax

  v2 = fmaxf(0.0, (disease.globalCureResearchThisTurn));
  v4 = (disease.researchInefficiencyMultiplier);
  v5 = v2 + (disease.globalCureResearch);
  (disease.globalCureResearchThisTurn) = v2;
  (disease.globalCureResearch) = v5;
  disease.diseaseType = (disease.diseaseType);
  if ( disease.diseaseType == 9 )
  {
    v7 = (a1 + 352);
    if ( v7 >= 1 || v4 >= 0.0 )
    {
      if ( v7 < 2 && v4 < 0.0 )
        v4 = v4 * 0.5;
      v8 = v2 * v4;
    }
    else
    {
      v8 = v2 * (float)(v4 * 0.25);
    }
  }
  else
  {
    v8 = v4 * v2;
  }
  v9 = (a1 + 48) * (a1 + 44);
  diseaseTypeInfectBonus = 1.0;
  v11 = v8 + (a1 + 56);
  (a1 + 56) = v11;
  (a1 + 40) = v9 + v11;
  if ( disease.diseaseType == 3 )
    diseaseTypeInfectBonus = 0.1;
  v12 = (disease.infectedPointsPotAll);
  v13 = 100.0;
  if ( 200 - disease.dnaPointsGained > disease.infectedPointsPotAll )
  {
    disease.globalSeverity = (a1 + 24);
    switch ( disease.diseaseType )
    {
		
      case EDiseaseType.NEURAX:
		rawInfectedPoints = (disease.globalSeverity / 100.0 + 1.0) * disease.infectedThisTurn * 0.00000002 + disease.globalSeverity * disease.globalInfectedPercent / 200.0;
        break;
		
      case EDiseaseType.NECROA:
        rawInfectedPoints = (disease.globalSeverity / 100.0 + 1.0) * ((disease.hiZombifiedPopulation) * 0.000000015) + (double)(int)disease.infectedThisTurn * 0.000000005;
        break;
		
      case EDiseaseType.SIMIAN_FLU:
        rawInfectedPoints = (float)((float)(int)disease.infectedThisTurn * 0.000000015) * (float)((float)(disease.globalSeverity / 100.0) + 1.0);
        break;
		
      default:
        rawInfectedPoints = (disease.globalSeverity / 50.0 + 1.0) * ((double)(int)disease.infectedThisTurn * 0.00000002);
    }
    v18 = rawInfectedPoints * diseaseTypeInfectBonus;
    v19 = v18 + disease.infectedPointsPot;
    disease.infectedPointsPot = v19;
    if ( v19 < 0.0 )
      disease.infectedPointsPot = 0;
    (disease.infectedPointsPotAll) = v12 + v18;
  }
  v20 = (a1 + 952);
  v21 = (a1 + 424);
  if ( (float)(v21 * v20) > v20 )
  {
    if ( (float)(v21 - 1.0) > v20 )
    {
      v22 = v21 - (float)(v21 * v20);
      goto LABEL_29;
    }
    v23 = (float)(v21 - 1.0) / v21;
    v21 = 1.0;
    v20 = v20 - v23;
  }
  v22 = v21 - v20;
LABEL_29:
  (a1 + 424) = v22;
  (a1 + 952) = 0;
  if ( disease.diseaseType == EDiseaseType.NEURAX )
    v13 = 80.0;
  v24 = 0.0;
  if ( disease.diseaseType != EDiseaseType.NECROA )
  {
    v25 = (float)((float)(int)(disease.deadThisTurn) * v13) / (float)World.instance.totalPopulation;
    v26 = v25;
    if ( v25 >= 0.0 )
      v27 = floor(v26 + 0.5);
    else
      v27 = ceil(v26 - 0.5);
    v24 = v27;
  }
  
  
  
  
  pointToRelease = 0.0;
  possibility = IntRand(0i64, 100i64);
  infectScale = logf((float)(int)((disease.infectedThisTurn) + 1 + *(_QWORD *)(a1 + 592)));
  infectLuck = FloatRand(infectScale);
  if ( possibility < 30 )
  {
    infectLuck = &infectLuck;
    if ( infectLuck >= 0.0 )
      infectLuckRound = floor(infectLuck + 0.5);
    else
      infectLuckRound = ceil(infectLuck - 0.5);

    pointToRelease = fmaxf(0.0, infectLuckRound);
  }
  v36 = (disease.infectedPointsPot);
  if ( v36 <= pointToRelease )
  {
    pointToRelease = (disease.infectedPointsPot);
    v37 = 0.0;
  }
  else
  {
    v37 = v36 - pointToRelease;
  }
  
  evoPoints.Release(pointToRelease);
  
  
  
  
  v38 = (disease.globalCureResearch);
  (disease.infectedPointsPot) = v37;
  v39 = (a1 + 40);
  result = (unsigned int)(int)(float)(pointToRelease + v24);
  disease.evoPoints += result;
  disease.ep2 += result;
  if ( (a1 + 228) )
  {
    if ( v39 > v38 && !(a1 + 232) )
      (a1 + 228) = 0;
  }
  else if ( v38 >= v39 || (a1 + 232) )
  {
    (a1 + 228) = 1;
  }
  return result;
}