// Original function: GetPublicOrderEffect(__int64 a1)
float __fastcall GetPublicOrderEffect(__int64 ld)
{
  return (((ld.infectedPercent + ld.infectedPercent) / (ld.infectedPercent + 0.5))
               * (ld.localSeverity / 135.0))
       * (ld.localSeverity / 135.0);
}
