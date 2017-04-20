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
        public App()
        {

            //System.Diagnostics.Debug.WriteLine("====== resource debug info =========");
            //var assembly = typeof(App).GetTypeInfo().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //    System.Diagnostics.Debug.WriteLine("found resource: " + res);
            //System.Diagnostics.Debug.WriteLine("====================================");

            // This lookup NOT required for Windows platforms - the Culture will be automatically set
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                // determine the correct, supported .NET culture
                //var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                //AppResources.Culture = ci; // set the RESX for resource localization
                //DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }


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
