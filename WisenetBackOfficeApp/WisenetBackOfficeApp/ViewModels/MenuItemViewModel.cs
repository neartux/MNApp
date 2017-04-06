using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace WisenetBackOfficeApp.ViewModels
{
    class MenuItemViewModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }

        }

        private void Navigate()
        {

            App.Master.IsPresented = false;
            switch (PageName)
            {
                case "HomePage":
                    App.Navigator.PushAsync(new Pages.HomePage());
                    break;


                case "MainPage":
                    App.Navigator.PopToRootAsync();
                    App.Navigator.PushAsync(new Pages.HomePage());
                    break;

                case "OrderReport":
                    App.Navigator.PushAsync(new Views.OrderReport());
                    break;

                default:
                    break;
            }


        }
    }
}
