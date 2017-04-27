using WisenetBackOfficeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePersonalInformation : ContentPage
    {
        public UpdatePersonalInformation()
        {
            InitializeComponent();

            BindingContext = new UpdatePersonalInformationViewModel();
        }
    }
}
