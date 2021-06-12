namespace RapiPlay.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class MdlCategoria : MdlBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MdlCategoria(){}
    }

    [JsonObject]
    public class ListaCategoria: MdlRespuestaBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ListaCategoria(){}

        [JsonProperty("categoria")]
        public List<MdlCategoria> categoria { get; set; }
    }
}
