using WisenetBackOfficeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Views.Checks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChecksReport : TabbedPage
    {
        public ChecksReport()
        {
            InitializeComponent();

            BindingContext = new ChecksViewModel();
        }
    }
}
