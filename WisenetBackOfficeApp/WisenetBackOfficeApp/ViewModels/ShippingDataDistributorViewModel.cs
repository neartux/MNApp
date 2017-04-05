using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Distributor;

namespace WisenetBackOfficeApp.ViewModels
{
    class ShippingDataDistributorViewModel {

        private DistributorTO _Distributor;     

        public ShippingDataDistributorViewModel()
        {
            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();
        }
    
        public DistributorTO Distributor
        {
            get { return _Distributor; }
            set { _Distributor = value; }
        }

        public string PaisEstado
        {
            get
            {
                return _Distributor.EstadoEnvio + Keys.DASH + _Distributor.PaisEnvio;
            }
        }

        public string Ubicaciones
        {
            get
            {
                return _Distributor.Celular + Keys.SLASH + _Distributor.Telefono + Keys.SLASH + _Distributor.Fax;
            }
        }
    }
}
