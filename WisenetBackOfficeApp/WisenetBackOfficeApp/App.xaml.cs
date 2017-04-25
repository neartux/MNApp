using WisenetBackOfficeApp.Pages;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WisenetBackOfficeApp.Translations;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WisenetBackOfficeApp
{
    public partial class App : Application
    {

        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        public App() {

            InitializeComponent();
            MainPage = new Views.Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
