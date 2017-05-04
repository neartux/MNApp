using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Checks;
using WisenetBackOfficeApp.Services;

namespace WisenetBackOfficeApp.ViewModels
{
    class ChecksViewModel
    {

        private static readonly IWisenetWebServices IWisenetWS = new WisenetWebServices();

        private List<ChequeTO> _Checks;

        public ChecksViewModel()
        {
            var _AppManager = AppManager.Instance;
            var _DistributorTO = _AppManager.GetDistributor();
            ResponseCheque response = Task.Run(() => IWisenetWS.FindChecksByDistributor(_DistributorTO.IdDistributor, Keys.COMISION_TYPE_ALL)).Result;
            Debug.WriteLine("RESPUESTA CHEQUE = " +response.Success);
            if (response.Success)
            {
                Debug.WriteLine("---------------");
                CheckList = response.Checks;
            }
        }

        public List<ChequeTO> CheckList
        {
            get
            {
                return _Checks;
            }
            set
            {
                _Checks = value;
            }
        }
    }
}
