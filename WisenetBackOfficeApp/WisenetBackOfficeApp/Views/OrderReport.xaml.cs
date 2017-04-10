using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Models.Ordenes;
using WisenetBackOfficeApp.Services;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.Views {

    public partial class OrderReport : ContentPage {

        
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();

        public OrderReport() {
            InitializeComponent();

            BindingContext = new VentaTO();

            var _AppManager = AppManager.Instance;
            DistributorTO _Distributor = _AppManager.GetDistributor();
            ResponseVenta response = Task.Run(() => IWisenetWS.FindOrdersByDistributor(_Distributor.IdDistributor)).Result;

            OrderList.ItemsSource = response.Ventas;

        }
    }
}
