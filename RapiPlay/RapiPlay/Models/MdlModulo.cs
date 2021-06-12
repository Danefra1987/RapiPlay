namespace RapiPlay.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class MdlModulo : MdlBase
    {
        public MdlModulo()
        {
        }
    }

    [JsonObject]
    public class ListaModulo : MdlRespuestaBase
    {
        public ListaModulo()
        {
        }

        [JsonProperty("modulo")]
        public List<MdlModulo> modulo { get; set; }
    }
}
