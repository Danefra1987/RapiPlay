namespace RapiPlay.Views
{
    using RapiPlay.Models;
    using RapiPlay.ViewModels;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeliculaPage : ContentPage
    {
        public PeliculaPage(string strCategoria)
        {
            InitializeComponent();
            Obtener(strCategoria, string.Empty);
        }

        /// <summary>
        /// Obtiene el listado de peliculas por categoria
        /// </summary>
        public async void Obtener(string strCategoria, string strPelicula)
        {
            PeliculaViewModel objVista = new PeliculaViewModel();
            ListaPelicula objLista = new ListaPelicula();

            if (string.IsNullOrEmpty(strCategoria) && string.IsNullOrEmpty(strPelicula))
                objLista = await objVista.ObtenerPeliculasAsync();
            if (!string.IsNullOrEmpty(strCategoria) && string.IsNullOrEmpty(strPelicula))
                objLista = await objVista.ObtenerPeliculaPorCategoriaAsync(strCategoria);
            if (string.IsNullOrEmpty(strCategoria) && !string.IsNullOrEmpty(strPelicula))
                objLista = await objVista.ObtenerPeliculaPorNombreAsync(strPelicula);

            ObtenerContent(objLista);
        }

        /// <summary>
        /// Listado de peliculas
        /// </summary>
        /// <param name="objLista">ListaPelicula</param>
        private void ObtenerContent(ListaPelicula objLista)
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

        /// <summary>
        /// Genera grid con informacion de peliculas
        /// </summary>
        /// <param name="objLista">Listado de peliculas</param>
        /// <returns>Grid con listado de peliculas</returns>
        private Grid GenerarGrid(ListaPelicula objLista)
        {
            Grid grid = new Grid();
            var contador = 0;

            if (objLista.codigoError==0)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

                int intFilas = objLista.pelicula.Count / grid.ColumnDefinitions.Count + objLista.pelicula.Count % grid.ColumnDefinitions.Count;

                for (int i = 0; i < intFilas; i++)
                {
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                }

                for (int i = 0; i < grid.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < grid.ColumnDefinitions.Count; j++)
                    {
                        contador++;
                        if (contador > objLista.pelicula.Count)
                            break;

                        StackLayout stackLayoutLabel = new StackLayout();
                        stackLayoutLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
                        stackLayoutLabel.VerticalOptions = LayoutOptions.FillAndExpand;

                        Label label = new Label
                        {
                            Text = objLista.pelicula[contador - 1].nombre,
                            TextColor = Color.White,
                            FontSize = 14,
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        };
                        stackLayoutLabel.Children.Add(label);

                        ImageButton imageButton = new ImageButton()
                        {
                            Source = objLista.pelicula[contador - 1].imagen,
                            CornerRadius = 0,
                            WidthRequest = 150,
                            HeightRequest = 200,
                            BorderColor = Color.Black,
                            ClassId = objLista.pelicula[contador - 1].id,
                            Aspect = Aspect.AspectFill
                        };
                        imageButton.Clicked += ImageButton_Clicked;

                        StackLayout stackLayoutContent = new StackLayout()
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,

                        };
                        stackLayoutContent.Children.Add(imageButton);
                        stackLayoutContent.Children.Add(stackLayoutLabel);

                        Frame frame = new Frame
                        {
                            CornerRadius = 5,
                            BorderColor = Color.Black,
                            Padding = 5,
                            Content = stackLayoutContent,
                            ClassId = objLista.pelicula[contador - 1].id,
                            BackgroundColor = Color.Black
                        };
                        grid.Children.Add(frame, j, i);
                    }
                }
            }
            else
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

                for (int i = 0; i < grid.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < grid.ColumnDefinitions.Count; j++)
                    {
                        contador++;
                        StackLayout stackLayoutContent = new StackLayout()
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Padding = 10
                        };

                        Label labelTitle = new Label
                        {
                            Text = "!Esta opción no esta disponible!",
                            TextColor = Color.White,
                            FontSize = 24,
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        };
                        stackLayoutContent.Children.Add(labelTitle);

                        Label labelMensaje = new Label
                        {
                            Text = objLista.mensaje,
                            TextColor = Color.White,
                            FontSize = 14,
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        };
                        stackLayoutContent.Children.Add(labelMensaje);

                        grid.Children.Add(stackLayoutContent, i, j);
                    }
                }
            }
            return grid;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton objSender = (ImageButton)sender;
            var id = objSender.ClassId;
            Navigation.PushAsync(new PeliculaDetalle(id));
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Entry searchBar = (Entry)sender;
            SearchBar searchBar = (SearchBar)sender; 
            Obtener(string.Empty, searchBar.Text);
        }

       
    }
}