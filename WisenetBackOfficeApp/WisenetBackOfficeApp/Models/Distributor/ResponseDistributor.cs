using System;
using Newtonsoft.Json;
using WisenetBackOfficeApp.Models.Common;

namespace WisenetBackOfficeApp.Models.Distributor
{
    class ResponseDistributor : ResponseTO {

        [JsonProperty(PropertyName = "object")]
        public DistributorTO DistributorTO { get; set; }

        public override string ToString()
        {
            return "ResponseVO: { \n Id = " + Id + " \n Message = " + Message + " \n Success = " + Success + " \n DistributorTO = " + DistributorTO + " }";
        }
    }
}
