using Newtonsoft.Json;
using System.Collections.Generic;
using WisenetBackOfficeApp.Models.Common;

namespace WisenetBackOfficeApp.Models.Ordenes
{
    class ResponseVenta : ResponseTO
    {
        [JsonProperty(PropertyName = "object")]
        public List<VentaTO> Ventas { get; set; }

        public override string ToString() {
            return "ResponseVO: { \n Ventas = " + Ventas + " \n " + " }";
        }
    }
}
