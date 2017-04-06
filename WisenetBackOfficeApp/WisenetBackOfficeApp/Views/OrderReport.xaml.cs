using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Models.Ordenes;
using WisenetBackOfficeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Views
{

    

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderReport : ContentPage
    {
        public OrderReport()
        {
            InitializeComponent();

            BindingContext = new OrderReportViewModel();
        }
    }
}
