namespace RapiPlay.ViewModels
{
    using RapiPlay.Models;
    using RapiPlay.Services;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class UsuarioViewModel : BaseViewModel
    {
        public ICommand _command { get; set; }
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UsuarioViewModel()
        {
           
        }

        private string _cedula;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _password;
        

        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; OnPropertyChanged(); }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(); }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged(); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }
        public string Clave
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Obtiene usuario
        /// </summary>
        /// <param name="strUsuario">Cedula del usuario</param>
        /// <param name="strContrasenia">Clave del usuario</param>
        /// <returns>Lista de usuario</returns>
        public async Task<ListaLogin> ObtenerUsuarioAsync(string strUsuario, string  strContrasenia)
        {
            ClsConsumoRest clsRest = new ClsConsumoRest();
            ListaLogin objLista = await clsRest.ObtenerUsuarioAsync(strUsuario, strContrasenia);
            return objLista;
        }

        /// <summary>
        /// Actualiza el nuemro de conexiones permitidas al usuario
        /// </summary>
        /// <param name="strUsuario">Cedula del usuario</param>
        /// <param name="strConectado">Numero de conexiones</param>
        /// <returns></returns>
        public async Task<ListaLogin> ActualizaUsuarioConectadoAsync(string strUsuario, int strConectado)
        {
            ClsConsumoRest clsRest = new ClsConsumoRest();
            ListaLogin objLista = await clsRest.ActualizaUsuarioConectadoAsync(strUsuario, strConectado);
            return objLista;
        }
    }
}
