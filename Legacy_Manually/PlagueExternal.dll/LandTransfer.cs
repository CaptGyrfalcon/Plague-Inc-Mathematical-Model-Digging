_BOOL8 __fastcall LandTransfer(SPDiseaseData disease, SPLocalDiseaseData sourceLocalDisease, SPCountryData sourceCountry, SPLocalDiseaseData destinationLocalDisease, SPCountryData destinationCountry, int landRoutesMult)
{
  long totalInfected; // rbx
  float borderOpenValue; // xmm7_4
  double FloatRand(0, 1); // xmm0_8
  bool v11; // cc
  int youRLucky; // eax
  float landTransmissionPower; // xmm8_4
  int v14; // eax

  totalInfected = destinationLocalDisease.controlledInfected + destinationLocalDisease.uncontrolledInfected;
  borderOpenValue = sourceLocalDisease.borderStatusValue * destinationLocalDisease.borderStatusValue;
  youRLucky = 1;
  if (IntRand(0l, 100l) < 1)
    youRLucky = 1000;
  landTransmissionPower = (float)totalInfected * 100.0 / (float)destinationCountry.originalPopulation
                                      * disease.globalLandRate
                              * disease.landTransmission
                      * borderOpenValue
              * FloatRand(0, 1)
      * (float)youRLucky;
  return landTransmissionPower >= fmaxf(13.0 - sourceLocalDisease.localInfectiousness, 1.0) && landRoutesMult > IntRand(0, 10);
