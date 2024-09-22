public static void LocalDiseaseTest(MPLocalDiseaseData d);
public static void LocalDiseaseUpdate(MPLocalDiseaseData ld, MPCountryData c, MPDiseaseData d);
public static void LocalDiseaseUpdateSecond(MPLocalDiseaseData ld, MPCountryData c, MPDiseaseData d);
public static bool SeaTransfer(MPDiseaseData d, MPLocalDiseaseData ld, MPCountryData source, MPLocalDiseaseData td, MPCountryData destination);
public static bool AirTransfer(MPDiseaseData d, MPLocalDiseaseData ld, MPCountryData source, MPLocalDiseaseData td, MPCountryData destination);
public static bool LandTransfer(MPDiseaseData d, MPLocalDiseaseData ld, MPCountryData source, MPLocalDiseaseData td, MPCountryData destination, int landRoutesMult);