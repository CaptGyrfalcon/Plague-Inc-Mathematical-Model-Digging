_BOOL8 __fastcall AirTransfer(Disease disease, LocalDisease localDisease, Country country, LocalDisease destDisease)
{
  double FloatRand(0f, 1f); // xmm0_8
  int IntRand(0, 100); // ebx
  int IntRand(0, 100); // edx
  int youRLucky; // eax
  float airTransferPower; // xmm1_4
  double FloatRand(0f, 1f); // xmm0_8
  float IntRand(0, 100); // xmm6_4
  float IntRand(0, 100); // xmm1_4

  if (disease.DiseaseType == Disease.EDiseaseType.Necroa)
  {
    case(chance)
	{
		1/101 : youRLucky = 5000; break;
		100/10201 : youRLucky = 100; break;
		10000/10201 : youRLucky = 1; break;
		default : youRLucky = 1; break;
	}
    airTransferPower = (localDisease.controlledInfected + localDisease.uncontrolledInfected)
                                        / country.originalPopulation
                                * 100.0
                        * disease.globalAirRate
                * disease.airTransmission
        * FloatRand(0f, 1f);
  }
  else
  {
    case(chance)
	{
		1/101 : youRLucky = 5000; break;
		500/10201 : youRLucky = 100; break;
		9600/10201 : youRLucky = 1; break;
		default : youRLucky = 1; break;
	}
    airTransferPower = (localDisease.controlledInfected + localDisease.uncontrolledInfected)
                                        / country.originalPopulation
                                * 100.0
                        * disease.globalAirRate
                * disease.airTransmission
        * FloatRand(0f, 1f);
  }
  return ((airTransferPower * youRLucky) >= fmax(12.0 - destDisease.localInfectiousness / 10.0, 1.0))
      || (disease.DiseaseType == Disease.EDiseaseType.Necroa && localDisease.infectedPercent > 0.9999f);
}