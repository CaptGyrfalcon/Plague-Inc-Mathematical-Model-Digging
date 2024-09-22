// Original function: ZombieTransfer(__int64 a1, __int64 a2, __int64 a3, __int64 a4, __int64 a5)
_BOOL8 __fastcall ZombieTransfer(__int64 d, __int64 ld, __int64 source, __int64 td, __int64 destination)
{
  float v8; 
  double v9; 
  bool v10; 
  int v11; 

  v8 = ld.borderStatusValue * td.borderStatusValue;
  v9 = FloatRand();
  v10 = IntRand(0LL, 100LL) < 1;
  v11 = 1;
  if ( v10 )
    v11 = 1000;
  return (((((((td.zombie * 100.0)
                                                       / destination.originalPopulation)
                                               * d.globalLandRate)
                                       * d.landTransmission)
                               * v8)
                       * *(float *)&v9)
               * v11) >= fmaxf(13.0 - ld.localSeverity, 1.0);
}
