// Original function: SeaTransfer(__int64 a1, __int64 a2, __int64 a3, __int64 a4)
_BOOL8 __fastcall SeaTransfer(__int64 d, __int64 ld, __int64 source, __int64 td)
{
  double v8; 
  float v9; 
  int v10; 
  int v11; 
  __int64 v12; 
  int v13; 
  bool v14; 
  double v15; 
  int v16; 
  int v17; 

  if ( d.diseaseType == 8 )
  {
    v8 = FloatRand();
    v9 = *(float *)&v8;
    v10 = IntRand(0LL, 100LL);
    v11 = IntRand(0LL, 100LL);
    v12 = ld._controlledInfected + ld.uncontrolledInfected;
    if ( v10 < 1 )
    {
      v13 = 5000;
      return ((((((v12 / source.originalPopulation) * 100.0)
                                           * d.globalSeaRate)
                                   * d.seaTransmission)
                           * v9)
                   * v13) >= fmax(10.0 - td.localInfectiousness / 10.0, 1.0)
          || d.diseaseType == 8 && ld.infectedPercent > 0.99989998;
    }
    v13 = 1;
    v14 = v11 < 1;
  }
  else
  {
    v15 = FloatRand();
    v9 = *(float *)&v15;
    v16 = IntRand(0LL, 100LL);
    v17 = IntRand(0LL, 100LL);
    v12 = ld._controlledInfected + ld.uncontrolledInfected;
    if ( v16 < 1 )
    {
      v13 = 5000;
      return ((((((v12 / source.originalPopulation) * 100.0)
                                           * d.globalSeaRate)
                                   * d.seaTransmission)
                           * v9)
                   * v13) >= fmax(10.0 - td.localInfectiousness / 10.0, 1.0)
          || d.diseaseType == 8 && ld.infectedPercent > 0.99989998;
    }
    v13 = 1;
    v14 = v17 < 5;
  }
  if ( v14 )
    v13 = 100;
  return ((((((v12 / source.originalPopulation) * 100.0)
                                       * d.globalSeaRate)
                               * d.seaTransmission)
                       * v9)
               * v13) >= fmax(10.0 - td.localInfectiousness / 10.0, 1.0)
      || d.diseaseType == 8 && ld.infectedPercent > 0.99989998;
}
