using System;
using Newtonsoft.Json;

namespace WisenetBackOfficeApp.Models.Distributor
{
    class ResponseDistributor : DistributorTO
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "message")]
        public String Message { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "object")]
        public DistributorTO DistributorTO { get; set; }

        public override string ToString()
        {
            return "ResponseVO: { \n Id = " + Id + " \n Message = " + Message + " \n Success = " + Success + " \n DistributorTO = " + DistributorTO + " }";
        }
    }
}
