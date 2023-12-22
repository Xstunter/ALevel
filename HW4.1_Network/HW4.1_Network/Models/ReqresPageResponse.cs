using Newtonsoft.Json;
using System.Collections.Generic;

namespace HW4._1_Network.Models
{
    internal class ReqresPageResponse
    {
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage {  get; set; }
        public int Total {  get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        public List<ReqresUserResponse>  Data { get; set; }
        public List<ReqresSupportResponse> Support { get; set; }
    }
}
