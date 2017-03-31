using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisenetBackOfficeApp.Infrastructure
{
    class InstanceLocatorMenuDist
    {
        public InstanceLocatorMenuDist()
        {
            MenuDist = new ViewModels.MainViewModel();
        }

        public ViewModels.MainViewModel MenuDist { get; set; }
    }
}
