// Original function: LocalDiseaseUpdateSecond(__int64 a1, __int64 a2, __int64 a3)
__int64 __fastcall LocalDiseaseUpdateSecond(__int64 ld, __int64 c, __int64 d)
{
  __int64 v5; 
  int v7; 
  float v8; 
  float v9; 
  __int64 v10; 
  double v11; 
  double v12; 
  double v13; 
  float v14; 
  float v15; 
  float v16; 
  __int64 v17; 
  float v18; 
  float v19; 
  float v20; 
  float v21; 
  float v22; 
  __int64 v23; 
  double v24; 
  __int64 v25; 
  double v26; 
  float v27; 
  int v28; 
  float v29; 
  double v30; 
  double v31; 
  double v32; 
  float v33; 
  __int64 v34; 
  double v35; 
  double v36; 
  __int64 v37; 
  double v38; 
  float v39; 
  float v40; 
  __int64 result; 

  v5 = ld._controlledInfected + ld.uncontrolledInfected;
  v7 = d.diseaseType;
  if ( v7 == 5 )
  {
    ld.cureResearchAllocation = 1065353216;
    v8 = 1.0;
    v7 = d.diseaseType;
  }
  else
  {
    v8 = ld.cureResearchAllocation;
  }
  v9 = (v8 * c.medicalBudget) * c.publicOrder;
  if ( v7 == 9 )
  {
    v10 = ld.apeDeadPopulation / d.apeTotalPopulation;
    v11 = v9;
    if ( d.difficulty <= 1 )
    {
      v12 = 2.0;
      v13 = (60 * v10 + 1);
    }
    else
    {
      v12 = 4.0;
      v13 = (((d.difficultyVariable + 65.0) * v10) + 1.0);
    }
    v9 = v11 * fmin(v12, v13);
  }
  ld.localCureResearch = v9;
  if ( ld.localPriority <= 0.0 )
    ld.localPriorityCounter = 0;
  else
    ld.localPriorityCounter = ld.localPriorityCounter + 1.0;
  v14 = c.originalPopulation;
  v15 = ld.localInfectiousness / 100.0;
  v16 = (c.currentPopulation * c.basePopulationDensity) / v14;
  if ( d.diseaseType == 9 )
    v16 = fmax(v16, 0.1);
  v17 = c.deadPopulation;
  v18 = 0.0;
  v19 = fmaxf(0.0, (v17 * ld.localCorpseTransmission) / v14);
  if ( v17 > 0 )
    v18 = ld.localDeadBodyTransmission;
  v20 = (v19 * v15) + (v16 * v15);
  v21 = v18 * v15;
  v22 = ((ld.localLethality * ld.localLethality) * ld.localLethality) / 500000.0;
  if ( d._cureFlag )
  {
    if ( ld.zombie <= 0 )
      *(float *)&v24 = IntRand(0LL, 6LL);
    else
      v24 = FloatRand(0LL);
    ld.cureRollout = *(float *)&v24 + ld.cureRollout;
    v26 = FloatRand(v23);
    v27 = v5;
    ld.H2I = ld.H2I
                         - (((((ld.cureRollout * ld.cureRollout) / 10000.0)
                                                 * v5)
                                         * c.importance)
                                 + (ld.cureRollout * *(float *)&v26));
  }
  else
  {
    v27 = v5;
    ld.cureRollout = 0;
    v28 = d.diseaseType;
    v29 = v5 * v20;
    if ( v28 == 8 )
    {
      v30 = FloatRand(0LL);
      ld.H2I = ((v29 * *(float *)&v30) * (1.1 - ld.infectedPercent))
                           + ld.H2I;
    }
    else if ( v28 == 9 )
    {
      v31 = FloatRand(0LL);
      ld.H2I = ((1.1 - (ld.healthyImmunePercent + ld.infectedPercent))
                                   * (v29 * *(float *)&v31))
                           + ld.H2I;
    }
    else
    {
      v32 = FloatRand(0LL);
      v33 = *(float *)&v32;
      v35 = FloatRand(v34);
      ld.H2I = ((((c.deadPopulation * v21) * *(float *)&v35)
                                           * (1.0 - ld.infectedPercent))
                                   + ((v29 * v33) * (1.2 - ld.infectedPercent)))
                           + ld.H2I;
    }
  }
  v36 = FloatRand(v25);
  ld.I2D = (*(float *)&v36 * v22) * floorf(v27);
  v38 = FloatRand(v37);
  if ( d.globalLethality > 0.0 && (v5 > 0 || d.diseaseType == 8) && !d._zdayDone )
    ld.I2D = (*(float *)&v38 * ld.maxDeadChangePerTurn) + ld.I2D;
  v39 = ld.maxDeadChangePerTurn;
  v40 = (ld.I2D / 1000.0) - v39;
  if ( v40 > v39 )
  {
    ld.maxDeadChangePerTurn = v40;
    v39 = v40;
  }
  if ( c.deadPopulation > v5 + 2 && v39 < 1.0 && d.globalLethality > 0.0 && (v5 > 0 || d.diseaseType == 8) )
    ld.maxDeadChangePerTurn = v39 + 2.0;
  result = *(unsigned int *)d.diseaseType;
  if ( (_DWORD)result == 8 )
  {
    LocalZombieUpdate(ld, c, d);
    result = *(unsigned int *)d.diseaseType;
  }
  if ( (_DWORD)result == 9 )
    return LocalSimianUpdate(ld, c, d);
  return result;
}
