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
            //Detail = new NavigationPage(new ModuloPage());
            List<Menu> menu = new List<Menu>
            {
                new Menu{Page = new ModuloPage(),MenuTitle="Modulos",MenuDetail="Lista de modulos",MenuImagen=""},
                new Menu{Page = new CategoriaPage(),MenuTitle="Categorias",MenuDetail="Lista de categorías",MenuImagen=""},
                new Menu{Page = new CategoriaPage(),MenuTitle="Películas",MenuDetail="Listado de películas",MenuImagen=""},
                new Menu{Page = new InicioPage(),MenuTitle="Cerrar sesión",MenuDetail="Lista de categorías",MenuImagen=""}
            };
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                //IsPresented = false;
                Navigation.PushAsync(menu.Page);
                //new NavigationPage(menu.Page);
            }

        }
    }
}