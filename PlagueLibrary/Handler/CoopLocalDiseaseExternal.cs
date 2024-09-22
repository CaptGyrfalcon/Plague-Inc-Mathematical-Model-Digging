public static void LocalDiseaseTest(CoopLocalDiseaseData d);
public static void LocalDiseaseUpdate(CoopLocalDiseaseData ld, CoopCountryData c, CoopDiseaseData d);
public static void LocalDiseaseUpdateSecond(CoopLocalDiseaseData ld, CoopCountryData c, CoopDiseaseData d);
public static bool SeaTransfer(CoopDiseaseData d, CoopLocalDiseaseData ld, CoopCountryData source, CoopLocalDiseaseData td, CoopCountryData destination);
public static bool AirTransfer(CoopDiseaseData d, CoopLocalDiseaseData ld, CoopCountryData source, CoopLocalDiseaseData td, CoopCountryData destination);
public static bool LandTransfer(CoopDiseaseData d, CoopLocalDiseaseData ld, CoopCountryData source, CoopLocalDiseaseData td, CoopCountryData destination, int landRoutesMult);