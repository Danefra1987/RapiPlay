using RapiPlay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RapiPlay.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        public Perfil()
        {
            InitializeComponent();
            MyMenu();
            BindingContext = this;
        }

        public class Menu
        {
            public string MenuImagen
            { get; set; }
            public string MenuTitle
            { get; set; }
            public string MenuDetail
            { get; set; }
            public Page Page
            { get; set; }
        }
        public void MyMenu()
        {
            List<Menu> menu = new List<Menu>
            {
                new Menu{Page = new ModuloPage(),MenuTitle="Modulos",MenuDetail="Lista de modulos",MenuImagen=FontAwesomeIcons.Module},
                new Menu{Page = new CategoriaPage(),MenuTitle="Categorias",MenuDetail="Lista de categorías",MenuImagen=FontAwesomeIcons.Module},
                new Menu{Page = new PeliculaPage(string.Empty),MenuTitle="Películas",MenuDetail="Listado de películas",MenuImagen=FontAwesomeIcons.Categoria},
                new Menu{Page = new InicioPage(),MenuTitle="Cerrar sesión",MenuDetail="Lista de categorías",MenuImagen=FontAwesomeIcons.Signoutalt}
            };
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                Navigation.PushAsync(menu.Page);
            }

        }
    }
}