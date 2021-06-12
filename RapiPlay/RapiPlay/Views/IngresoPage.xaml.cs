namespace RapiPlay.Views
{
    using RapiPlay.Models;
    using RapiPlay.ViewModels;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresoPage : ContentPage
    {
        public IngresoPage()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtContrasenia.Text))
            {
                ListaLogin objMdlLogin = new ListaLogin();
                UsuarioViewModel objModel = new UsuarioViewModel();
                objMdlLogin = await objModel.ObtenerUsuarioAsync(txtUsuario.Text, txtContrasenia.Text);
                if (objMdlLogin.codigoError == 0 && objMdlLogin != null && objMdlLogin.usuario[0].password == txtContrasenia.Text)
                {
                    int intConectados = Convert.ToInt32(objMdlLogin.usuario[0].conectado) + 1;
                    //await objModel.ActualizaUsuarioConectadoAsync(objMdlLogin.usuario[0].cedula, intConectados);
                    Application.Current.Properties["usuario"] = objMdlLogin.usuario[0].cedula;
                    Application.Current.Properties["Nombre"] = objMdlLogin.usuario[0].nombre;
                    Application.Current.Properties["Apellido"] = objMdlLogin.usuario[0].apellido;
                    await Navigation.PushAsync(new ModuloPage());
                }
                else
                    await DisplayAlert("Mensaje", objMdlLogin.mensaje, "Aceptar");
            }
        }
    }
}