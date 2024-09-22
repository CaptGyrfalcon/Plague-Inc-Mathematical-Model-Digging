// Original function: LocalDiseaseUpdateSecond(__int64 a1, double * a2, double * a3)
__int64 __fastcall LocalDiseaseUpdateSecond(__int64 ld, double *c, double *d)
{
  void *v6; 
  void *v7; 
  __int64 v8; 
  __int64 v9; 
  double v10; 
  __int64 v11; 
  double v12; 
  double v13; 
  double v14; 
  __int64 v15; 
  __int64 v16; 
  double v17; 
  double v18; 
  double v19; 
  double v20; 
  __int64 v21; 
  __int64 v22; 
  double v23; 
  double v24; 
  double v25; 
  int v26; 
  __int64 v27; 
  __int64 v28; 
  __int64 v29; 
  __int64 v30; 
  double v31; 
  __int64 v32; 
  int v33; 
  int v34; 
  int v35; 
  __int64 result; 
  __int64 v37; 
  __int64 v38; 
  __int64 v39; 

  if ( ld._isNexus > 0 )
  {
    v6 = operator new(0x100uLL);
    v37 = ld._controlledInfected;
    v7 = v6;
    sub_1800011F0((int)v6, (int));
    if ( Debug )
      Debug(v7);
  }
  v8 = ld._controlledInfected + ld.uncontrolledInfected;
  ld.localCureResearch = c.medicalBudget * ld.cureResearchAllocation * c.publicOrder * (d.researchFocusMod + 1.0);
  BenignMimic(*(unsigned int *)c, *(unsigned int *)d);
  v10 = 0.0;
  if ( ld.localPriority <= 0.0 )
    ld.localPriorityCounter = 0LL;
  else
    ld.localPriorityCounter = ld.localPriorityCounter + 1.0;
  v11 = c.originalPopulation;
  v12 = (double)(int)c.currentPopulation * c.basePopulationDensity / (double)(int)v11;
  if ( v12 <= 0.01 )
    v12 = 0.01;
  v13 = ld.localLethality * ld.localLethality * ld.localLethality / 500000.0;
  v14 = fmax(0.0, (double)(int)ld.killedPopulation * ld.localCorpseTransmission / (double)(int)v11)
      * (ld.localInfectiousness
       / 100.0)
      + v12 * (ld.localInfectiousness / 100.0);
  if ( d._cureFlag )
  {
    if ( ld.benignMimicCounter )
    {
      ld.cureRollout = ld.cureRollout + 1.0;
      v17 = DoubleRand(v9);
      v18 = ld.cureRollout;
      v19 = v18 * v18 / 20000.0;
    }
    else
    {
      ld.cureRollout = (double)(int)IntRand(0LL, 6LL) * c.importance * c.importance + ld.cureRollout;
      v17 = DoubleRand(v15);
      v18 = ld.cureRollout;
      v19 = v18 * v18 / 10000.0;
    }
    ld.H2I = ld.H2I - (v19 * (double)(int)v8 * c.importance + v18 * v17);
  }
  else
  {
    ld.cureRollout = 0LL;
    ld.H2I = (1.2 - ld.infectedPercent) * (DoubleRand(v9) * v14) * (double)(int)v8
                          + ld.H2I;
  }
  if ( v8 <= 0 )
    ld.maxDeadChangePerTurn = 0LL;
  v20 = DoubleRand(v16);
  ld.I2D = floorf((float)(int)v8) * (v20 * v13);
  v23 = DoubleRand(v21);
  if ( d.globalLethality > 0.0 && (v8 > 0 || d.diseaseType == 8) && !d._zdayDone )
    ld.I2D = v23 * ld.maxDeadChangePerTurn + ld.I2D;
  v24 = ld.maxDeadChangePerTurn;
  if ( ld.I2D / 1000.0 - v24 > v24 )
  {
    v25 = ld.I2D / 1000.0 - v24;
    ld.maxDeadChangePerTurn = v25;
    v24 = v25;
  }
  if ( ld.killedPopulation > v8 + 2 && v24 < 2.0 && d.globalLethality > 0.0 && (v8 > 0 || d.diseaseType == 8) )
    ld.maxDeadChangePerTurn = v24 + 0.15;
  if ( ld.benignMimicCounter > 0 )
  {
    if ( !d._cureFlag )
      ld.H2I = 0LL;
    ld.H2D = 0LL;
    ld.I2D = 0LL;
  }
  v26 = 1;
  v27 = ld._controlledInfected + ld.uncontrolledInfected;
  LODWORD(v37) = 1;
  TransferPopulation(*(unsigned int *)c, v22, 0LL, *(unsigned int *)d, v37);
  v28 = ld._controlledInfected + ld.uncontrolledInfected - v27;
  LODWORD(v38) = 2;
  v31 = TransferPopulation(*(unsigned int *)c, v29, 1LL, *(unsigned int *)d, v38);
  if ( v31 > 0.0 )
  {
    LODWORD(v39) = 2;
    v28 += (int)(v31 - TransferPopulation(*(unsigned int *)c, v30, 0LL, *(unsigned int *)d, v39));
  }
  LethalAttack(*(unsigned int *)c, v30, *(unsigned int *)d);
  if ( ld.immuneShockCounter > 0 )
    ImmuneShock(*(unsigned int *)c, *(unsigned int *)d);
  LODWORD(v39) = 2;
  TransferPopulation(*(unsigned int *)c, v32, 0LL, *(unsigned int *)d, v39);
  ld.deadPopulationOverride = 0LL;
  v33 = 10;
  ld.infectedPopulationOverride = 0LL;
  ld.Z2DOverride = 0LL;
  ld.H2DOverride = 0LL;
  ld.H2ZOverride = 0LL;
  ld.I2ZOverride = 0LL;
  ld.D2ZOverride = 0LL;
  d.infectedThisTurn += v28;
  d.deadThisTurn += ld.killedPopulation - ld.prevKilled;
  ld.prevInfected = ld._controlledInfected + ld.uncontrolledInfected;
  ld.prevKilled = ld.killedPopulation;
  v34 = (int)((c.medicalBudget + 1.0) / 1000.0);
  if ( v34 >= 2 )
  {
    v26 = 10;
    if ( v34 < 10 )
      v26 = (int)((c.medicalBudget + 1.0) / 1000.0);
  }
  v35 = (int)((1.0 - c.publicOrder) * (double)v26);
  if ( v35 < 1 )
  {
    v33 = 0;
  }
  else if ( v35 < 10 )
  {
    v33 = (int)((1.0 - c.publicOrder) * (double)v26);
  }
  ld.flaskBroken = v33;
  if ( fmin(ceil((double)v26 * ld.cureResearchAllocation), (double)(v26 - v33)) > 0.0 )
  {
    v33 = ld.flaskBroken;
    v10 = fmin(ceil((double)v26 * ld.cureResearchAllocation), (double)(v26 - v33));
  }
  ld.flaskResearched = (int)v10;
  ld.flaskEmpty = v26 - (int)v10 - v33;
  ld.originalPopulation = c.originalPopulation;
  result = c.originalPopulation - c.deadPopulation - ld.uncontrolledInfected - ld._controlledInfected;
  ld.uninfectedPopulation = result;
  return result;
}
