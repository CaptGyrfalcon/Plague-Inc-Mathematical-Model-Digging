// Original function: LocalDiseaseUpdate(__int64 a1, __int64 a2, __int64 a3)
void __fastcall LocalDiseaseUpdate(__int64 ld, __int64 c, __int64 d)
{
  float v6; 
  __int64 v7; 
  __int64 v8; 
  float v9; 
  float v10; 
  float v11; 
  double v12; 
  float v13; 
  float v14; 
  float v15; 
  float v16; 
  __int64 v17; 
  float v18; 
  __int64 v19; 
  float v20; 
  float v21; 
  int v22; 
  float v23; 
  float v24; 
  __int64 v25; 
  float v26; 
  float v27; 
  float v28; 
  float v29; 
  float v30; 
  float v31; 
  float v32; 
  float v33; 
  float v34; 
  int v35; 
  float v36; 
  float v37; 
  float v38; 
  float v39; 
  float v40; 
  float v41; 
  float v42; 
  float v43; 
  double v44; 
  float v45; 
  float v46; 
  int v47; 

  if ( c._borderStatus )
    v6 = 1.0;
  else
    v6 = 0.050000001;
  ld.borderStatusValue = v6;
  if ( d._closedBordersSpreadEnhance )
    ld.borderStatusValue = v6 * 3.0;
  v7 = ld._controlledInfected + ld.uncontrolledInfected;
  v8 = ld.apeHealthyPopulation;
  v9 = 0.0;
  v10 = ld.killedPopulation / c.originalPopulation;
  ld.deadPercent = v10;
  v11 = v7 / c.originalPopulation;
  v12 = ld.zombie;
  ld.infectedPercent = v11;
  v13 = v12 / c.originalPopulation;
  v14 = 0.0;
  ld.zombiePercent = v13;
  ld.healthyImmunePercent = c.healthyPopulationImmune / c.originalPopulation;
  v15 = c.healthyPopulationSusceptible;
  v16 = c.originalPopulation;
  v17 = ld.apeDeadPopulation;
  ld.healthySusceptiblePercent = v15 / v16;
  v18 = 0.0;
  v19 = ld.apeInfectedPopulation;
  v20 = (v19 + v8 + v17);
  if ( v20 >= 0.5 )
  {
    v21 = v17 / v20;
    v18 = v8 / v20;
    v14 = v19 / v20;
  }
  else
  {
    v21 = 1.0;
  }
  ld.apeInfectedPercent = v14;
  ld.apeHealthyPercent = v18;
  v22 = 0;
  ld.apeDeadPercent = v21;
  v23 = 0.0;
  ld.H2D = 0LL;
  v24 = 1.0;
  ld.I2Z = 0LL;
  ld.I2D = 0LL;
  ld.H2I = 0;
  ld.apeI2D = 0LL;
  ld.apeH2I = 0;
  v25 = *(unsigned int *)c._wealthy;
  if ( d.diseaseType == 9 )
  {
    if ( (_DWORD)v25 )
    {
      v22 = 6;
      v24 = 0.89999998;
      v23 = (d.wealthy * 6.0) + 0.0;
    }
    if ( c._poverty )
    {
      v22 += 3;
      v23 = v23 + (d.poverty * 3.0);
      v24 = v24 * 1.1;
    }
    if ( c._urban )
    {
      v22 += 2;
      v23 = v23 + (d.urban + d.urban);
      v24 = v24 * 0.8;
    }
    if ( c._rural )
    {
      v22 += 2;
      v23 = v23 + (d.rural + d.rural);
      v24 = v24 * 1.2;
    }
    if ( c._hot )
    {
      v22 += 8;
      v23 = v23 + (d.hot * 8.0);
      v24 = v24 * 0.9;
    }
    if ( c._cold )
    {
      v22 += 10;
      v23 = v23 + (d.cold * 10.0);
      v24 = v24 * 0.9;
    }
    if ( c._humid )
    {
      v22 += 2;
      v23 = v23 + (d.humid + d.humid);
      v24 = v24 * 1.1;
    }
    if ( c._arid )
    {
      v23 = v23 + (d.arid + d.arid);
      v24 = v24 * 0.75;
LABEL_42:
      v22 += 2;
    }
  }
  else
  {
    if ( (_DWORD)v25 )
    {
      v22 = 30;
      v23 = (d.wealthy * 30.0) + 0.0;
    }
    if ( c._poverty )
    {
      v22 += 3;
      v23 = v23 + (d.poverty * 3.0);
    }
    if ( c._urban )
    {
      v22 += 2;
      v23 = v23 + (d.urban + d.urban);
    }
    if ( c._rural )
    {
      v22 += 2;
      v23 = v23 + (d.rural + d.rural);
    }
    if ( c._hot )
    {
      v22 += 10;
      v23 = v23 + (d.hot * 10.0);
    }
    if ( c._cold )
    {
      v22 += 10;
      v23 = v23 + (d.cold * 10.0);
    }
    if ( c._humid )
    {
      v22 += 2;
      v23 = v23 + (d.humid + d.humid);
    }
    if ( c._arid )
    {
      v23 = v23 + (d.arid + d.arid);
      goto LABEL_42;
    }
  }
  if ( v24 < 0.2 )
    v24 = 0.2;
  ld.apeSuitability = v24;
  if ( v22 )
    v26 = v23 / v22;
  else
    v26 = 1.0;
  v27 = c.govLocalInfectiousness + d.globalInfectiousness;
  ld.localInfectiousness = v27;
  if ( ld._isNexus )
  {
    v28 = d.nexusMinInfect;
    if ( d._nexusBonus )
      v28 = v28 + d.nexusBonusGene;
    v29 = fmaxf(0.0, v28);
    v27 = (v29 - (v29 * ld.infectedPercent)) + v27;
  }
  v30 = v27 * v26;
  ld.localInfectiousness = v30;
  if ( v30 < 0.050000001 )
    ld.localInfectiousness = 1028443341;
  v31 = d.globalSeverity + c.govLocalSeverity;
  ld.localSeverity = v31;
  v32 = v31;
  if ( d.diseaseType == 8 && (d._zday || d._zdayDone) )
  {
    v32 = v31;
    if ( c._cold )
    {
      v32 = v31 - (v31 * 0.2);
      ld.localSeverity = v32;
    }
    if ( c._arid )
    {
      v32 = v32 - (v32 * 0.050000001);
      ld.localSeverity = v32;
    }
    if ( c._poverty )
    {
      ld.localSeverity = (v32 * 0.050000001) + v32;
      v32 = (v32 * 0.050000001) + v32;
    }
    if ( c._wealthy )
    {
      v32 = v32 - (v32 * 0.050000001);
      ld.localSeverity = v32;
    }
    if ( c._urban )
    {
      ld.localSeverity = (v32 * 0.050000001) + v32;
      v32 = (v32 * 0.050000001) + v32;
    }
    if ( c._rural )
    {
      v32 = v32 - (v32 * 0.050000001);
      ld.localSeverity = v32;
    }
  }
  v33 = c.govLocalLethality + d.globalLethality;
  ld.localLethality = v33;
  ld.localCorpseTransmission = d.corpseTransmission + c.govLocalCorpseTransmission;
  ld.localDeadBodyTransmission = d.deadBodyTransmission + c.govDeadBodyTransmission;
  v34 = v32;
  ld.localInfectedPercent = v7 / c.originalPopulation;
  if ( (unsigned int)(d.diseaseType - 7) <= 1 )
  {
    if ( v32 < 0.050000001 )
    {
      ld.localSeverity = 1028443341;
      v34 = 0.050000001;
    }
  }
  else if ( v32 < 0.0 )
  {
    ld.localSeverity = 0;
    v34 = 0.0;
  }
  if ( v33 < 0.0 )
    ld.localLethality = 0;
  v35 = d.diseaseType;
  v36 = v34 - (v26 * c.govLocalSeverity);
  if ( v35 == 8 )
    v36 = fmaxf(d.globalSeverity, 0.5);
  if ( v7 <= 10 )
    v37 = 0.0;
  else
    v37 = (v36 * v36) / 100000.0;
  v38 = v36;
  if ( v35 == 8 )
  {
    v39 = (v36 * 0.5) + 16.0;
  }
  else
  {
    if ( v35 == 7 )
      v38 = v36 * 0.89999998;
    v39 = v38 + 30.0;
  }
  v40 = v36 / v39;
  if ( v35 == 8 )
    v41 = 1.7;
  else
    v41 = 1.5;
  v42 = ((((ld.infectedPercent * ld.infectedPercent) * v41) * v40) * v40) + v37;
  v43 = (ld.deadPercent * 3.0) / (ld.deadPercent + 0.3);
  if ( v35 == 8 )
    v9 = (ld.zombiePercent * 5.0) / (ld.zombiePercent + 0.2);
  if ( (*(_BYTE *)d.cheatFlags & 2) != 0 )
  {
    ld.localPriority = 0;
  }
  else
  {
    v44 = FloatRand(v25);
    v45 = *(float *)&v44 * v43;
    v46 = v42 + v9;
    v47 = 86;
    if ( v35 != 4 )
      v47 = 96;
    ld.localPriority = floorf(
                            fminf(
                              100.0,
                              (((v46 + v45) * c.importance)
                                    * (v47 + d.difficultyVariable))
                            + ld.localBonusPriority));
  }
}
