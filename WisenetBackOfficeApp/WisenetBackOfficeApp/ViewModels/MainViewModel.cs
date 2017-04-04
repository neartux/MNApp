using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Utils;
using WisenetBackOfficeApp.Models.Distributor;

namespace WisenetBackOfficeApp.ViewModels {
    class MainViewModel {
        private DistributorTO _Distributor;
        public MainViewModel() {
            LoadMenu();
            LoadMenuDist();

            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();

            if(_Distributor.FechaRegistro > 0)
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

        public DateTime FechaRegistro { get; set; }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_launcher",
                Title = "Inicio",
                PageName = "HomePage"

            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_genealogia",
                Title = "Genealogia",
                PageName = "HomePage"

            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_sesion",
                Title = "Cerrar",
                PageName = "HomePage"

            });

        }





        private void LoadMenuDist()
        {
            Debug.WriteLine("Entrando a menu");

            MenuDist = new ObservableCollection<MenuItemDataDistributorViewModel>();
            MenuDist.Add(new MenuItemDataDistributorViewModel()
            {
                Title_d = "Datos Personales",
                Icon_d = "ic_account_circle",
                PageName_d = "PersonalDataDistributor"
            });

            MenuDist.Add(new MenuItemDataDistributorViewModel()
            {
                Title_d = "Datos Facturación",
                Icon_d = "ic_document_a",
                PageName_d = "PersonalDataDistributor"
            });

            MenuDist.Add(new MenuItemDataDistributorViewModel()
            {
                Title_d = "Datos Envío",
                Icon_d = "ic_send",
                PageName_d = "PersonalDataDistributor"
            });


        }
    }
}
