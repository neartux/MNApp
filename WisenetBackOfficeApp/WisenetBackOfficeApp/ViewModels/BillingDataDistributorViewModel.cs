using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Distributor;

namespace WisenetBackOfficeApp.ViewModels
{
    class BillingDataDistributorViewModel
    {
        private DistributorTO _Distributor;
        public BillingDataDistributorViewModel()
        {
            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();
        }

        public DistributorTO Distributor
        {
            get { return _Distributor; }
            set { _Distributor = value; }
        }

        public string EstadoPais
        {
            get { return _Distributor.Estado + Keys.DASH + _Distributor.Pais; }
        }

        public string Telefonos
        {
            get
            {
                var _Ubicaciones = "";
                if (_Distributor.Celular.Length > Keys.NUMBER_ZERO)
                {
                    _Ubicaciones = _Distributor.Celular;
                }
                if (_Distributor.Telefono.Length > Keys.NUMBER_ZERO)
                {
                    _Ubicaciones += Keys.SLASH + _Distributor.Telefono;
                }
                if (_Distributor.Fax.Length > Keys.NUMBER_ZERO)
                {
                    _Ubicaciones += Keys.SLASH + _Distributor.Fax;
                }
                return _Ubicaciones;
            }
        }
    }
}
