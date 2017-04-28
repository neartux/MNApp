﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Services;
using WisenetBackOfficeApp.Translations;
using WisenetBackOfficeApp.Views;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels
{
    class UpdateBillingInformationViewModel : ObservableObject
    {
        private DistributorTO _Distributor;
        private int _idState;
        private bool loadCity = false;
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();

        public UpdateBillingInformationViewModel()
        {
            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();

            States = new ObservableRangeCollection<CatalogoTO>(Task.Run(() => IWisenetWS.FindUbicaciones(WebServicesKeys.URL_FIND_STATES_BY_COUNTRY+ _Distributor.IdPais)).Result);

            Cities = new ObservableRangeCollection<CatalogoTO>();

            ConfigureUbicacionesDistributor((int)_Distributor.IdEstado, (int)_Distributor.IdCiudad);

            UpdateDataCommand = new Command(() => UpdateData());
        }

        public ObservableRangeCollection<CatalogoTO> States { get; set; }

        public ObservableRangeCollection<CatalogoTO> Cities { get; set; }

        public DistributorTO Distributor
        {
            get { return _Distributor; }
            set { _Distributor = value; }
        }

        public Command UpdateDataCommand { get; }

        public int IdState
        {
            get { return _idState; }
            set
            {
                _idState = value;
                SetProperty(ref _idState, value);
                if (loadCity)
                {
                    FindCitiesByState(_idState);
                }
                else
                {
                    loadCity = true;
                }
            }
        }

        public int IdCity { get; set; }

      

        private void FindCitiesByState(long idState)
        {
            // Valida el id estado y busca las ciudades
            if (idState > Keys.NUMBER_ZERO)
            {
                Cities.Clear();
                Cities.AddRange(Task.Run(() => IWisenetWS.FindUbicaciones(WebServicesKeys.URL_FIND_CITIES_BY_STATE + IdState)).Result);
            }

        }

        private void ConfigureUbicacionesDistributor(int idEstado, int idCiudad)
        {
            IdState = idEstado;
            IdCity = idCiudad;
        }

        private void UpdateData()
        {
            if (validateShippingInformation())
            {
                Debug.WriteLine("La informacion del distribuidor es valida");
                ConfigureDistributorUpdated();
                ResponseTO response = Task.Run(() => IWisenetWS.UpdateBillingInformation(_Distributor)).Result;
                Debug.WriteLine("LINEA DE RESPUESTA EN OBJECT = ", response.ToString());
                if (response.Success)
                {
                    AppManager.Instance.SetDistributor(_Distributor);
                    App.Navigator.Navigation.RemovePage(App.Navigator.Navigation.NavigationStack[App.Navigator.Navigation.NavigationStack.Count - 1]);
                    App.Navigator.Navigation.RemovePage(App.Navigator.Navigation.NavigationStack[App.Navigator.Navigation.NavigationStack.Count - 1]);
                    App.Navigator.PushAsync(new BillingDataDistributor());
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert(AppResources.LabelWarning, response.Message, AppResources.ButtonLabelOk);
                }
            }
        }

        private void ConfigureDistributorUpdated()
        {
            _Distributor.IdCiudad = IdCity;
            _Distributor.Ciudad = FindDescriptionById(IdCity, new List<CatalogoTO>(Cities));
            _Distributor.Estado = FindDescriptionById(_idState, new List<CatalogoTO>(States));
        }

        private string FindDescriptionById(int _Id, List<CatalogoTO> list)
        {
            string _Description = "";
            foreach (CatalogoTO _CatalogoTO in list)
            {
                if (_CatalogoTO.Id == _Id)
                {
                    _Description = _CatalogoTO.Descripcion;
                    break;
                }
            }
            return _Description;
        }

        private bool validateShippingInformation()
        { // TODO este metodo debe ser sustituido mas adelante por los validadores, Behaviors Validators de Xamarin Forms, para darle una mejor presentacion
            if (_Distributor.Direccion == null || _Distributor.Direccion.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "La direccion es requerida", "Aceptar");
                return false;
            }

            if (_Distributor.CodigoPostal == null || _Distributor.CodigoPostal.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "El codigo postal es requerido", "Aceptar");
                return false;
            }

            if (IdCity <= 0)
            {
                Application.Current.MainPage.DisplayAlert("Info", "Seleccione una ciudad", "Aceptar");
                return false;
            }

            if (_Distributor.Email == null || _Distributor.Email.Trim().Length.Equals(Keys.NUMBER_ZERO))
            {
                Application.Current.MainPage.DisplayAlert("Info", "El email es requerido", "Aceptar");
                return false;
            }

            return true;
        }


    }
}
