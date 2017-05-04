namespace WisenetBackOfficeApp.Helpers.Keys
{
    class WebServicesKeys {

        public static string URL_HOST_WEB_SERVICE = "http://192.168.100.108:8080/webservicesTest/";
        public static string URL_VALIDATE_DISTRIBUTOR_AND_FIND_INFORMATION = URL_HOST_WEB_SERVICE + "distribuidor/validateDistributorAndFindInformation/";
        public static string URL_UPDATE_SHIPPING_INFORMATION = URL_HOST_WEB_SERVICE + "distribuidor/updateShippingInformationDistributor";
        public static string URL_UPDATE_PERSONAL_INFORMATION = URL_HOST_WEB_SERVICE + "distribuidor/updatePersonalInformationDistributor";
        public static string URL_FIND_COUNTRIES = URL_HOST_WEB_SERVICE + "distribuidor/findCountries";
        public static string URL_FIND_STATES_BY_COUNTRY = URL_HOST_WEB_SERVICE + "distribuidor/findStatesByCountry/";
        public static string URL_FIND_CITIES_BY_STATE = URL_HOST_WEB_SERVICE + "distribuidor/findCitiesByState/";
        public static string URL_UPDATE_BIRTH_DATE = URL_HOST_WEB_SERVICE + "distribuidor/updateBirthDay";
        public static string URL_FIND_ORDERS_BY_DISTRIBUTOR = URL_HOST_WEB_SERVICE + "distribuidor/findOrderListByDistributor/";
        public static string URL_FIND_ORDER_BY_ID = URL_HOST_WEB_SERVICE + "distribuidor/findVentaCompletaById/";
        public static string URL_FIND_ALL_CHECKS = URL_HOST_WEB_SERVICE + "distribuidor/findChecksByDistributor/";
    }
}
