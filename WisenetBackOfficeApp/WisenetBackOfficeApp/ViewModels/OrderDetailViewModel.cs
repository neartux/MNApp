using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Services;
using WisenetBackOfficeApp.Models.Ordenes;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.ViewModels
{
    class OrderDetailViewModel {

        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();
        private ReporteVentaTO _ReporteVentaTO = new ReporteVentaTO();

        public OrderDetailViewModel(long _IdVenta) {
            Debug.WriteLine("ID DE ORDEN = " + _IdVenta);
            ResponseVentaDetalle response = Task.Run(() => IWisenetWS.FindVentaById(_IdVenta)).Result;
            Debug.WriteLine("Aqui termino de peticion");
            if (response.Success) {
                _ReporteVentaTO = response.ReporteVenta;
            } else {
                Application.Current.MainPage.DisplayAlert("Info", response.Message, "Aceptar");
            }
            Debug.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Debug.WriteLine("ReporteVentaTO = "+_ReporteVentaTO.ToString());
            Debug.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }

        public ReporteVentaTO ReporteVentaTO {
            get { return _ReporteVentaTO; }
            set { _ReporteVentaTO = value; }
        }
    }
}
