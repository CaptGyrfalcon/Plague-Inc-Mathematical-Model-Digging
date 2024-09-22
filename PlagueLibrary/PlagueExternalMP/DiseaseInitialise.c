// Original function: DiseaseInitialise(__int64 a1)
void __fastcall DiseaseInitialise(__int64 d)
{
  int v2; 
  double v3; 
  __m128d v4; 
  double v5; 
  __m128d v6; 
  __m128d v7; 
  __m128d v8; 
  double v9; 
  double v10; 
  __m128d v11; 
  __m128d v12; 
  __m128d v13; 
  double v14; 
  __m128d v15; 
  void *v16; 
  void *v17; 
  double v18; 
  double v19; 
  double v20; 

  v2 = d.difficulty;
  d.geneticDriftMax = 0x3FF0000000000000LL;
  if ( v2 )
  {
    switch ( v2 )
    {
      case 1:
        v9 = d.globalInfectiousnessMax + 1.0;
        ++d.aaCostModifier;
        d.infectedPointsPot = 0x4037000000000000LL;
        d.difficultyVariable = 0x4010000000000000LL;
        d.globalInfectiousnessMax = v9;
        break;
      case 2:
        v10 = d.globalInfectiousnessMax;
        v11 = _mm_sub_pd(*(__m128d *)d.wealthy, (__m128d)xmmword_18001DA50);
        d.infectedPointsPot = 0x4034000000000000LL;
        d.difficultyVariable = 0x4024000000000000LL;
        *(__m128d *)d.wealthy = v11;
        v12 = *(__m128d *)d.urban;
        d.globalInfectiousnessMax = v10 + 1.0;
        *(__m128d *)d.urban = _mm_sub_pd(v12, (__m128d)xmmword_18001DA30);
        *(__m128d *)d.hot = _mm_sub_pd(*(__m128d *)d.hot, (__m128d)xmmword_18001DA20);
        *(__m128d *)d.humid = _mm_sub_pd(*(__m128d *)d.humid, (__m128d)xmmword_18001DA30);
        d.cureRequirementBase = d.cureRequirementBase - d.cureRequirementBase * 0.239999994635582;
        break;
      case 3:
        v13 = *(__m128d *)d.wealthy;
        d.geneticDrift = 0x3FF0000000000000LL;
        v14 = d.globalInfectiousnessMax;
        d.infectedPointsPot = 0x4033000000000000LL;
        d.difficultyVariable = 0x402C000000000000LL;
        *(__m128d *)d.wealthy = _mm_sub_pd(v13, (__m128d)xmmword_18001DA60);
        v15 = *(__m128d *)d.urban;
        d.globalInfectiousnessMax = v14 + 1.0;
        *(__m128d *)d.urban = _mm_sub_pd(v15, (__m128d)xmmword_18001DA30);
        *(__m128d *)d.hot = _mm_sub_pd(*(__m128d *)d.hot, (__m128d)xmmword_18001DA20);
        *(__m128d *)d.humid = _mm_sub_pd(*(__m128d *)d.humid, (__m128d)xmmword_18001DA30);
        d.cureRequirementBase = d.cureRequirementBase - d.cureRequirementBase * 0.239999994635582;
        break;
      default:
        v16 = operator new(0x100uLL);
        sub_1800011F0(v16, );
        if ( Debug )
          Debug(v16);
        break;
    }
  }
  else
  {
    v3 = d.globalInfectiousnessMax + 5.0;
    v4 = *(__m128d *)d.wealthy;
    d.aaCostModifier += 3;
    d.infectedPointsPot = 0x403B000000000000LL;
    d.difficultyVariable = 0x3FF0000000000000LL;
    d.globalInfectiousnessMax = v3;
    v5 = d.cureRequirementBase * 0.2899999916553497;
    *(__m128d *)d.wealthy = _mm_add_pd(v4, (__m128d)xmmword_18001DA40);
    v6 = _mm_add_pd(*(__m128d *)d.urban, (__m128d)xmmword_18001DA20);
    d.cureRequirementBase = v5 + d.cureRequirementBase;
    v7 = *(__m128d *)d.landTransmission;
    *(__m128d *)d.urban = v6;
    v8 = _mm_add_pd(*(__m128d *)d.hot, (__m128d)xmmword_18001DA70);
    *(__m128d *)d.landTransmission = _mm_add_pd(v7, (__m128d)xmmword_18001DA90);
    *(__m128d *)d.hot = v8;
    *(__m128d *)d.humid = _mm_add_pd(*(__m128d *)d.humid, (__m128d)xmmword_18001DA20);
    d.airTransmission = d.airTransmission + 1.0;
  }
  v17 = operator new(0x100uLL);
  sub_1800011F0(v17, );
  if ( Debug )
    Debug(v17);
  v18 = d.cureRequirementBase * d.cureRequirementBaseMultipler;
  d.symptomDevolveCost = 5;
  v19 = d.infectedPointsPotChange + d.infectedPointsPot;
  d.transmissionDevolveCost = 5;
  v20 = v18 + d.cureRequirementBase;
  d.abilityDevolveCost = 5;
  d.symptomDevolveCostIncrease = 1;
  d.infectedPointsPot = v19;
  d.transmissionDevolveCostIncrease = 1;
  d.cureRequirementBase = v20;
  d.abilityDevolveCostIncrease = 1;
}
