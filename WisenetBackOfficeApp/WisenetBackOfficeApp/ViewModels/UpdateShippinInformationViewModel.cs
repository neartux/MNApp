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
        private DistributorTO _distribuidorTO = new DistributorTO();
        private int _idCountry;
        private int _idState;
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();

        public UpdateShippinInformationViewModel()
        {
            _distribuidorTO.IdDistributor = 1001;
            _distribuidorTO.Direccion = "C. 17 # 106 x 14 y 22";
            _distribuidorTO.CodigoPostal = "97380";
            _distribuidorTO.Telefono = "9993599516";
            _distribuidorTO.Celular = "9993599516";
            _distribuidorTO.Fax = "fax@faxito.com";
            _distribuidorTO.Email = "near@hotmail.com";

            Countries = new ObservableRangeCollection<CatalogoTO>(Task.Run(() => IWisenetWS.FindUbicaciones(WebServicesKeys.URL_FIND_COUNTRIES)).Result);

            States = new ObservableRangeCollection<CatalogoTO>();

            Cities = new ObservableRangeCollection<CatalogoTO>();

            ConfigureUbicacionesDistributor(4, 189, 230419);

            UpdateDataCommand = new Command(() => UpdateData());
        }

        public ObservableRangeCollection<CatalogoTO> Countries { get; set; }

        public ObservableRangeCollection<CatalogoTO> States { get; set; }

        public ObservableRangeCollection<CatalogoTO> Cities { get; set; }

        public DistributorTO DistributorTO
        {
            get { return _distribuidorTO; }
            set
            {
                _distribuidorTO = value; SetProperty(ref _distribuidorTO, value);
            }
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

        private void FindStatesByCountry(int idCountry)
        {
            // Valida el id del pais y busca los estados
            if (idCountry > Keys.NUMBER_ZERO)
            {
                Cities.Clear();
                States.Clear();
                States.AddRange(Task.Run(() => IWisenetWS.FindUbicaciones(WebServicesKeys.URL_FIND_STATES_BY_COUNTRY + IdCountry)).Result);
            }
        }

        private void FindCitiesByState(int idState)
        {
            // Valida el id estado y busca las ciudades
            if (idState > Keys.NUMBER_ZERO)
            {
                Cities.Clear();
                Cities.AddRange(Task.Run(() => IWisenetWS.FindUbicaciones(WebServicesKeys.URL_FIND_CITIES_BY_STATE + IdState)).Result);
            }

        }

        private void ConfigureUbicacionesDistributor(int idPais, int idEstado, int idCiudad)
        {
            IdCountry = idPais;
            IdState = idEstado;
            _distribuidorTO.IdCiudad = idCiudad;
        }

        private void UpdateData()
        {
            if (validateShippingInformation())
            {
                Debug.WriteLine("La informacion del distribuidor es valida");
                ResponseTO response = Task.Run(() => IWisenetWS.UpdateShippingInformation(DistributorTO)).Result;
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
            if (_distribuidorTO.Direccion == null || _distribuidorTO.Direccion.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "La direccion es requerida", "Aceptar");
                return false;
            }

            if (_distribuidorTO.CodigoPostal == null || _distribuidorTO.CodigoPostal.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "El codigo postal es requerido", "Aceptar");
                return false;
            }

            if (_distribuidorTO.IdCiudad <= 0)
            {
                Application.Current.MainPage.DisplayAlert("Info", "Seleccione una ciudad", "Aceptar");
                return false;
            }

            if (_distribuidorTO.Email == null || _distribuidorTO.Email.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "El email es requerido", "Aceptar");
                return false;
            }

            return true;
        }
    }
}
