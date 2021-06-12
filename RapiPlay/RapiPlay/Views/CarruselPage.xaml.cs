using System;
using System.Collections.ObjectModel;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RapiPlay.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarruselPage : ContentPage
    {
        public CarruselPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            imgCabecera.Source = "https://fernandor26.sg-host.com/imgs/logos/logo-cabecera-carrusel.png";
        }
        private Timer timer;
        public ObservableCollection<carrusel> lista { get => load(); }

        protected override void OnAppearing()
        {
            timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds) { AutoReset = true, Enabled = true };
            timer.Elapsed += Timer_Elapsed;
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            timer.Dispose();
            base.OnDisappearing();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (listacarrusel.Position == 2)
                {
                    listacarrusel.Position = 0;
                    return;
                }
                listacarrusel.Position += 1;
            });
        }

        private ObservableCollection<carrusel> load()
        {
            return new ObservableCollection<carrusel>(new[]{
                new carrusel {url="https://fernandor26.sg-host.com/imgs/carrusel/carrusel-01.jpg" },
                new carrusel {url="https://fernandor26.sg-host.com/imgs/carrusel/carrusel-02.jpg" },
                new carrusel {url="https://fernandor26.sg-host.com/imgs/carrusel/carrusel-03.jpg" },
                new carrusel {url="https://fernandor26.sg-host.com/imgs/carrusel/carrusel-04.jpg" }
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresoPage());
        }
    }
    public class carrusel
    {
        public string url { get; set; }
    }
}