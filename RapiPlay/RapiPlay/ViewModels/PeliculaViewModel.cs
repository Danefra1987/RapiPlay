namespace RapiPlay.ViewModels
{
    using RapiPlay.Models;
    using RapiPlay.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class PeliculaViewModel : BaseViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PeliculaViewModel()
        {
        }

        /// <summary>
        /// Metodo que obtiene la Lista de categorias
        /// </summary>
        /// <returns>Lista de peliculas</returns>
        public async Task<ListaPelicula> ObtenerPeliculaPorCategoriaAsync(string strCategoria)
        {
            ClsConsumoRest clsRest = new ClsConsumoRest();
            ListaPelicula objLista = await clsRest.ObtenerPeliculaPorCategoriaAsync(strCategoria);
            return objLista;
        }

        /// <summary>
        /// Metodo que obtiene la Lista de categorias
        /// </summary>
        /// <returns></returns>
        public async Task<ListaPelicula> ObtenerPeliculaPorCodigoAsync(string strPelicula)
        {
            ClsConsumoRest clsRest = new ClsConsumoRest();
            ListaPelicula objLista = await clsRest.ObtenerPeliculaPorCodigoAsync(strPelicula);
            return objLista;
        }

        /// <summary>
        /// Obtiene todas las peliculas
        /// </summary>
        /// <returns>Listado de peliculas</returns>
        public async Task<ListaPelicula> ObtenerPeliculasAsync()
        {
            ClsConsumoRest clsRest = new ClsConsumoRest();
            ListaPelicula objLista = await clsRest.ObtenerPeliculasAsync();
            return objLista;
        }

        /// <summary>
        /// Obtiene peliculas por nombre
        /// </summary>
        /// <returns>Lista de peliculas</returns>
        public async Task<ListaPelicula> ObtenerPeliculaPorNombreAsync(string strPelicula)
        {
            ClsConsumoRest clsRest = new ClsConsumoRest();
            ListaPelicula objLista = await clsRest.ObtenerPeliculaPorNombreAsync(strPelicula);
            return objLista;
        }
    }
}
