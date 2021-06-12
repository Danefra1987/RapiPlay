namespace RapiPlay.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class MdlPelicula : MdlBase
    {
        public string descripcion { get; set; }
        public string duracion { get; set; }
        public string anio { get; set; }
        public string censura { get; set; }
        public string reparto { get; set; }
        public string genero { get; set; }
        public string destacado { get; set; }
        public string url { get; set; }
        [JsonProperty("modulo")]
        public string modulo { get; set; }
        [JsonProperty("categoria")]
        public string categoria { get; set; }
    }

    [JsonObject]
    public class ListaPelicula : MdlRespuestaBase
    {
        public ListaPelicula()
        {
        }

        [JsonProperty("pelicula")]
        public List<MdlPelicula> pelicula { get; set; }
    }
}
