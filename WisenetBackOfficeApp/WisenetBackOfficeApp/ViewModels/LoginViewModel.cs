using Acr.UserDialogs;
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
    class LoginViewModel : ObservableObject
    {
        User _user = new User();
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();


        public LoginViewModel()
        {
            DoLoginCommand = new Command(() => DoLogin());
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public Command DoLoginCommand { get; }

        private void DoLogin()
        {
           
            Task.Run(() => {
                if(ValidateLoginForm())
                {
                    Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Wait a moment, please"));

                    ResponseDistributor response = IWisenetWS.FindDatosDistribuidorById(long.Parse(_user.UserName), User.Password).Result;

                    if (response.Success)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            var _AppManager = AppManager.Instance;
                            _AppManager.SetDistributor(response.DistributorTO);

                            UserDialogs.Instance.HideLoading();
                            Application.Current.MainPage = new MasterPage();
                            return;
                        });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            UserDialogs.Instance.HideLoading();
                            UserDialogs.Instance.ErrorToast(response.Message);
                            return;
                        });

                    }
                }

                
            });

        }



        private bool ValidateLoginForm()
        {
            int n;
            bool isNumeric = int.TryParse(_user.UserName, out n);
            if (_user.UserName == null || _user.UserName.Trim().Length.Equals(Keys.NUMBER_ZERO) || !isNumeric)
            {
                UserDialogs.Instance.WarnToast(AppResources.LoginValidateMessageUserRequired);
                return false;
            }

            if (_user.Password == null || _user.Password.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                UserDialogs.Instance.WarnToast(AppResources.LoginValidateMessagePasswordRequired);
                return false;
            }
            return true;
        }
    }
}
