namespace RapiPlay.Views
{
    using RapiPlay.Models;
    using RapiPlay.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModuloPage : ContentPage
    {
        public ModuloPage()
        {
            InitializeComponent();
            //btnUsuario.Text = Application.Current.Properties["Apellido"].ToString().Substring(0, 1).ToUpper();
            Obtener();
        }

        /// <summary>
        /// Obtiene el listado de modulos
        /// </summary>
        public async void Obtener()
        {
            ModuloViewModel objVista = new ModuloViewModel();
            ListaModulo objLista = await objVista.ObtenerModulosAsync();

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
        /// Obtiene grid con listado de modulos
        /// </summary>
        /// <param name="objLista">Lista de modulos</param>
        /// <returns>Grid con informacion de los modulos</returns>
        private Grid GenerarGrid(ListaModulo objLista)
        {
            Grid grid = new Grid();
            int intContador = 0;

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            int intFilas = objLista.modulo.Count / grid.ColumnDefinitions.Count + objLista.modulo.Count % grid.ColumnDefinitions.Count;

            for (int i = 0; i < intFilas; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < grid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < grid.ColumnDefinitions.Count; j++)
                {
                    intContador++;
                    if (intContador > objLista.modulo.Count)
                        break;

                    ImageButton imagen = new ImageButton()
                    {
                        BackgroundColor = Color.Black,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Source = objLista.modulo[intContador - 1].imagen,
                        ClassId = objLista.modulo[intContador - 1].id,
                        HeightRequest = 200,
                        Padding = 10,
                        Aspect = Aspect.AspectFill
                    };
                    imagen.Clicked += ImageButton_Clicked;
                    grid.Children.Add(imagen, j, i);
                }
            }
            return grid;
        }

       
        private void ImageButton_Clicked(object sender, System.EventArgs e)
        {
            ImageButton objSender = (ImageButton)sender;
            var id = objSender.ClassId;
            Navigation.PushAsync(new CategoriaPage());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var sesion = Application.Current.Properties["usuario"];
        }

        private void btnBuscar_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PeliculaPage(string.Empty));
        }

        private void btnUsuario_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Perfil());
        }
    }
}