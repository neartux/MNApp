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
                var _Ubicaciones = "";
                if(_Distributor.Celular.Length > Keys.NUMBER_ZERO) {
                    _Ubicaciones = _Distributor.Celular;
                }
                if(_Distributor.Telefono.Length > Keys.NUMBER_ZERO) {
                    _Ubicaciones += Keys.SLASH + _Distributor.Telefono;
                }
                if(_Distributor.Fax.Length > Keys.NUMBER_ZERO) {
                    _Ubicaciones += Keys.SLASH + _Distributor.Fax;
                }
                return _Ubicaciones;
            }
        }
    }
}
