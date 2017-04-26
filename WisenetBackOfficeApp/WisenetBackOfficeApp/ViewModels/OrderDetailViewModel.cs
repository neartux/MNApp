using System.Diagnostics;
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
            ResponseVentaDetalle response = Task.Run(() => IWisenetWS.FindVentaById(_IdVenta)).Result;
            if (response.Success) {
                _ReporteVentaTO = response.ReporteVenta;
            }
            else {
                Application.Current.MainPage.DisplayAlert("Info", response.Message, "Aceptar");
            }
            
        }

        public ReporteVentaTO ReporteVentaTO {
            get { return _ReporteVentaTO; }
            set { _ReporteVentaTO = value; }
        }

        public int GetTotalFormaPago {
            get
            {
                return _ReporteVentaTO.FormaPagoVentaList.Count;
            }
        }
    }
}
