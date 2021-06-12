namespace RapiPlay.Views
{
    using System;
    using System.Timers;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
        }
        private Timer timer;
        protected override void OnAppearing()
        {
            timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds) { AutoReset = false, Enabled = true };
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
                App.Current.MainPage = new NavigationPage(new CarruselPage());
            });
        }
    }
}