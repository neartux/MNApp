using WisenetBackOfficeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillingDataDistributor : ContentPage
    {
        public BillingDataDistributor()
        {
            InitializeComponent();

            BindingContext = new BillingDataDistributorViewModel();
        }
    }
}
