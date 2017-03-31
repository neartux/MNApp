using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisenetBackOfficeApp.ViewModels
{
    class MainViewModel
    {
        public MainViewModel()
        {
            LoadMenu();
            LoadMenuDist();

        }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<MenuItemDataDistributorViewModel> MenuDist { get; set; }

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
