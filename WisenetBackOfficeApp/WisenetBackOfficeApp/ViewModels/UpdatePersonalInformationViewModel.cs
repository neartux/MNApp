using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Utils;
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Services;
using WisenetBackOfficeApp.Translations;
using WisenetBackOfficeApp.Views;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels
{
    class UpdatePersonalInformationViewModel : ObservableObject
    {
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();
        private DateTime _birthDate;
        private DistributorTO _Distributor;
        private bool isLoad = true;

        public UpdatePersonalInformationViewModel()
        {
            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();
            _birthDate = DateUtil.UnixDateToDateTime(_Distributor.FechaNacimiento);
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set {
                SetProperty(ref _birthDate, value);
                if (isLoad)
                {
                    isLoad = false;
                } else
                {
                    UpdateBirthDate();
                }
            }
        }

        public DistributorTO Distributor
        {
            get { return _Distributor; }
            set { _Distributor = value; }
        }

        private void UpdateBirthDate()
        {
            Debug.WriteLine("Entrando a metodo BirthDate: "+ _birthDate);
            if (BirthDate != null)
            {
                ResponseTO response = Task.Run(() => IWisenetWS.UpdateBirthDateDistributor(_Distributor.IdDistributor, String.Format("{0:MM/dd/yyyy}", BirthDate))).Result;

                if (response.Success)
                {
                    _birthDate = new DateTime(_birthDate.Year, _birthDate.Month, _birthDate.Day, _birthDate.Hour, _birthDate.Minute, _birthDate.Second, DateTimeKind.Local);
                    //Application.Current.MainPage.DisplayAlert(AppResources.LabelInfo, AppResources.PersonalDataDistributorBirthDateUpdated, AppResources.ButtonLabelOk);                    
                    AppManager.Instance.GetDistributor().FechaNacimiento = DateUtil.DateTimeToUnixDate(_birthDate);
                    App.Navigator.PushAsync(new PersonalDataDistributor());

                }
                else
                {
                    Application.Current.MainPage.DisplayAlert(AppResources.LabelWarning, response.Message, AppResources.ButtonLabelOk);
                }

            }
            else
            {
                Application.Current.MainPage.DisplayAlert(AppResources.LabelWarning, AppResources.PersonalDataDistributorBirthDateRequired, AppResources.ButtonLabelOk);
            }

        }
    }
}
