using Newtonsoft.Json;

namespace WisenetBackOfficeApp.Models.Ordenes {
    class FormaPagoVentaTO {

        [JsonProperty(PropertyName = "formapago")]
        public string FormaPago { get; set; }

        [JsonProperty(PropertyName = "numeroTarjeta")]
        public string NumeroTarjeta { get; set; }

        [JsonProperty(PropertyName = "fechaVencimiento")]
        public string FechaVencimiento { get; set; }

        [JsonProperty(PropertyName = "repetible")]
        public bool Repetible { get; set; }

        [JsonProperty(PropertyName = "nombreTitular")]
        public string NombreTitular { get; set; }

        [JsonProperty(PropertyName = "banco")]
        public string Banco { get; set; }

        [JsonProperty(PropertyName = "autorizacion")]
        public string Autorizacion { get; set; }

        [JsonProperty(PropertyName = "cantidad")]
        public double Cantidad { get; set; }
    }
}
