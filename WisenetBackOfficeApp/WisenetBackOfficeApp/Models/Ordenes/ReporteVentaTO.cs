using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WisenetBackOfficeApp.Models.Ordenes {
    class ReporteVentaTO {

        [JsonProperty(PropertyName = "inventario")]
        public string Inventario { get; set; }

        [JsonProperty(PropertyName = "pais")]
        public string Pais { get; set; }

        [JsonProperty(PropertyName = "idVenta")]
        public int IdVenta { get; set; }

        [JsonProperty(PropertyName = "idDistribuidor")]
        public long IdDistribuidor { get; set; }

        [JsonProperty(PropertyName = "nameDistribuidor")]
        public string NombreDistribuidor { get; set; }

        [JsonProperty(PropertyName = "fechaComision")]
        public DateTime FechaComision { get; set; }

        [JsonProperty(PropertyName = "fastart")]
        public bool? FastStart { get; set; }

        [JsonProperty(PropertyName = "tipoOrden")]
        public string TipoOrden { get; set; }

        [JsonProperty(PropertyName = "comentarios")]
        public string Comentarios { get; set; }

        [JsonProperty(PropertyName = "volumen")]
        public double Volumen { get; set; }

        [JsonProperty(PropertyName = "subTotal")]
        public double SubTotal { get; set; }

        [JsonProperty(PropertyName = "envio")]
        public double GastoEnvio { get; set; }

        [JsonProperty(PropertyName = "impuesto")]
        public double Impuesto { get; set; }

        [JsonProperty(PropertyName = "total")]
        public double Total { get; set; }

        [JsonProperty(PropertyName = "ventadetalleTOs")]
        public List<VentaDetalleTO> VentaDetalleList { get; set; }

        [JsonProperty(PropertyName = "formaPagoVentaTOs")]
        public List<FormaPagoVentaTO> FormaPagoVentaList { get; set; }

        [JsonProperty(PropertyName = "formaenvioTO")]
        public FormaEnvioTO FormaEnvioTO { get; set; }

        [JsonProperty(PropertyName = "datosEnvioDetalleTOs")]
        public List<DatosEnvioDetalleTO> DatosEnvioDetalleList { get; set; }
    }
}
