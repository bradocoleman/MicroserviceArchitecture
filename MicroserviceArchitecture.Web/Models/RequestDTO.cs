using MicroserviceArchitecture.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using static MicroserviceArchitecture.Web.Utility.SD;


namespace MicroserviceArchitecture.Web.Models
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

        public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
