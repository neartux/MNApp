using Newtonsoft.Json;

namespace WisenetBackOfficeApp.Models.Distributor
{
    public class DistributorTO
    {
        [JsonProperty(PropertyName = "idDistribuidor")]
        public long IdDistributor { get; set; }

        [JsonProperty(PropertyName = "nombres")]
        public string Nombres { get; set; }

        [JsonProperty(PropertyName = "apellidos")]
        public string Apellidos { get; set; }

        [JsonProperty(PropertyName = "nombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonProperty(PropertyName = "patrocinador")]
        public string Patrocinador { get; set; }

        [JsonProperty(PropertyName = "nombrecompania")]
        public string NombreCompania { get; set; }

        [JsonProperty(PropertyName = "nombrePaquete")]
        public string NombrePaquete { get; set; }

        [JsonProperty(PropertyName = "fechaRegistro")]
        public long FechaRegistro { get; set; } 

        [JsonProperty(PropertyName = "fechaNacimiento")]
        public long FechaNacimiento { get; set; }

        [JsonProperty(PropertyName = "calificacion")]
        public string Calificacion { get; set; }

        [JsonProperty(PropertyName = "direccion")]
        public string Direccion { get; set; }

        [JsonProperty(PropertyName = "codigoPostal")]
        public string CodigoPostal { get; set; }

        [JsonProperty(PropertyName = "idPais")]
        public long IdPais { get; set; }

        [JsonProperty(PropertyName = "pais")]
        public string Pais { get; set; }

        [JsonProperty(PropertyName = "idEstado")]
        public long IdEstado { get; set; }

        [JsonProperty(PropertyName = "estado")]
        public string Estado { get; set; }

        [JsonProperty(PropertyName = "idCiudad")]
        public int IdCiudad { get; set; }

        [JsonProperty(PropertyName = "ciudad")]
        public string Ciudad { get; set; }

        [JsonProperty(PropertyName = "telefono")]
        public string Telefono { get; set; }

        [JsonProperty(PropertyName = "celular")]
        public string Celular { get; set; }

        [JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        // Propiedades para datos de envio
        [JsonProperty(PropertyName = "nombreEnvio")]
        public string NombresEnvio { get; set; }

        [JsonProperty(PropertyName = "apellidosEnvio")]
        public string ApellidosEnvio { get; set; }

        [JsonProperty(PropertyName = "direccionEnvio")]
        public string DireccionEnvio { get; set; }

        [JsonProperty(PropertyName = "idPaisEnvio")]
        public long IdPaisEnvio { get; set; }

        [JsonProperty(PropertyName = "paisEnvio")]
        public string PaisEnvio { get; set; }

        [JsonProperty(PropertyName = "idEstadoEnvio")]
        public long IdEstadoEnvio { get; set; }

        [JsonProperty(PropertyName = "idCiudadEnvio")]
        public long IdCiudadEnvio { get; set; }

        [JsonProperty(PropertyName = "estadoEnvio")]
        public string EstadoEnvio { get; set; }

        [JsonProperty(PropertyName = "ciudadEnvio")]
        public string CiudadEnvio { get; set; }

        [JsonProperty(PropertyName = "codigoPostalEnvio")]
        public string CodigoPostalEnvio { get; set; }

        [JsonProperty(PropertyName = "telefonoEnvio")]
        public string TelefonoEnvio { get; set; }

        [JsonProperty(PropertyName = "celularEnvio")]
        public string CelularEnvio { get; set; }

        [JsonProperty(PropertyName = "faxEnvio")]
        public string FaxEnvio { get; set; }

        [JsonProperty(PropertyName = "emailEnvio")]
        public string EmailEnvio { get; set; }


        public override string ToString()
        {
            return "DistribuidorTO:{ " +
                "\n IdDistributor = " + IdDistributor +
                "\n Nombres = " + Nombres +
                "\n Apellidos =  " + Apellidos +
                "\n Direccion =  " + Direccion +
                "\n CodigoPostal =  " + CodigoPostal +
                "\n IdPais =  " + IdPais +
                "\n IdEstado =  " + IdEstado +
                "\n IdCiudad =  " + IdCiudad +
                "\n Telefono =  " + Telefono +
                "\n Celular =  " + Celular +
                "\n Fax =  " + Fax +
                "\n Email = " + Email +
                "\n Calificacion = " + Calificacion +
                "\n Patrocinador = " + Patrocinador +
                "\n FechaRegistro = " + FechaRegistro +
                "}";
        }
    }
}
