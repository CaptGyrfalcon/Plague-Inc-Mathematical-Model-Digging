// Original function: DiseasePostLocalUpdate(__int64 a1, int a2, int a3)
void __fastcall DiseasePostLocalUpdate(__int64 dat, int totalPop, int infectedPop)
{
  double v3; 
  double v4; 
  double v8; 
  double v9; 
  double v10; 
  int v11; 
  double v12; 
  double v13; 
  double v14; 
  double v15; 
  double v16; 
  int v17; 
  __int64 v18; 
  double v19; 
  double v20; 
  double v21; 
  double v22; 
  __int64 v23; 
  double v24; 
  double v25; 
  double v26; 
  void *v27; 
  __int64 v28; 
  double v29; 
  double v30; 
  double v31; 
  double v32; 
  double v33; 
  void *v34; 
  double v35; 
  double v36; 
  double v37; 
  double v38; 
  void *v39; 
  void *v40; 
  int v41; 
  void *v42; 
  double v43; 
  double v44; 

  v3 = dat.infectedPointsPotAll;
  v4 = fmax(0.0, dat.globalCureResearchThisTurn);
  v8 = 0.0;
  v9 = v4 + dat.globalCureResearch;
  dat.globalCureResearchThisTurn = v4;
  v10 = v4 * dat.researchInefficiencyMultiplier;
  v11 = 200 - dat.dnaPointsGained;
  dat.globalCureResearch = v9;
  v12 = v10 + dat.researchInefficiency;
  v13 = dat.cureBaseMultiplier * dat.cureRequirementBase + v12;
  dat.researchInefficiency = v12;
  dat.cureRequirements = v13;
  if ( v11 > v3 )
  {
    v14 = dat.infectedThisTurn * 0.00000002 * (dat.globalSeverity / 50.0 + 1.0);
    v15 = v14 + dat.infectedPointsPot;
    dat.infectedPointsPot = v15;
    if ( v15 < 0.0 )
      dat.infectedPointsPot = 0LL;
    dat.infectedPointsPotAll = v3 + v14;
  }
  v16 = 0.0;
  v17 = IntRand(0LL, 100LL);
  logf(dat.infectedThisTurn);
  v19 = DoubleRand(v18);
  if ( v17 < 30 )
  {
    if ( v19 >= 0.0 )
      v20 = floor(v19 + 0.5);
    else
      v20 = ceil(v19 - 0.5);
    v16 = fmax(0.0, v20);
  }
  v21 = dat.infectedPointsPot;
  if ( v21 <= v16 )
  {
    v16 = dat.infectedPointsPot;
    v22 = 0.0;
  }
  else
  {
    v22 = v21 - v16;
  }
  v23 = dat.deadThisTurn;
  dat.infectedPointsPot = v22;
  v24 = v23 * 100.0 / totalPop;
  if ( v24 >= 0.0 )
    v25 = floor(v24 + 0.5);
  else
    v25 = ceil(v24 - 0.5);
  v26 = v25;
  v27 = operator new(0x100uLL);
  sub_1800011F0(v27, );
  if ( Debug )
    Debug(v27);
  v29 = 0.0;
  v30 = fmax(0.1, infectedPop / totalPop * (infectedPop / totalPop));
  v31 = DoubleRand(v28);
  dat.infectedIncomeTurnDNA = v31 * v30;
  v32 = v31 * v30 + dat.incomeRemainder;
  *(float *)&v31 = v32;
  v33 = floorf(*(float *)&v31);
  dat.infectedIncome = dat.infectedIncomeTurnDNA + dat.infectedIncome;
  dat.incomeRemainder = v32 - v33;
  if ( v33 > 0.0 )
  {
    v34 = operator new(0x100uLL);
    sub_1800011F0(v34, );
    if ( Debug )
      Debug(v34);
    v29 = v33;
  }
  v35 = dat.globalKilledPercent;
  if ( v35 > 0.0 )
  {
    v36 = (v35 / (v35 + 0.1000000014901161) + 0.01999999955296516) * dat.corpseIncomeMultiplier;
    dat.corpseIncomeTurnDNA = v36;
    v37 = v36 + dat.incomeRemainder;
    v38 = floorf(v37);
    dat.corpseIncome = dat.corpseIncome + dat.corpseIncomeTurnDNA;
    dat.incomeRemainder = v37 - v38;
    if ( v38 > 0.0 )
    {
      v39 = operator new(0x100uLL);
      sub_1800011F0(v39, );
      if ( Debug )
        Debug(v39);
      v8 = v38;
    }
  }
  v40 = operator new(0x100uLL);
  sub_1800011F0(v40, );
  if ( Debug )
    Debug(v40);
  v41 = (v26 + v16 + v29 + v8);
  dat._evoPoints += v41;
  dat._ep2 += v41;
  v42 = operator new(0x100uLL);
  sub_1800011F0(v42, );
  if ( Debug )
    Debug(v42);
  v43 = dat.cureRequirements;
  v44 = dat.globalCureResearch;
  if ( dat._cureFlag )
  {
    if ( v43 > v44 && !dat._cureFlagOverride )
      dat._cureFlag = 0;
  }
  else if ( v44 >= v43 || dat._cureFlagOverride )
  {
    dat._cureFlag = 1;
  }
}
