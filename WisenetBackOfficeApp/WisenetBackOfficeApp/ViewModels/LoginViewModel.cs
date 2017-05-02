using Acr.UserDialogs;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Models.Login;
using WisenetBackOfficeApp.Pages;
using WisenetBackOfficeApp.Services;
using WisenetBackOfficeApp.Translations;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels
{
    class LoginViewModel : ObservableObject {
        User _user = new User();
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();


        public LoginViewModel() {
            DoLoginCommand = new Command(() => DoLogin());
        }

        public User User {
            get { return _user; }
            set { _user = value; }
        }

        public Command DoLoginCommand { get; }

        private async Task  DoLogin() {
            if (ValidateLoginForm()) {
                Debug.WriteLine("1");
                //UserDialogs.Instance.ShowLoading();
                Debug.WriteLine("2");


                ResponseDistributor response = Task.Run(() => IWisenetWS.FindDatosDistribuidorById(long.Parse(_user.UserName), User.Password)).Result;
                Debug.WriteLine("3");
                if (response.Success) {
                    Debug.WriteLine("4");
                    var _AppManager = AppManager.Instance;
                    _AppManager.SetDistributor(response.DistributorTO);
                    Debug.WriteLine("5");
                    Application.Current.MainPage = new MasterPage();
                    Debug.WriteLine("6");
                }
                else {
                    Debug.WriteLine("7");
                    await Application.Current.MainPage.DisplayAlert(AppResources.LabelWarning, response.Message, AppResources.ButtonLabelOk);
                }
                Debug.WriteLine("8");
            }
            Debug.WriteLine("9");

        }



        private bool ValidateLoginForm() {
            int n;
            bool isNumeric = int.TryParse(_user.UserName, out n);
            if (_user.UserName == null || _user.UserName.Trim().Length.Equals(Keys.NUMBER_ZERO) || !isNumeric) {
                Application.Current.MainPage.DisplayAlert(AppResources.LabelInfo, AppResources.LoginValidateMessageUserRequired, AppResources.ButtonLabelOk);
                return false;
            }

            if (_user.Password == null || _user.Password.Trim().Length.Equals(Keys.NUMBER_ZERO)) {
                Application.Current.MainPage.DisplayAlert(AppResources.LabelInfo, AppResources.LoginValidateMessagePasswordRequired, AppResources.ButtonLabelOk);
                return false;
            }
            return true;
        }
    }
}
