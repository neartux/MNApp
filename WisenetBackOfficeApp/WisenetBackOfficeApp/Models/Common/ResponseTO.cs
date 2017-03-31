using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisenetBackOfficeApp.Models.Common
{
    class ResponseTO
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        public override string ToString()
        {
            return "ResponseVO: { \n Id = " + Id + " \n Message = " + Message + " \n Success = " + Success + " }";
        }
    }
}
