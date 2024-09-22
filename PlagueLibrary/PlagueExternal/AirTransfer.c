// Original function: AirTransfer(__int64 a1, __int64 a2, __int64 a3, __int64 a4)
_BOOL8 __fastcall AirTransfer(__int64 d, __int64 ld, __int64 source, __int64 td)
{
  double v8; 
  int v9; 
  int v10; 
  int v11; 
  float v12; 
  double v13; 
  float v14; 
  float v15; 

  if ( d.diseaseType == 8 )
  {
    v8 = FloatRand();
    v9 = IntRand(0LL, 100LL);
    v10 = IntRand(0LL, 100LL);
    if ( v9 >= 1 )
    {
      v11 = 1;
      if ( v10 < 1 )
        v11 = 100;
    }
    else
    {
      v11 = 5000;
    }
    v12 = (((((ld._controlledInfected + ld.uncontrolledInfected)
                                        / source.originalPopulation)
                                * 100.0)
                        * d.globalAirRate)
                * d.airTransmission)
        * *(float *)&v8;
  }
  else
  {
    v13 = FloatRand();
    v14 = IntRand(0LL, 100LL);
    v15 = IntRand(0LL, 100LL);
    if ( v14 >= 1.0 )
    {
      v11 = 1;
      if ( v15 < 5.0 )
        v11 = 100;
    }
    else
    {
      v11 = 5000;
    }
    v12 = (((((ld._controlledInfected + ld.uncontrolledInfected)
                                        / source.originalPopulation)
                                * 100.0)
                        * d.globalAirRate)
                * d.airTransmission)
        * *(float *)&v13;
  }
  return (v12 * v11) >= fmax(12.0 - td.localInfectiousness / 10.0, 1.0)
      || d.diseaseType == 8 && ld.infectedPercent > 0.99989998;
}
