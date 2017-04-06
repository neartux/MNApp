using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Models.Ordenes;
using WisenetBackOfficeApp.Services;

namespace WisenetBackOfficeApp.ViewModels
{
    class OrderReportViewModel {
        List<VentaTO> orderList = new List<VentaTO>();
        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();
        public OrderReportViewModel()
        {
            Debug.WriteLine("Entrando a view model");
            ResponseVenta response = Task.Run(() => IWisenetWS.FindOrdersByDistributor(1001)).Result;
            Debug.WriteLine("RESPONSER = " + response.ToString());
            if(response.Success)
            {
                Debug.WriteLine("Entrando a if");
                orderList = response.Ventas;
            }
           
        }

        public List<VentaTO> OrderList { get { return orderList; } }
    }
}
