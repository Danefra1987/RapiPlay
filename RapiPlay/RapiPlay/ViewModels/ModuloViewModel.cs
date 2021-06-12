namespace RapiPlay.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using RapiPlay.Models;
    using RapiPlay.Services;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class ModuloViewModel : BaseViewModel
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public ModuloViewModel()
        {
        }

        /// <summary>
        /// Obtine los Modulos
        /// </summary>
        /// <returns>Lista de modulos</returns>
        public async Task<ListaModulo> ObtenerModulosAsync()
        {
            ClsConsumoRest clsRest = new ClsConsumoRest();
            ListaModulo objLista = await clsRest.ObtenerModulosAsync();
            return objLista;
        }
    }
}
