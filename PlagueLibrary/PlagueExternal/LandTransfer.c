// Original function: LandTransfer(__int64 a1, __int64 a2, __int64 a3, __int64 a4, __int64 a5, int a6)
_BOOL8 __fastcall LandTransfer(__int64 d, __int64 ld, __int64 source, __int64 td, __int64 destination, int landRoutesMult)
{
  __int64 v7; 
  float v9; 
  double v10; 
  bool v11; 
  int v12; 
  float v13; 
  int v14; 

  v7 = td._controlledInfected + td.uncontrolledInfected;
  v9 = ld.borderStatusValue * td.borderStatusValue;
  v10 = FloatRand();
  v11 = IntRand(0LL, 100LL) < 1;
  v12 = 1;
  if ( v11 )
    v12 = 1000;
  v13 = ((((((v7 * 100.0) / destination.originalPopulation)
                                      * d.globalLandRate)
                              * d.landTransmission)
                      * v9)
              * *(float *)&v10)
      * v12;
  v14 = IntRand(0LL, 10LL);
  return v13 >= fmaxf(13.0 - ld.localInfectiousness, 1.0) && landRoutesMult > v14;
}
