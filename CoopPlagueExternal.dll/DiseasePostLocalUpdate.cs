__int64 (__fastcall *__fastcall DiseasePostLocalUpdate(CoopDiseaseData coopDisease, long totalPop, long infectedPop, long deadPop))(_QWORD)
{
  double v4; // xmm2_8
  double v5; // xmm1_8
  double v10; // xmm0_8
  double v11; // xmm7_8
  double v12; // xmm1_8
  int v13; // eax
  double v14; // xmm1_8
  double v15; // xmm0_8
  double v16; // xmm1_8
  double v17; // xmm0_8
  double v18; // xmm8_8
  int v19; // ebx
  __int64 v20; // rdx
  __int64 v21; // rcx
  double v22; // xmm0_8
  double v23; // xmm0_8
  double v24; // xmm0_8
  double v25; // xmm0_8
  __int64 v26; // rax
  double v27; // xmm0_8
  __int64 v28; // rdx
  __int64 v29; // rcx
  double v30; // xmm0_8
  double v31; // xmm10_8
  double v32; // xmm4_8
  double v33; // xmm11_8
  double v34; // xmm3_8
  double v35; // xmm6_8
  void *v36; // rbx
  __int64 v37; // rcx
  double v38; // xmm6_8
  double v39; // xmm9_8
  void *v40; // rbx
  void *v41; // rbx
  void *v42; // rbx
  void *v43; // rbx
  void *v44; // rbx
  __int64 v45; // rcx
  double v46; // xmm6_8
  double v47; // xmm9_8
  void *v48; // rbx
  void *v49; // rbx
  int v50; // eax
  void *v51; // rsi
  __int64 (__fastcall *result)(_QWORD); // rax
  double v53; // xmm0_8
  double v54; // xmm1_8

  v4 = *(double *)(disease.infectedPointsPotAll);
  v5 = fmax(0.0, *(double *)(disease.globalCureResearchThisTurn));
  v10 = v5 + *(double *)(disease.globalCureResearch);
  *(double *)(disease.globalCureResearchThisTurn) = v5;
  v11 = 0.0;
  v12 = v5 * *(double *)(disease.researchInefficiencyMultiplier);
  v13 = 200 - *(_DWORD *)(disease.dnaPointsGained);
  *(double *)(disease.globalCureResearch) = v10;
  v14 = v12 + *(double *)(disease.researchInefficiency);
  v15 = *(double *)(disease.cureBaseMultiplier) * *(double *)(disease.cureRequirementBase) + v14;
  *(double *)(disease.researchInefficiency) = v14;
  *(double *)(disease.cureRequirements) = v15;
  if ( (double)v13 > v4 )
  {
    v16 = (double)(int)*(_QWORD *)(disease.infectedThisTurn) * 0.00000002 * (*(double *)(disease.globalSeverity) / 50.0 + 1.0);
    v17 = v16 + *(double *)(a1 + 176);
    *(double *)(a1 + 176) = v17;
    if ( v17 < 0.0 )
      *(_QWORD *)(a1 + 176) = 0i64;
    *(double *)(disease.infectedPointsPotAll) = v4 + v16;
  }
  v18 = 0.0;
  v19 = qword_180021C88(0i64, 100i64);
  logf((float)(int)*(_QWORD *)(disease.infectedThisTurn));
  v22 = qword_180021C90(v21, v20);
  if ( v19 < 30 )
  {
    if ( v22 >= 0.0 )
      v23 = floor(v22 + 0.5);
    else
      v23 = ceil(v22 - 0.5);
    v18 = fmax(0.0, v23);
  }
  v24 = *(double *)(a1 + 176);
  if ( v24 <= v18 )
  {
    v18 = *(double *)(a1 + 176);
    v25 = 0.0;
  }
  else
  {
    v25 = v24 - v18;
  }
  v26 = *(_QWORD *)(a1 + 888);
  *(double *)(a1 + 176) = v25;
  v27 = (double)(int)v26 * 100.0 / (double)a2;
  if ( v27 >= 0.0 )
    v30 = floor(v27 + 0.5);
  else
    v30 = ceil(v27 - 0.5);
  v31 = v30;
  v32 = (double)a3 / (double)a2;
  v33 = 0.0;
  v34 = (double)a4 / (double)a2;
  if ( fmax(0.1, v32 * v32) <= v34 * v34 )
    v35 = v34 * v34;
  else
    v35 = fmax(0.1, v32 * v32);
  *(double *)(disease.infectedIncomeTurnDNA) = qword_180021C90(v29, v28) * v35;
  v36 = operator new(0x100ui64);
  sub_1800011F0((int)v36, (int)"DISEASE [1] infectedIncomeTurnDNA: %f");
  if ( qword_180021C98 )
    qword_180021C98(v36);
  v38 = *(double *)(disease.infectedIncomeTurnDNA) + *(double *)(disease.incomeRemainder);
  v39 = sub_18000771C(v37);
  *(double *)(disease.infectedIncome) = *(double *)(disease.infectedIncome) + *(double *)(disease.infectedIncomeTurnDNA);
  *(double *)(disease.incomeRemainder) = v38 - v39;
  if ( v39 > 0.0 )
  {
    v40 = operator new(0x100ui64);
    sub_1800011F0((int)v40, (int)"DISEASE INFECTED INCOME: %f");
    if ( qword_180021C98 )
      qword_180021C98(v40);
    v33 = v39;
  }
  v41 = operator new(0x100ui64);
  sub_1800011F0((int)v41, (int)"DISEASE [1] incomeRemainder: %f");
  if ( qword_180021C98 )
    qword_180021C98(v41);
  if ( *(double *)(disease.globalKilledPercent) > 0.0 )
  {
    v42 = operator new(0x100ui64);
    sub_1800011F0((int)v42, (int)"DISEASE corpseIncomeMultiplier: %f");
    if ( qword_180021C98 )
      qword_180021C98(v42);
    *(double *)(disease.corpseIncomeTurnDNA) = (*(double *)(disease.globalKilledPercent) / (*(double *)(disease.globalKilledPercent) + 0.1)
                            + 0.02)
                           * *(double *)(disease.corpseIncomeMultiplier);
    v43 = operator new(0x100ui64);
    sub_1800011F0((int)v43, (int)"DISEASE corpseIncomeTurnDNA: %f");
    if ( qword_180021C98 )
      qword_180021C98(v43);
    v44 = operator new(0x100ui64);
    sub_1800011F0((int)v44, (int)"DISEASE corpseIncome: %f");
    if ( qword_180021C98 )
      qword_180021C98(v44);
    v46 = *(double *)(disease.incomeRemainder) + *(double *)(disease.corpseIncomeTurnDNA);
    v47 = sub_18000771C(v45);
    *(double *)(a1 + 1544) = *(double *)(a1 + 1544) + *(double *)(disease.corpseIncomeTurnDNA);
    *(double *)(disease.incomeRemainder) = v46 - v47;
    if ( v47 > 0.0 )
    {
      v48 = operator new(0x100ui64);
      sub_1800011F0((int)v48, (int)"______DISEASE DEATH DNA GAIN: %f");
      if ( qword_180021C98 )
        qword_180021C98(v48);
      v11 = v47;
    }
  }
  v49 = operator new(0x100ui64);
  sub_1800011F0((int)v49, (int)"DISEASE [2] incomeRemainder: %f");
  if ( qword_180021C98 )
    qword_180021C98(v49);
  *(double *)(a1 + 1616) = v31;
  *(double *)(a1 + 1608) = v18;
  *(double *)(a1 + 1624) = v33;
  *(double *)(a1 + 1632) = v11;
  v50 = (int)(v31 + v18 + v33 + v11);
  *(_DWORD *)(a1 + 4) += v50;
  *(_DWORD *)(a1 + 724) += v50;
  v51 = operator new(0x100ui64);
  sub_1800011F0((int)v51, (int)"//EVO POINTS// Disease %d EVO %d");
  result = qword_180021C98;
  if ( qword_180021C98 )
    result = (__int64 (__fastcall *)(_QWORD))qword_180021C98(v51);
  v53 = *(double *)(disease.cureRequirements);
  v54 = *(double *)(disease.globalCureResearch);
  if ( *(_DWORD *)(a1 + 332) )
  {
    if ( v53 > v54 && !*(_DWORD *)(a1 + 336) )
      *(_DWORD *)(a1 + 332) = 0;
  }
  else if ( v54 >= v53 || *(_DWORD *)(a1 + 336) )
  {
    *(_DWORD *)(a1 + 332) = 1;
  }
  return result;
}