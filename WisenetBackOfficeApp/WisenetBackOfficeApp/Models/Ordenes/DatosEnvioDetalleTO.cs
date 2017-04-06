using Newtonsoft.Json;

namespace WisenetBackOfficeApp.Models.Ordenes {
    class DatosEnvioDetalleTO {

        [JsonProperty(PropertyName="caja")]
        public string Caja { get; set; }

        [JsonProperty(PropertyName ="abreviatura")]
        public string Abreviatura { get; set; }

        [JsonProperty(PropertyName = "numeroRastro")]
        public string NumeroRastreo { get; set; }

        [JsonProperty(PropertyName = "comentarios")]
        public string Comentarios { get; set; }
    }
}
