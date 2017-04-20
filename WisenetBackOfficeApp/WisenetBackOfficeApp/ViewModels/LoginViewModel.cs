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
        bool _isLoading = false;
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();


        public LoginViewModel() {
            DoLoginCommand = new Command(() => DoLogin());
        }

        public User User {
            get { return _user; }
            set { _user = value; }
        }

        public bool IsLoading {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public Command DoLoginCommand { get; }

        private void DoLogin() {
            _isLoading = true;

            if (ValidateLoginForm()) {
                ResponseDistributor response = Task.Run(() => IWisenetWS.FindDatosDistribuidorById(long.Parse(_user.UserName), User.Password)).Result;
                if (response.Success) {

                    var _AppManager = AppManager.Instance;
                    _AppManager.SetDistributor(response.DistributorTO);

                    Application.Current.MainPage = new MasterPage();
                }
                else {
                    Application.Current.MainPage.DisplayAlert(AppResources.LabelWarning, response.Message, AppResources.ButtonLabelOk);
                }
            }

            _isLoading = false;
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
