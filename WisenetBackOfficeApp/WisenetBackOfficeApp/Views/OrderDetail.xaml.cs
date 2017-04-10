using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetail : TabbedPage
    {
        public OrderDetail(long _IdVenta) {
            InitializeComponent();
        }
    }
}
