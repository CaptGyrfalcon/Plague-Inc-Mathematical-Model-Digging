// Original function: GetGeneticDriftCost(__int64 a1, int a2)
__int64 __fastcall GetGeneticDriftCost(__int64 d, int cost)
{
  float v2; 

  if ( d.geneticDrift <= 0.0 )
    return (unsigned int)cost;
  v2 = d.globalInfectedPercent + d.globalZombiePercent;
  if ( d.diseaseType == 9 )
    v2 = d.globalInfectedPercent + d.apeTotalInfectedPercent;
  return (unsigned int)floorf((((v2 * v2) + 1.0) * cost) * d.geneticDriftMax);
}
