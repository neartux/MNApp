using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Models.Distributor;

namespace WisenetBackOfficeApp.Helpers
{
    public class AppManager
    {
        private static volatile AppManager _instance;
        private static object _lockObject = new object();
        private static DistributorTO _Distributor;

        private AppManager()
        {
            _Distributor = new DistributorTO();
        }

        public void SetDistributor(DistributorTO Distributor)
        {
            Debug.WriteLine(".... = "+ Distributor.ToString());
            _Distributor = Distributor;
        }

        public DistributorTO GetDistributor()
        {
            return _Distributor;
        }

        public static AppManager Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (_lockObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new AppManager();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
