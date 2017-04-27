using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Views;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels
{
    class ShippingDataDistributorViewModel {

        private DistributorTO _Distributor;     

        public ShippingDataDistributorViewModel()
        {
            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();

            UpdateShippingInformationCommand = new Command(() => DisplayUpdateShippingInformation());
        }

        public Command UpdateShippingInformationCommand { get; }

        private void DisplayUpdateShippingInformation()
        {
            App.Navigator.PushAsync(new UpdateShippingInformation());
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
                if(_Distributor.CelularEnvio.Length > Keys.NUMBER_ZERO) {
                    _Ubicaciones = _Distributor.CelularEnvio;
                }
                if(_Distributor.TelefonoEnvio.Length > Keys.NUMBER_ZERO) {
                    _Ubicaciones += Keys.SLASH + _Distributor.TelefonoEnvio;
                }
                if(_Distributor.FaxEnvio.Length > Keys.NUMBER_ZERO) {
                    _Ubicaciones += Keys.SLASH + _Distributor.FaxEnvio;
                }
                return _Ubicaciones;
            }
        }
    }
}
