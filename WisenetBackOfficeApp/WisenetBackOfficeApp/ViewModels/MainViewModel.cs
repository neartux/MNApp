using System;
using System.Collections.ObjectModel;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Utils;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Translations;

namespace WisenetBackOfficeApp.ViewModels {
    class MainViewModel {
        private DistributorTO _Distributor;
        public MainViewModel() {
            LoadMenu();
            LoadMenuDist();

            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();

            if (_Distributor.FechaRegistro > 0)
            {
                FechaRegistro = DateUtil.UnixDateToDateTime(_Distributor.FechaRegistro);   
            }
        }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<MenuItemDataDistributorViewModel> MenuDist { get; set; }
        public DistributorTO Distributor
        {
            get { return _Distributor; }
            set { _Distributor = value; }
        }

        public String prueba { get; set; }
        public DateTime FechaRegistro { get; set; }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_launcher",
                Title = AppResources.MenuLabelHomePage,
                PageName = "HomePage"

            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_genealogia",
                Title = AppResources.MenuLabelOrders,
                PageName = "OrderReport"

            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_genealogia",
                Title = AppResources.MenuLabelGenealogy,
                PageName = "HomePage"

            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_sesion",
                Title = AppResources.MenuLabelClose,
                PageName = "CloseApp"

            });

        }


        private void LoadMenuDist() {

            MenuDist = new ObservableCollection<MenuItemDataDistributorViewModel>();
            MenuDist.Add(new MenuItemDataDistributorViewModel()
            {
                Title_d = AppResources.MenuLabelPersonalData,
                Icon_d = "ic_account_circle",
                PageName_d = "PersonalDataDistributor"
            });

            MenuDist.Add(new MenuItemDataDistributorViewModel()
            {
                Title_d = AppResources.MenuLabelBillingData,
                Icon_d = "ic_document_a",
                PageName_d = "BillingDataDistributor"
            });

            MenuDist.Add(new MenuItemDataDistributorViewModel()
            {
                Title_d = AppResources.MenuLabelShippingData,
                Icon_d = "ic_send",
                PageName_d = "ShippingDataDistributor"
            });


        }
    }
}
