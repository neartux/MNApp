using WisenetBackOfficeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var sLogo = "logo-45.png";
            NavigationPage.SetTitleIcon(this, sLogo);

            BindingContext = new MainViewModel();
        }
    }
}
