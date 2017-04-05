using Newtonsoft.Json;

namespace WisenetBackOfficeApp.Models.Common
{
    class CatalogoTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }

        public override string ToString() {
            return "CatalogoTO:{ " +
                "\n Id = " + Id +
                "\n Descripcion = " + Descripcion +
                "\n}";
        }
    }
}
