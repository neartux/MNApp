namespace WisenetBackOfficeApp.Helpers.Keys
{
    class WebServicesKeys
    {
        public static string URL_HOST_WEB_SERVICE = "http://192.168.100.106:8080/webservicesTest/";
        public static string URL_VALIDATE_DISTRIBUTOR_AND_FIND_INFORMATION = URL_HOST_WEB_SERVICE + "distribuidor/validateDistributorAndFindInformation/";
        public static string URL_UPDATE_SHIPPING_INFORMATION = URL_HOST_WEB_SERVICE + "distribuidor/updateShippingInformationDistributor";
        public static string URL_FIND_COUNTRIES = URL_HOST_WEB_SERVICE + "distribuidor/findCountries";
        public static string URL_FIND_STATES_BY_COUNTRY = URL_HOST_WEB_SERVICE + "distribuidor/findStatesByCountry/";
        public static string URL_FIND_CITIES_BY_STATE = URL_HOST_WEB_SERVICE + "distribuidor/findCitiesByState/";
        public static string URL_UPDATE_BIRTH_DATE = URL_HOST_WEB_SERVICE + "distribuidor/updateBirthDay";
    }
}
