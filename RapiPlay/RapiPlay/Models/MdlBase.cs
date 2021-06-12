namespace RapiPlay.Models
{
    using Newtonsoft.Json;

    [JsonObject]
    public class MdlBase
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        [JsonProperty("nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string nombre { get; set; }
        [JsonProperty("imagen", NullValueHandling = NullValueHandling.Ignore)]
        public string imagen { get; set; }
        [JsonProperty("estado", NullValueHandling = NullValueHandling.Ignore)]
        public string estado { get; set; }
    }
}
