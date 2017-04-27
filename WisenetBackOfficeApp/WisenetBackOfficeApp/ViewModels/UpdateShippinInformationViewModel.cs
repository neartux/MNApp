using System.Diagnostics;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Services;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels
{
    class UpdateShippinInformationViewModel : ObservableObject
    {
        private DistributorTO _Distributor;
        private int _idCountry;
        private int _idState;
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();

        public UpdateShippinInformationViewModel()
        {
            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();

            Countries = new ObservableRangeCollection<CatalogoTO>(Task.Run(() => IWisenetWS.FindUbicaciones(WebServicesKeys.URL_FIND_COUNTRIES)).Result);

            States = new ObservableRangeCollection<CatalogoTO>();

            Cities = new ObservableRangeCollection<CatalogoTO>();

            ConfigureUbicacionesDistributor((int)_Distributor.IdPaisEnvio, (int)_Distributor.IdEstadoEnvio, _Distributor.IdCiudadEnvio);

            UpdateDataCommand = new Command(() => UpdateData());
        }

        public ObservableRangeCollection<CatalogoTO> Countries { get; set; }

        public ObservableRangeCollection<CatalogoTO> States { get; set; }

        public ObservableRangeCollection<CatalogoTO> Cities { get; set; }

        public DistributorTO Distributor
        {
            get { return _Distributor; }
            set { _Distributor = value; }
        }

        public Command UpdateDataCommand { get; }

        public int IdCountry
        {
            get { return _idCountry; }
            set { _idCountry = value; SetProperty(ref _idCountry, value); FindStatesByCountry(_idCountry); }
        }

        public int IdState
        {
            get { return _idState; }
            set { _idState = value; SetProperty(ref _idState, value); FindCitiesByState(_idState); }
        }

        private void FindStatesByCountry(long idCountry)
        {
            // Valida el id del pais y busca los estados
            if (idCountry > Keys.NUMBER_ZERO)
            {
                Cities.Clear();
                States.Clear();
                States.AddRange(Task.Run(() => IWisenetWS.FindUbicaciones(WebServicesKeys.URL_FIND_STATES_BY_COUNTRY + IdCountry)).Result);
            }
        }

        private void FindCitiesByState(long idState)
        {
            // Valida el id estado y busca las ciudades
            if (idState > Keys.NUMBER_ZERO)
            {
                Cities.Clear();
                Cities.AddRange(Task.Run(() => IWisenetWS.FindUbicaciones(WebServicesKeys.URL_FIND_CITIES_BY_STATE + IdState)).Result);
            }

        }

        private void ConfigureUbicacionesDistributor(int idPais, int idEstado, long idCiudad)
        {
            IdCountry = idPais;
            IdState = idEstado;
            //_Distributor.IdCiudadEnvio = idCiudad;
        }

        private void UpdateData()
        {
            if (validateShippingInformation())
            {
                Debug.WriteLine("La informacion del distribuidor es valida");
                ResponseTO response = Task.Run(() => IWisenetWS.UpdateShippingInformation(_Distributor)).Result;
                Debug.WriteLine("LINEA DE RESPUESTA EN OBJECT = ", response.ToString());
                if (response.Success)
                {
                    Application.Current.MainPage.DisplayAlert("Success", "Se ha actualizado la informacion", "Aceptar");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                }
            }

        }

        private bool validateShippingInformation()
        { // TODO este metodo debe ser sustituido mas adelante por los validadores, Behaviors Validators de Xamarin Forms, para darle una mejor presentacion
            if (_Distributor.Direccion == null || _Distributor.Direccion.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "La direccion es requerida", "Aceptar");
                return false;
            }

            if (_Distributor.CodigoPostal == null || _Distributor.CodigoPostal.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "El codigo postal es requerido", "Aceptar");
                return false;
            }

            if (_Distributor.IdCiudadEnvio <= 0)
            {
                Application.Current.MainPage.DisplayAlert("Info", "Seleccione una ciudad", "Aceptar");
                return false;
            }

            if (_Distributor.Email == null || _Distributor.Email.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "El email es requerido", "Aceptar");
                return false;
            }

            return true;
        }
    }
}
