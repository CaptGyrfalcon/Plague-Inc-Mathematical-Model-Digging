// Original function: DiseaseUpdate(__int64 a1)
__int64 __fastcall DiseaseUpdate(__int64 d)
{
  float v2; 
  float v3; 
  double v4; 
  float v5; 
  double v6; 
  float v7; 
  double v8; 
  float v9; 
  float v10; 
  float v11; 
  float v12; 
  float v13; 
  float v14; 
  __int64 result; 
  float v16; 
  float v17; 
  bool v18; 
  __int64 v19; 

  if ( d.diseaseType == 9 )
    v2 = (fmaxf(0.30000001, 1.0 - (d.globalSeverity / 150.0))
               * (((IntRand(0LL, 5LL) * d.mutation)
                               * fmaxf(0.2, d.globalInfectedPercent))
                       * ((d.apeTotalInfectedPercent * 0.5) + 1.0)))
       * fmaxf(0.1, 1.0 - (d.globalLethality / 40.0));
  else
    v2 = (IntRand(0LL, 5LL) * d.mutation) * fmaxf(0.2, d.globalInfectedPercent);
  v3 = v2 + d.mutationCounter;
  d.mutationCounter = v3;
  if ( v3 < 0.0 )
    d.mutationCounter = 0;
  v4 = FloatRand();
  v5 = *(float *)&v4;
  v6 = FloatRand();
  v7 = *(float *)&v6;
  v8 = FloatRand();
  v9 = d.globalLethalityMax;
  v10 = d.globalSeverityMax;
  v11 = d.globalInfectiousnessMax;
  v12 = fmaxf((v7 * d.globalSeverityTopMultipler) * (v10 - d.globalSeverity), d.globalSeverityBottomValue)
      + d.globalSeverity;
  v13 = fmaxf((v5 * d.globalInfectiousnessTopMultipler) * (v11 - d.globalInfectiousness), d.globalInfectiousnessBottomValue)
      + d.globalInfectiousness;
  v14 = fmaxf((*(float *)&v8 * d.globalLethalityTopMultipler) * (v9 - d.globalLethality), d.globalLethalityBottomValue)
      + d.globalLethality;
  if ( v9 < 0.0 )
  {
    d.globalLethalityMax = 0;
    v9 = 0.0;
  }
  result = *(unsigned int *)d.lethalityDelayTurns;
  v16 = fminf(v12, v10);
  v17 = fminf(v14, v9);
  d.globalInfectiousness = fminf(v13, v11);
  d.globalSeverity = v16;
  d.globalLethality = v17;
  if ( (_DWORD)result == -1 && v17 > 0.0 )
  {
    v18 = d.diseaseType == 8;
    d.globalLethality = 0;
    v19 = 3LL;
    if ( !v18 )
      v19 = 6LL;
    result = IntRand(2LL, v19);
    d.lethalityDelayTurns = result;
    v17 = d.globalLethality;
    v16 = d.globalSeverity;
  }
  else if ( result > 0 )
  {
    result = (unsigned int)(result - 1);
    d.globalLethality = 0;
    d.lethalityDelayTurns = result;
    v17 = 0.0;
  }
  d.globalSeverityPlusLethality = v16 + v17;
  return result;
}
