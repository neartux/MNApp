using System.Collections.Generic;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Models.Ordenes;
using WisenetBackOfficeApp.Services;

namespace WisenetBackOfficeApp.ViewModels
{
    class OrderReportViewModel {

        List<VentaTO> orderList = new List<VentaTO>();

        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();

        public OrderReportViewModel() {

            var _AppManager = AppManager.Instance;
            DistributorTO _Distributor = _AppManager.GetDistributor();

            ResponseVenta response = Task.Run(() => IWisenetWS.FindOrdersByDistributor(_Distributor.IdDistributor)).Result;
            
            if(response.Success) {
                orderList = response.Ventas;
            }
        }

        public List<VentaTO> OrderList { get { return orderList; } }
    }
}
