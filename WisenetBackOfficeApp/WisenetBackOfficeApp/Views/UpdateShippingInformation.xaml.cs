using WisenetBackOfficeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateShippingInformation : ContentPage
    {
        public UpdateShippingInformation()
        {
            InitializeComponent();
            BindingContext = new UpdateShippinInformationViewModel();
        }
    }
}
