namespace RapiPlay.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [JsonObject]
    public class MdlLogin
    {
        [JsonProperty("cedula")]
        public string cedula { get; set; }
        [JsonProperty("nombre")]
        public string nombre { get; set; }
        [JsonProperty("apellido")]
        public string apellido { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("login")]
        public string login { get; set; }
        [JsonProperty("conectado")]
        public string conectado { get; set; }
        [JsonProperty("maximo")]
        public string maximo { get; set; }
    }

    public class ListaLogin: MdlRespuestaBase
    {
        public ListaLogin()
        { }

        [JsonProperty("usuario")]
        public List<MdlLogin> usuario { get; set; }
    }
}

