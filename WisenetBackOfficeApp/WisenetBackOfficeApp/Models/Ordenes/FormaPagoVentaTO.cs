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

        public override string ToString() {
            return "FormaPagoVentaTO:{ " +
             "\n FormaPago = " + FormaPago +
             "\n NumeroTarjeta = " + NumeroTarjeta +
             "\n FechaVencimiento = " + FechaVencimiento +
             "\n Repetible = " + Repetible +
             "\n NombreTitular = " + NombreTitular +
             "\n Banco = " + Banco +
             "\n Autorizacion = " + Autorizacion +
             "\n Cantidad = " + Cantidad +
             "\n}";
        }
    }
}
