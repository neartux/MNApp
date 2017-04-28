using WisenetBackOfficeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateBillingInformation : ContentPage
    {
        public UpdateBillingInformation()
        {
            InitializeComponent();

            BindingContext = new UpdateBillingInformationViewModel();
        }
    }
}
