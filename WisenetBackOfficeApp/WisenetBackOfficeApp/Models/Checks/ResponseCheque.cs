using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Models.Common;

namespace WisenetBackOfficeApp.Models.Checks
{
    class ResponseCheque : ResponseTO
    {
        [JsonProperty(PropertyName = "object")]
        public List<ChequeTO> Checks { get; set; }
    }
}
