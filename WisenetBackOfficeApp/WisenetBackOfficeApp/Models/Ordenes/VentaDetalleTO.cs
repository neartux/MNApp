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
        public int Cantidad { get; set; }

        [JsonProperty(PropertyName = "precio")]
        public double Precio { get; set; }

        [JsonProperty(PropertyName = "total")]
        public double Total { get; set; }
    }
}
