namespace RapiPlay.Services
{
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using RapiPlay.Models;

    public class ClsConsumoRest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ClsConsumoRest()
        {
        }

        public string strUrlApi = "http://172.17.128.1/rapinet/RestApi/";


        /// <summary>
        /// Metodo que sirve para consumo de rest
        /// </summary>
        /// <typeparam name="T">Tipo de objeto</typeparam>
        /// <param name="_url">Url a consumir</param>
        /// <param name="_httpMethod">Verbo</param>
        /// <returns>Objeto del tipo T</returns>
        public async Task<T> ConsumirApiRest<T>(Uri _url, HttpMethod _httpMethod)
        {
            try
            {
                string strCadena = string.Empty;
                HttpClient _httpClient = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();

                if (_httpMethod == HttpMethod.Get)
                    response = await _httpClient.GetAsync(_url);
                else
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    request.RequestUri = _url;
                    request.Method = _httpMethod;
                    request.Headers.Add("Accept", "application/json");
                    response = await _httpClient.SendAsync(request);
                }

                if (response.StatusCode == HttpStatusCode.OK)
                    strCadena = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(strCadena);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene usuarios
        /// </summary>
        /// <param name="strCedula">Cedula</param>
        /// <param name="strContrasenia">Clave</param>
        /// <returns>Lista Usuario</returns>
        public async Task<ListaLogin> ObtenerUsuarioAsync(string strCedula,string strContrasenia)
        {
            Uri _url = new Uri(strUrlApi + "usuario.php?vusu=" + strCedula + "&vcla=" + strContrasenia);
            ListaLogin objLista = await ConsumirApiRest<ListaLogin>(_url, HttpMethod.Get);
            return objLista;
        }

        public async Task<ListaLogin> ActualizaUsuarioConectadoAsync(string strCedula, int strConectado)
        {
            Uri _url = new Uri(strUrlApi + "usuario.php?vced=" + strCedula + "&vcon=" + strConectado);
            ListaLogin objLista = await ConsumirApiRest<ListaLogin>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Metodo que obtiene los modulos
        /// </summary>
        /// <returns>Lista de modulos</returns>
        public async Task<ListaModulo> ObtenerModulosAsync()
        {
            Uri _url = new Uri(strUrlApi + "modulo.php");
            ListaModulo objLista = await ConsumirApiRest<ListaModulo>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Metodo que obtiene la lista de categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public async Task<ListaCategoria> ObtenerCatagoriasAsync() 
        {
            Uri _url = new Uri(strUrlApi + "categoria.php");
            ListaCategoria objLista = await ConsumirApiRest<ListaCategoria>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Obtiene listado de todas las peliculas
        /// </summary>
        /// <returns>Listado de peliculas</returns>
        public async Task<ListaPelicula> ObtenerPeliculasAsync()
        {
            Uri _url = new Uri(strUrlApi + "pelicula.php");
            ListaPelicula objLista = await ConsumirApiRest<ListaPelicula>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Obtiene listado de peliculas por categoria
        /// </summary>
        /// <param name="strCategoria">Id de categoria</param>
        /// <returns>Listado de peliculas</returns>
        public async Task<ListaPelicula> ObtenerPeliculaPorCategoriaAsync(string strCategoria)
        {
            Uri _url = new Uri(strUrlApi + "pelicula.php?vcate=" + strCategoria);
            ListaPelicula objLista = await ConsumirApiRest<ListaPelicula>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Obtiene listado de peliculas por categoria y modulo
        /// </summary>
        /// <param name="strCategoria">Id de categoria</param>
        /// <param name="strModulo">Id de modulo</param>
        /// <returns>Listado de peliculas</returns>
        public async Task<ListaPelicula> ObtenerPeliculaPorCategoriaModuloAsync(string strCategoria, string strModulo)
        {
            Uri _url = new Uri(strUrlApi + "pelicula.php?vcat=" + strCategoria + "&vmod=" + strModulo);
            ListaPelicula objLista = await ConsumirApiRest<ListaPelicula>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Obtiene las peliculas que coicidan con el nombre
        /// </summary>
        /// <param name="strPelicula">Nombre de la pelicula</param>
        /// <returns>Lista de peliculas</returns>
        public async Task<ListaPelicula> ObtenerPeliculaPorNombreAsync(string strPelicula)
        {
            Uri _url = new Uri(strUrlApi + "pelicula.php?vpel=" + strPelicula);
            ListaPelicula objLista = await ConsumirApiRest<ListaPelicula>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Obtiene las peliculas por codigo
        /// </summary>
        /// <param name="strPelicula">Codigo de la pelicula</param>
        /// <returns>Lista de peliculas</returns>
        public async Task<ListaPelicula> ObtenerPeliculaPorCodigoAsync(string strPelicula)
        {
            Uri _url = new Uri(strUrlApi + "pelicula.php?vpcod=" + strPelicula);
            ListaPelicula objLista = await ConsumirApiRest<ListaPelicula>(_url, HttpMethod.Get);
            return objLista;
        }

        /// <summary>
        /// Obtiene catalogo de recursos
        /// </summary>
        /// <param name="strRecurso">Recurso</param>
        /// <returns>Lista de recurso</returns>
        public async Task<ListaPelicula> ObtenerRecursoPorCodigoAsync(string strRecurso)
        {
            Uri _url = new Uri(strUrlApi + "recurso.php?vrec=" + strRecurso);
            ListaPelicula objLista = await ConsumirApiRest<ListaPelicula>(_url, HttpMethod.Get);
            return objLista;
        }
    }
}