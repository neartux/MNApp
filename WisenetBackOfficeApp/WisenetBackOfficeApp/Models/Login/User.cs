using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisenetBackOfficeApp.Models.Login
{
    class User
    {
        public int IdUsurio { get; set; }
        public int? UserName { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
    }
}
