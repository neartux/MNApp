using WisenetBackOfficeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetail : TabbedPage {
        public OrderDetail(long _IdVenta) {

            InitializeComponent();

            BindingContext = new OrderDetailViewModel(_IdVenta);
        }
    }
}
