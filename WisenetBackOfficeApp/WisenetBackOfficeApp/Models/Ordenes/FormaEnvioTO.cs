using Newtonsoft.Json;

namespace WisenetBackOfficeApp.Models.Ordenes {
    class FormaEnvioTO {

        [JsonProperty(PropertyName = "tipoFormaEnvio")]
        public string TipoFormaEnvio { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "direccion")]
        public string Direccion;

        [JsonProperty(PropertyName = "nombreEnvio")]
        public string NombreEnvio { get; set; }

        [JsonProperty(PropertyName = "direccionEnvio")]
        public string DireccionEnvio { get; set; }

        [JsonProperty(PropertyName = "inventario")]
        public string Inventario { get; set; }

        [JsonProperty(PropertyName = "pais")]
        public string Pais { get; set; }

        [JsonProperty(PropertyName = "usuario")]
        public string Usuario { get; set; }

        [JsonProperty(PropertyName = "fechaOrden")]
        public string FechaOrden;

        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty(PropertyName = "receptor")]
        public string Receptor { get; set; }

        [JsonProperty(PropertyName = "commentReceptor")]
        public string ComentariosReceptor { get; set; }

    }
}
