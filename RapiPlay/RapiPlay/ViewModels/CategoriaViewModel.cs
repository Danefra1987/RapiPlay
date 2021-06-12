namespace RapiPlay.ViewModels
{
    using System.Threading.Tasks;
    using RapiPlay.Models;
    using RapiPlay.Services;

    public class CategoriaViewModel : BaseViewModel
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public CategoriaViewModel()
        {

        }

        /// <summary>
        /// Metodo que obtiene la Lista de categorias
        /// </summary>
        /// <returns></returns>
        public async Task<ListaCategoria> ObtenerCategoriasAsync()
        {
            ClsConsumoRest clsRest = new ClsConsumoRest();
            ListaCategoria objLista = await clsRest.ObtenerCatagoriasAsync();
            return objLista;
        }

    }
}
