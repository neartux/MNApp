using Newtonsoft.Json;
using System;

namespace WisenetBackOfficeApp.Models.Ordenes {
    class FormaEnvioTO {

        [JsonProperty(PropertyName = "tipoFormaEnvio")]
        public string TipoFormaEnvio { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "direccion")]
        public string Direccion { get; set; }

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
        public DateTime FechaOrden { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty(PropertyName = "receptor")]
        public string Receptor { get; set; }

        [JsonProperty(PropertyName = "commentReceptor")]
        public string ComentariosReceptor { get; set; }

        public override string ToString()
        {
            return "FormaEnvioTO:{ " +
             "\n TipoFormaEnvio = " + TipoFormaEnvio +
             "\n Nombre = " + Nombre +
             "\n Direccion = " + Direccion +
             "\n NombreEnvio = " + NombreEnvio +
             "\n DireccionEnvio = " + DireccionEnvio +
             "\n Inventario = " + Inventario +
             "\n Pais = " + Pais +
             "\n Usuario = " + Usuario +
             "\n FechaOrden = " + FechaOrden +
             "\n Descripcion = " + Descripcion +
             "\n Receptor = " + Receptor +
             "\n ComentariosReceptor = " + ComentariosReceptor +
             "\n}";
        }

    }
}
