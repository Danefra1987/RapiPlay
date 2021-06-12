namespace RapiPlay.Models
{
    using Newtonsoft.Json;

    [JsonObject]
    public class MdlRespuestaBase
    {
        [JsonProperty("mensaje")]
        public string mensaje { get; set; }
        [JsonProperty("codigoError")]
        public int codigoError { get; set; }
    }
}
