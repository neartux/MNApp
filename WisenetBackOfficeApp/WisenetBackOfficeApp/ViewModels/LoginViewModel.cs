using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Models.Login;
using WisenetBackOfficeApp.Pages;
using WisenetBackOfficeApp.Services;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels
{
    class LoginViewModel : ObservableObject
    {
        User _user = new User();
        bool _isLoading = false;
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();


        public LoginViewModel()
        {
            DoLoginCommand = new Command(() => DoLogin());
        }

        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public Command DoLoginCommand { get; }

        void DoLogin()
        {
            IsLoading = true;

            if (ValidateLoginForm())
            {
                ResponseDistributor response = Task.Run(() => IWisenetWS.FindDatosDistribuidorById(1001, "demo")).Result;
                Debug.WriteLine("ya obteniendo respuesta = " + response);
                if (response.Success)
                {
                    Debug.WriteLine("se redirecciona a otra pagina");
                    //App.Navigator.PushAsync(new MasterPage());
                    App.Navigator.PushAsync(new MasterPage(), true);
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("error", response.Message, "aceptar");
                }
            }

            IsLoading = false;
        }



        private bool ValidateLoginForm()
        {
            //Debug.WriteLine("USUARIO = " + usuario.UserName + " PASSWORD = " + usuario.Password+ " LENGTH USER = "+ usuario.UserName.Trim().Length);
            if (_user.UserName <= Keys.NUMBER_ZERO)
            {
                Application.Current.MainPage.DisplayAlert("Info", "User name is required", "Aceptar");
                return false;
            }

            if (_user.Password == null || _user.Password.Trim().Length.Equals(0))
            {
                Application.Current.MainPage.DisplayAlert("Info", "Password is required", "Aceptar");
                return false;
            }
            return true;
        }
    }
}
