namespace RapiPlay.Views
{
    using RapiPlay.Models;
    using RapiPlay.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeliculaDetalle : ContentPage
    {
        public string mstrPelicula;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="strPelicula">Codigo de pelicula</param>
        public PeliculaDetalle(string strPelicula)
        {
            InitializeComponent();
            mstrPelicula = strPelicula;
            Obtener();
        }

        /// <summary>
        /// Obtiene listado de peliculas
        /// </summary>
        public async void Obtener()
        {
            PeliculaViewModel objVista = new PeliculaViewModel();
            ListaPelicula objLista = await objVista.ObtenerPeliculaPorCodigoAsync(mstrPelicula);
            
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

        /// <summary>
        /// Genera grid con informacion de la pelicula
        /// </summary>
        /// <param name="objLista"></param>
        /// <returns>Pelicula</returns>
        private Grid GenerarGrid(ListaPelicula objLista)
        {
            Grid grid = new Grid();
            var contador = 0;

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
                    StackLayout stackLayoutAnio = new StackLayout();
                    stackLayoutAnio.Orientation = StackOrientation.Horizontal;
                    stackLayoutAnio.HorizontalOptions = LayoutOptions.FillAndExpand;
                    stackLayoutAnio.VerticalOptions = LayoutOptions.StartAndExpand;
                    Label lblAnio = new Label
                    {
                        Text = objLista.pelicula[contador - 1].anio,
                        TextColor = Color.White,
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };
                    Label lblDuracion = new Label
                    {
                        Text = objLista.pelicula[contador - 1].duracion,
                        TextColor = Color.White,
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };
                    stackLayoutAnio.Children.Add(lblAnio);
                    stackLayoutAnio.Children.Add(lblDuracion);

                    StackLayout stackLayoutLabel = new StackLayout();
                    stackLayoutLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
                    stackLayoutLabel.VerticalOptions = LayoutOptions.FillAndExpand;

                    Label lblNombre = new Label
                    {
                        Text = objLista.pelicula[contador - 1].nombre,
                        TextColor = Color.White,
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };
                    stackLayoutLabel.Children.Add(lblNombre);
                    stackLayoutLabel.Children.Add(stackLayoutAnio);

                    Label lblDescripcion = new Label
                    {
                        Text = objLista.pelicula[contador - 1].descripcion,
                        TextColor = Color.White,
                        FontSize = 14,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };
                    stackLayoutLabel.Children.Add(lblDescripcion);

                    Label lblTituloElenco = new Label
                    {
                        Text = "Elenco:",
                        TextColor = Color.White,
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    stackLayoutLabel.Children.Add(lblTituloElenco);

                    Label lblElenco = new Label
                    {
                        Text = objLista.pelicula[contador - 1].reparto,
                        TextColor = Color.White,
                        FontSize = 14,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    stackLayoutLabel.Children.Add(lblElenco);

                    Label lblTituloGenero = new Label
                    {
                        Text = "Genero:",
                        TextColor = Color.White,
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    stackLayoutLabel.Children.Add(lblTituloGenero);

                    Label lblGenero = new Label
                    {
                        Text = objLista.pelicula[contador - 1].genero,
                        TextColor = Color.White,
                        FontSize = 14,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    stackLayoutLabel.Children.Add(lblGenero);

                    Label lblTituloCensura = new Label
                    {
                        Text = "Censura",
                        TextColor = Color.White,
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    stackLayoutLabel.Children.Add(lblTituloCensura);

                    Label lblCensura = new Label
                    {
                        Text = objLista.pelicula[contador - 1].censura,
                        TextColor = Color.White,
                        FontSize = 14,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    stackLayoutLabel.Children.Add(lblCensura);

                    StackLayout stackLayoutButton = new StackLayout();
                    stackLayoutButton.HorizontalOptions = LayoutOptions.FillAndExpand;

                    Button btnReproducir = new Button()
                    {
                        Text = "Reproducir",
                        ImageSource = "https://img.icons8.com/metro/2x/play.png",
                        FontSize = 14,
                        TextColor = Color.Black,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        ClassId = objLista.pelicula[contador - 1].url,
                    };
                    btnReproducir.Clicked += btnReproducir_Clicked;
                    stackLayoutButton.Children.Add(btnReproducir);
                    stackLayoutLabel.Children.Add(stackLayoutButton);

                    Image imageButton = new Image()
                    {
                        Source = objLista.pelicula[contador - 1].imagen,
                        WidthRequest = 150,
                        HeightRequest = 200,
                        ClassId = objLista.pelicula[contador - 1].id,
                        Aspect = Aspect.AspectFill
                    };

                    StackLayout stackLayoutContent = new StackLayout()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.StartAndExpand,

                    };
                    stackLayoutContent.Children.Add(imageButton);
                    stackLayoutContent.Children.Add(stackLayoutLabel);

                    Frame frame = new Frame
                    {
                        CornerRadius = 5,
                        BorderColor = Color.Black,
                        Padding = 5,
                        Content = stackLayoutContent,
                        ClassId = objLista.pelicula[contador - 1].url,
                        BackgroundColor = Color.Black
                    };
                    grid.Children.Add(frame, j, i);
                }
            }
            return grid;
        }

        private void btnReproducir_Clicked(object sender, EventArgs e)
        {
            //"http://200.24.139.103:8816/mulan.mkv"
            Button objSender = (Button)sender;
            var id = objSender.ClassId;
            Navigation.PushAsync(new ReproductorPage(id));
        }
    }
}