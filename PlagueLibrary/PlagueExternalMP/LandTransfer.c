// Original function: LandTransfer(__int64 a1, __int64 a2, __int64 a3, __int64 a4, __int64 a5, int a6)
_BOOL8 __fastcall LandTransfer(__int64 d, __int64 ld, __int64 source, __int64 td, __int64 destination, int landRoutesMult)
{
  __int64 v7; 
  double v9; 
  double v10; 
  bool v11; 
  int v12; 
  double v13; 
  int v14; 

  v7 = td._controlledInfected + td.uncontrolledInfected;
  v9 = ld.borderStatusValue * td.borderStatusValue;
  v10 = qword_180021C90(d);
  v11 = (int)qword_180021C88(0LL, 100LL) < 1;
  v12 = 1;
  if ( v11 )
    v12 = 1000;
  v13 = (float)((float)((float)(int)v7 * 100.0) / (float)(int)destination.originalPopulation)
      * d.globalLandRate
      * d.landTransmission
      * v9
      * v10
      * (double)v12;
  v14 = qword_180021C88(0LL, 10LL);
  return v13 >= fmax(13.0 - ld.localInfectiousness, 1.0) && landRoutesMult > v14;
}
