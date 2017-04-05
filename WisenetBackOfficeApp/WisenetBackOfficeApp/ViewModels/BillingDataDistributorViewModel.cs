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
                return _Distributor.Celular + Keys.SLASH + _Distributor.Telefono + Keys.SLASH + _Distributor.Fax;
            }
        }
    }
}
