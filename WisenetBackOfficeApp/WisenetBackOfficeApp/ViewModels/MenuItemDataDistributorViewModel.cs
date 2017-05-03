using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using System.Windows.Input;
using WisenetBackOfficeApp.Views;

namespace WisenetBackOfficeApp.ViewModels
{
    class MenuItemDataDistributorViewModel
    {
        public string Title_d { get; set; }
        public string Icon_d { get; set; }
        public string PageName_d { get; set; }

        #region Comandos
        public ICommand GoToCommandPersonalData
        {
            get
            {
                return new RelayCommand(GoToPersoalData);
            }
        }

        private void GoToPersoalData() {
            switch (PageName_d)
            {
                case "PersonalDataDistributor":
                    App.Navigator.PushAsync(new PersonalDataDistributor());
                    break;


                case "BillingDataDistributor":
                    App.Navigator.PushAsync(new BillingDataDistributor());
                    break;


                case "ShippingDataDistributor":
                    App.Navigator.PushAsync(new ShippingDataDistributor());
                    break;


                default:
                    break;
            }
        }

        #endregion
    }
}
