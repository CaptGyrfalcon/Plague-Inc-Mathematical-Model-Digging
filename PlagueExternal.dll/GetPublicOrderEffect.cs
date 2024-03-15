float __fastcall GetPublicOrderEffect(SPLocalDiseaseData localDisease)
{
  return (((localDisease.infectedPercent + localDisease.infectedPercent) / (localDisease.infectedPercent + 0.5))
               * (localDisease.localSeverity / 135.0))
       * (localDisease.localSeverity / 135.0);
}