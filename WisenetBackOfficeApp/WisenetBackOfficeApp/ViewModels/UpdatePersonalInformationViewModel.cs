using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Services;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels
{
    class UpdatePersonalInformationViewModel : ObservableObject
    {
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();
        private DateTime _birthDate;

        public UpdatePersonalInformationViewModel()
        {
            _birthDate = DateTime.Now;
            UpdateBirthDateCommand = new Command(() => UpdateBirthDate());
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { SetProperty(ref _birthDate, value); }
        }


        public Command UpdateBirthDateCommand { get; }

        private void UpdateBirthDate()
        {
            Debug.WriteLine("Entrando a metodo");
            if (BirthDate != null)
            {
                Debug.WriteLine("FECHA FORMATEADA = " + String.Format("{0:MM/dd/yyyy}", BirthDate));
                ResponseTO response = Task.Run(() => IWisenetWS.UpdateBirthDateDistributor(1001, String.Format("{0:MM/dd/yyyy}", BirthDate))).Result;

                if (response.Success)
                {
                    Application.Current.MainPage.DisplayAlert("Success", "Se ha actualizado la fecha de nacimiento", "Aceptar");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                }

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Info", "Selecciona una fecha", "Aceptar");
            }

        }
    }
}
