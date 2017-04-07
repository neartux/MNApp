using Newtonsoft.Json;

namespace WisenetBackOfficeApp.Models.Ordenes {
    class VentaDetalleTO {

        [JsonProperty(PropertyName = "clave")]
        public string Clave { get; set; }

        [JsonProperty(PropertyName = "producto")]
        public string Producto { get; set; }

        [JsonProperty(PropertyName = "atributoProducto")]
        public string AtributoProducto { get; set; }

        [JsonProperty(PropertyName = "puntos")]
        public double Puntos { get; set; }

        [JsonProperty(PropertyName = "cantidad")]
        public double Cantidad { get; set; }

        [JsonProperty(PropertyName = "precio")]
        public double Precio { get; set; }

        [JsonProperty(PropertyName = "total")]
        public double Total { get; set; }

        public override string ToString() {
            return "VentaDetalleTO:{ " +
             "\n Clave = " + Clave +
             "\n Producto = " + Producto +
             "\n AtributoProducto = " + AtributoProducto +
             "\n Puntos = " + Puntos +
             "\n Cantidad = " + Cantidad +
             "\n Precio = " + Precio +
             "\n Total = " + Total +
             "\n}";
        }
    
    }
}
