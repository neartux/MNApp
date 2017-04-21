using System.Diagnostics;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Models.Distributor;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage {

        private DistributorTO _Distributor;
        public MenuPage()
        {
            InitializeComponent();

            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();
            
            DistributorName.Text = _Distributor.NombreCompleto;
            PackageDistributor.Text = _Distributor.Calificacion;

        }
    }
}
