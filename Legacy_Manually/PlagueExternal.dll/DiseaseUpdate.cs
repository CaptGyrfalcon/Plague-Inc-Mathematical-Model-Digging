__int64 __fastcall DiseaseUpdate(__int64 a1)
{
  float accumulatedMutation; // xmm3_4
  float v3; // xmm3_4
  double v4; // xmm0_8
  float v5; // xmm8_4
  double v6; // xmm0_8
  float v7; // xmm6_4
  double v8; // xmm0_8
  float v9; // xmm2_4
  float v10; // xmm5_4
  float v11; // xmm4_4
  float v12; // xmm6_4
  float v13; // xmm8_4
  float v14; // xmm3_4
  __int64 result; // rax
  float v16; // xmm6_4
  float v17; // xmm3_4
  bool v18; // zf
  __int64 v19; // rdx

  if (disease.diseaseType == Disease.EDiseaseType.SIMIAN_FLU)
    accumulatedMutation = 
				 fmaxf(0.3, 1.0 - disease.globalSeverity / 150.0)
               * IntRand(0, 5) 
			   * disease.mutation
               * fmaxf(0.2, disease.globalInfectedPercent)
               * (disease.apeTotalInfectedPercent * 0.5 + 1.0)
			   * fmaxf(0.1, 1.0 - disease.globalLethality / 40.0);
  else
    accumulatedMutation = (float)IntRand(0, 5) * (disease.mutation) * fmaxf(0.2, disease.globalInfectedPercent);
  disease.mutationCounter += accumulatedMutation;
  if(disease.mutationCounter < 0)
	  disease.mutationCounter = 0;
  v4 = FloatRand(0f, 1f);
  v5 = *(float *)&v4;
  v6 = FloatRand(0f, 1f);
  v7 = *(float *)&v6;
  v8 = FloatRand(0f, 1f);
  v9 = disease.globalLethalityMax;
  v10 = disease.globalSeverityMax;
  v11 = disease.globalInfectiousnessMax;
  v12 = fmaxf((float)(FloatRand(0f, 1f) * disease.globalSeverityTopMultipler) * (disease.globalSeverityMax - disease.globalSeverity), disease.globalSeverityBottomValue)
      + *(float *)(disease.globalSeverity);
  v13 = fmaxf((float)(FloatRand(0f, 1f) * disease.globalInfectiousnessTopMultipler) * (disease.globalInfectiousnessMax - disease.globalInfectiousness), disease.globalInfectiousnessBottomValue)
      + *(float *)(disease.globalInfectiousness);
  v14 = fmaxf((float)(FloatRand(0f, 1f) * disease.globalLethalityTopMultipler) * (disease.globalLethalityMax - disease.globalLethality), disease.globalLethalityBottomValue)
      + *(float *)(disease.globalLethality);
  if ( disease.globalLethalityMax < 0.0 )
  {
    *(_DWORD *)(a1 + 36) = 0;
    disease.globalLethalityMax = 0.0;
  }
  result = *(unsigned int *)(a1 + 676);
  v16 = fminf(v12, v10);
  v17 = fminf(v14, disease.globalLethalityMax);
  *(float *)(disease.globalInfectiousness) = fminf(v13, v11);
  *(float *)(disease.globalSeverity) = v16;
  *(float *)(disease.globalLethality) = v17;
  if ( (_DWORD)result == -1 && v17 > 0.0 )
  {
    v18 = *(_DWORD *)(disease.diseaseType) == 8;
    *(_DWORD *)(disease.globalLethality) = 0;
    v19 = 3i64;
    if ( !v18 )
      v19 = 6i64;
    result = IntRand(2i64, v19);
    *(_DWORD *)(a1 + 676) = result;
    v17 = *(float *)(disease.globalLethality);
    v16 = *(float *)(disease.globalSeverity);
  }
  else if ( (int)result > 0 )
  {
    result = (unsigned int)(result - 1);
    *(_DWORD *)(disease.globalLethality) = 0;
    *(_DWORD *)(a1 + 676) = result;
    v17 = 0.0;
  }
  *(float *)(a1 + 104) = v16 + v17;
  return result;
}