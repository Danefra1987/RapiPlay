namespace RapiPlay.Views
{
    using System;
    using RapiPlay.Models;
    using RapiPlay.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaPage : ContentPage
    {
        public CategoriaPage()
        {
            InitializeComponent();
            Obtener();
        }

        public async void Obtener()
        {
            CategoriaViewModel objVista = new CategoriaViewModel();
            ListaCategoria objLista = await objVista.ObtenerCategoriasAsync();

            if (objLista.codigoError == 0)
            {
                Content = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,                    
                    BackgroundColor = Color.Black,
                    Children =
                    {
                        new ScrollView
                        {
                            Content = GenerarGrid(objLista)
                        }
                    }
                };
            }
            else
                await DisplayAlert("Mensaje", objLista.mensaje, "Aceptar");
        }

        private Grid GenerarGrid(ListaCategoria objLista)
        {
            Grid grid = new Grid();
            int intContador = 0;

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            int intFilas = objLista.categoria.Count / grid.ColumnDefinitions.Count + objLista.categoria.Count % grid.ColumnDefinitions.Count;

            for (int i = 0; i < intFilas; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < grid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < grid.ColumnDefinitions.Count; j++)
                {
                    intContador++;
                    if (intContador > objLista.categoria.Count)
                        break;

                    ImageButton imagen = new ImageButton()
                    {
                        BackgroundColor = Color.Black,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Source = objLista.categoria[intContador - 1].imagen,
                        ClassId = objLista.categoria[intContador - 1].id,
                        HeightRequest = 120,
                        Margin = 8,
                        Padding = 12,
                        Aspect = Aspect.AspectFill
                    };
                    imagen.Clicked += ImageButton_Clicked;
                    grid.Children.Add(imagen, j, i);
                }
            }
            return grid;
        }

        private double width = 0;
        private double height = 0;
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //if (width != this.width || height != this.height)
            //{
            this.width = width;
            this.height = height;
            if (width > height)
            {
                Contenedor.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                Contenedor.Orientation = StackOrientation.Vertical;
            }
            //}
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton objSender = (ImageButton)sender;
            var id = objSender.ClassId;
            Navigation.PushAsync(new PeliculaPage(id));
        }
    }
}