namespace RapiPlay
{
    using RapiPlay.Views;
    using System.Collections.Generic;
    using Xamarin.Forms;
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMenu();
            BindingContext = this;
        }
        public class Menu
        {
            public string MenuTitle
            { get; set; }
            public string MenuDetail
            { get; set; }
            public Page Page
            { get; set; }
        }
        public void MyMenu()
        {
            Detail = new NavigationPage(new ModuloPage());
            List<Menu> menu = new List<Menu>
            {
                new Menu{Page = new ModuloPage(),MenuTitle="Modulos",MenuDetail="Lista de modulos"},
                new Menu{Page = new CategoriaPage(),MenuTitle="Categorias",MenuDetail="Lista de categorias"},
            };
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu!=null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }

        }
    }
}
