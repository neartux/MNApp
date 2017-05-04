using Newtonsoft.Json;
using System;

namespace WisenetBackOfficeApp.Models.Checks
{
    public class ChequeTO {

        public ChequeTO()
        {
                
        }

        [JsonProperty(PropertyName = "idDistribuidor")]
        public long IdDistributor { get; set; }

        [JsonProperty(PropertyName = "nombreDistribuidor")]
        public string NombreDistribuidor { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        public DateTime FechaCheque { get; set; }

        [JsonProperty(PropertyName = "fechaCierreComisiones")]
        public DateTime FechaCierreComision { get; set; }

        [JsonProperty(PropertyName = "monto")]
        public double Monto { get; set; }

        [JsonProperty(PropertyName = "idComisiones")]
        public long IdComision { get; set; }

        [JsonProperty(PropertyName = "idComisionesFast")]
        public long IdComisionFast { get; set; }

        [JsonProperty(PropertyName = "tipoComision")]
        public string TipoComision { get; set; }
    }
}
