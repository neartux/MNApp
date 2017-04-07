using Newtonsoft.Json;
using WisenetBackOfficeApp.Models.Common;

namespace WisenetBackOfficeApp.Models.Ordenes {
    class ResponseVentaDetalle : ResponseTO {

        [JsonProperty(PropertyName = "object")]
        public ReporteVentaTO ReporteVenta { get; set; }
    }
}
