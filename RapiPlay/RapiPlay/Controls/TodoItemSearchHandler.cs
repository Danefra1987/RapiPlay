namespace RapiPlay.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RapiPlay.Models;
    using RapiPlay.Services;
    using RapiPlay.ViewModels;
    using Xamarin.Forms;

    public class TodoItemSearchHandler: SearchHandler
    {
        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            await QueryItems(oldValue, newValue);
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            await Task.Delay(1000);

            var id = ((MdlModulo)item).id;

            //// Note: strings will be URL encoded for navigation
            //await Shell.Current.GoToAsync($"//todo/todoItem?itemid={id}");
        }

        private async Task QueryItems(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ClsConsumoRest objResultado = new ClsConsumoRest();
                var dbItems = await objResultado.ObtenerModulosAsync();

                ItemsSource = dbItems.modulo
                        .Where(x => x.nombre.ToLower()
                        .Contains(newValue.ToLower()))
                        .ToList();
            }
        }
    }
}
