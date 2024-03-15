__int64 __fastcall LocalZombieUpdate(__int64 a1, __int64 a2, __int64 a3)
{
  float v4; // xmm9_4
  __int64 totalInfected; // rbp
  __int64 a1; // rdi
  int disease.zdayCounter; // eax
  bool v9; // zf
  double FloatRand(0f, 1f); // xmm0_8
  float v11; // xmm6_4
  __int64 v12; // rcx
  double FloatRand(0f, 1f); // xmm0_8
  __int64 v14; // rcx
  double v15; // xmm0_8
  double floatRand_1; // xmm0_8
  float floatRand_1 * disease.zombieConversionMod; // xmm2_4
  float rate2D; // xmm6_4
  float rate2Z; // xmm7_4
  __int64 v20; // rcx
  double expectedH2D; // xmm0_8
  double expectedH2DZ; // xmm3_8
  float expectedH2Z; // xmm15_4
  __int64 v24; // rcx
  double v25; // xmm0_8
  float expectedI2DZ; // xmm14_4
  float expectedI2D; // xmm3_4
  float expectedI2Z; // xmm14_4
  float humanStrengthAdvantage; // xmm7_4
  __int64 v30; // rcx
  __int64 v31; // rcx
  double v32; // xmm0_8
  __int64 country.healthyPopulation; // rax
  float zombieKilledRaw; // xmm1_4
  float zombieKilled; // xmm12_4
  float zombieDecayEnvironmentalRate; // xmm7_4
  __int64 v37; // rcx
  double v38; // xmm0_8
  __int64 localDisease.zombie; // rax
  float expectedZ2D; // xmm6_4
  float v41; // xmm0_4
  float v42; // xmm0_4
  float v43; // xmm1_4
  double v44; // xmm0_8
  float v45; // xmm2_4
  float FloatRand(0f, 1f) * localDisease.maxDecayChangePerTurn + localDisease.Z2D; // xmm3_4
  __int64 v47; // rcx
  float v48; // xmm2_4
  __int64 v49; // rax
  float country.battleVictoryCount; // xmm1_4
  float v51; // xmm1_4
  double v52; // xmm0_8
  int v53; // eax
  int v54; // eax
  double v55; // xmm0_8
  float v56; // xmm3_4
  __int64 v57; // rcx
  float newHumanStrenth; // xmm2_4
  __int64 result; // rax
  float expectedH2D; // [rsp+E0h] [rbp+8h]
  
  //the initial value of disease.zdayDead is 1e-7, times 1.25 everyday if zday
  //the initial value of disease.zdayInfected is 0, plus 0.005 everyday if zday
  //zday lasts for 36~45 days, then zday will be set to false, while zdayDone set to true


  totalInfected = localDisease.controlledInfected + localDisease.uncontrolledInfected;
  if ( disease.zday )
  {
    if ( localDisease.isNexus && disease.zdayCounter < 6  )
    {
      localDisease.D2Z = country.deadPopulation * disease.zdayDead + IntRand(1, 5);
    }
    if ( disease.zdayCounter >= 6 )
    {
      localDisease.D2Z = country.deadPopulation * disease.zdayDead;
      if ( localDisease.isNexus )
	  {
			localDisease.D2Z = IntRand(1, 5) + localDisease.D2Z;
	  }
	  randomConversionMod = 
	  v11 = (1.0 - ran) *conv + ran;
      localDisease.H2Z = fminf(
                               [country.healthyPopulation],
                               [
							    (1.03 - localDisease.zombiePercent - country.deadPercent)
                                * (localDisease.localSeverity / 100.0)
                                * localDisease.zombie
                                * FloatRand(0f, 1f)
                                * country.basePopulationDensity
								]
								)
                                * (FloatRand(0f, 1f) * disease.zombieConversionMod + FloatRand(0f, 1f));

      localDisease.I2Z = fminf(
                               [totalInfected],
                               [
							    (1.05 - localDisease.zombiePercent - country.deadPercent)
                                * (localDisease.localSeverity / 100.0)
                                * localDisease.zombie
                                * FloatRand(0f, 1f)
                                * country.basePopulationDensity
							 ]
							 )
                            * (FloatRand(0f, 1f) * disease.zombieConversionMod + FloatRand(0f, 1f));
    }
  }
  if ( disease.zdayDone )
  {
    ++localDisease.zombieInactivityCounter;
	floatRand_1 = FloatRand(0f, 1f);
    rate2D = fmaxf(0.0, floatRand_1 * (1f - disease.zombieConversionMod));
    rate2Z = fminf(1.0, floatRand_1 * (disease.zombieConversionMod - 1f) + 1);
    expectedH2DZ = fmin(
            [country.healthyPopulation],
            [
			(1.03 - localDisease.zombiePercent - disease.deadPercent)
            * (localDisease.localSeverity / 100.0) 
			* localDisease.zombie
            * FloatRand(0f, 1f)
            * country.basePopulationDensity
			]
			);
    expectedH2Z = rate2Z * expectedH2DZ;
    expectedH2D = rate2D * expectedH2DZ;
    expectedI2DZ = fminf(
            [totalInfected],
            [
			(1.05 - localDisease.zombiePercent - disease.deadPercent)
            * (localDisease.localSeverity / 100.0) 
			* localDisease.zombie
            * FloatRand(0f, 1f)
            * country.basePopulationDensity
			]
			);
    expectedI2D = expectedI2DZ * rate2D;
    expectedI2Z = expectedI2DZ * rate2Z;
    humanStrengthAdvantage = fmaxf(
            0.0,
            disease.humanCombatStrength + country.localHumanCombatStrength - disease.zombieCombatStrength - localDisease.localZombieCombatStrength);
    zombieKilledRaw = country.healthyPopulation 
			* humanStrengthAdvantage 
			* localDisease.zombiePercent 
			* FloatRand(0f, 1f);
    if ( localDisease.zombie < 100 && country.healthyPopulation > 100 )
      zombieKilledRaw = zombieKilledRaw + humanStrengthAdvantage;
    zombieKilled = fmaxf(0.0, zombieKilledRaw);
    zombieDecayEnvironmentalRate = 2.0;
    if ( country.hot )
    {
      zombieDecayEnvironmentalRate = disease.zombieTechMummy <= 0.0 ? 7.0 : 2.5;
      if ( disease.hotDecayFlag )
	  {
        zombieDecayEnvironmentalRate *= 0.5;
	  }
    }
    if ( country.cold )
	{
      zombieDecayEnvironmentalRate -= 1.9;
	}
    if ( country.humid )
	{
      zombieDecayEnvironmentalRate += 1.5;
	}
    if ( country.arid )
	{
      zombieDecayEnvironmentalRate -= 1.2;
	}
    expectedZ2D = localDisease.zombie 
			  * disease.zombieDecay
              * (localDisease.localZombieDecayMultiplier + localDisease.localZombieDecayOverride)
              * fmaxf(0.01f, zombieDecayEnvironmentalRate)
              * disease.zombieDecayTechMultiplier
              * FloatRand(0f, 1f)
			  * disease.globalZombieDecayMultiplier;
    if ( localDisease.zombie <= 0 || expectedI2Z + expectedH2Z > 0.0 || localDisease.zombieInactivityCounter <= 14 )
	{
      localDisease.localZombieDecayMultiplier = 1.0;
	}
    else
	{
      localDisease.localZombieDecayMultiplier = localDisease.localZombieDecayMultiplier * 1.05f + 0.005f;
	}
    localDisease.H2Z = fmaxf(0.0, expectedH2Z) + localDisease.H2Z;
    localDisease.H2D = fmaxf(0.0, expectedH2D) + localDisease.H2D;
    localDisease.I2DAdditional = fmaxf(0.0, expectedI2D);
    localDisease.I2Z = fmaxf(0.0, expectedI2Z) + localDisease.I2Z;

    maxDecayChangePerTurnThisTurn = localDisease.maxDecayChangePerTurn
    localDisease.Z2D = FloatRand(0f, 1f) * localDisease.maxDecayChangePerTurn + localDisease.Z2D;
    if ( expectedZ2D / 1000.0 - localDisease.maxDecayChangePerTurn > localDisease.maxDecayChangePerTurn )
    {
      localDisease.maxDecayChangePerTurn = expectedZ2D / 1000.0 - localDisease.maxDecayChangePerTurn;

    }
    if ( country.totalZombie + country.deadPopulation > country.healthyPopulation + country.totalInfected + 2 && localDisease.maxDecayChangePerTurn < 1.0 )
	{
      localDisease.maxDecayChangePerTurn = localDisease.maxDecayChangePerTurn + 2.0;
	}
    localDisease.Z2D = fmaxf(0.0, expectedZ2D + zombieKilled) + FloatRand(0f, 1f) * maxDecayChangePerTurnThisTurn + localDisease.Z2D;
    if ( country.fortState == 1 )
    {
      if ( country.totalZombie >= 100 )
      {
        if ( country.totalZombie >= 10000 )
        {
          if ( localDisease.Z2D <= localDisease.H2Z + localDisease.I2Z )
          {
            if ( country.zombiePercent + disease.deadPercent <= country.healthyPercent )
              country.battleVictoryCount = country.battleVictoryCount - 0.001;
            else
              country.battleVictoryCount = country.battleVictoryCount - 0.01f;
          }
          else
          {
            country.battleVictoryCount = country.battleVictoryCount + 0.002f;
          }
        }
        else
        {
          country.battleVictoryCount = country.battleVictoryCount + 0.001;
        }
      }
      else
      {
        country.battleVictoryCount = country.localHumanCombatStrength / 50.0 + 0.01f + country.battleVictoryCount;
      }
    }

    if ( FloatRand(0f, 1f) > disease.globalZombiePercent + disease.globalInfectedPercent + disease.globalDeadPercent
      && IntRand(0, 10) < 1
      && localDisease.zombie < 1 )
    {
      country.battleVictoryCount = country.battleVictoryCount + 0.03f;
    }
    a1 = disease.zdayCounter;
    if ( disease.zdayCounter > 100 && disease.zombieDecreaseTurnCount > 50 && disease.evoPoints < 25 && disease.globalZombiePercent < 0.0001 )
    {
      country.battleVictoryCount += 0.1f;
      a1 = disease.zdayCounter;
    }
    if ( disease.zdayCounter > 100
      && localDisease.zombie < 1
      && disease.globalInfectedPercent < 0.001
      && disease.globalZombiePercent < 0.001
      && disease.evoPoints < 30
      && country.healthyPopulation > 10000 )
    {
      country.battleVictoryCount = country.battleVictoryCount + 0.1;
    }
    if ( country.battleVictoryCount < 0.0 )
      country.battleVictoryCount = 0;
  }
  country.localHumanCombatStrength = fmaxf((country.localHumanCombatStrengthMax - country.localHumanCombatStrength) * FloatRand(0f, 0.01f), 0.0001f) + country.localHumanCombatStrength;
  if ( country.totalZombie < 100 )
  {
    country.localHumanCombatStrength += 0.001f;
  }
  if ( country.wealthy )
  {
    country.localHumanCombatStrength += 0.001f;
  }
  if ( country.fortState == 1 )
  {
    country.localHumanCombatStrength += 0.001f;
  }
  if ( country.totalZombie > country.healthyPopulation + country.totalInfected )
  {
    country.localHumanCombatStrength -= 0.003f;
  }
  if ( disease.difficulty == 0 )
  {
   country.localHumanCombatStrength = fminf(country.localHumanCombatStrength, country.localHumanCombatStrengthMax * 0.55f);
  }
  else
  {
	  country.localHumanCombatStrength = fminf(country.localHumanCombatStrength, country.localHumanCombatStrengthMax);
  }
  return country.healthyPopulation + country.totalInfected;
}