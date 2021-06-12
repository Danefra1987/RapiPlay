namespace RapiPlay.Views
{
    using LibVLCSharp.Shared;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReproductorPage : ContentPage
    {
        LibVLC _libVLC;
        public ReproductorPage(string strUrl)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Core.Initialize();
            _libVLC = new LibVLC();
            var media = new Media(_libVLC, strUrl, FromType.FromLocation);
            Video.MediaPlayer = new MediaPlayer(media)
            {
                EnableHardwareDecoding = true
            };
            Video.MediaPlayer.Play();
        }
        protected override void OnDisappearing()
        {
            Video.MediaPlayer.Stop();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PopAsync();
            });
        }
    }
}