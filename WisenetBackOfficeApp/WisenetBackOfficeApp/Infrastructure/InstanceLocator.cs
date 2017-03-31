using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisenetBackOfficeApp.Infrastructure
{
    class InstanceLocator
    {
        public InstanceLocator()
        {
            Main = new ViewModels.MainViewModel();


        }

        public ViewModels.MainViewModel Main { get; set; }
    }

    
}
