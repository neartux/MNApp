using System;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Utils;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Views;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels {
    class PersonalDataDistributorViewModel {

        private DistributorTO _Distributor;
        public PersonalDataDistributorViewModel()
        {
            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();

            FechaNacimiento = DateUtil.UnixDateToDateTime(_Distributor.FechaNacimiento);

            FechaInscripcion = DateUtil.UnixDateToDateTime(_Distributor.FechaRegistro);

            UpdateBirthDateCommand = new Command(() => DisplayUpdateBirthDate());
        }

        public DistributorTO Distributor
        {
            get { return _Distributor; }
            set { _Distributor = value; }
        }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaInscripcion { get; set; }

        public Command UpdateBirthDateCommand { get; }

        private void DisplayUpdateBirthDate()
        {
            App.Navigator.PushAsync(new UpdatePersonalInformation());
        }
    }
}
