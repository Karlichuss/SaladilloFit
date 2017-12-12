using SaladilloFit.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaladilloFit.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_View : ContentPage
    {

        Login_ViewModel ViewModel;

        public Login_View()
        {
            InitializeComponent();

            InitViews();

            ViewModel = new Login_ViewModel(this, Navigation, txtUsuario, txtContrasenia, lblStatus);

            // Cuando hacemos click en Iniciar Sesión, realiza las comprobaciones de que el usuario y la contraseña son correctas y realiza la navegación a la vista que corresponda.
            btnLogIn.Clicked += async (sender, args) =>
            {
                await ViewModel.Iniciar_SesionAsync();
            };

            // Cuando escribimos algo en el campo de texto, tenemos que controlar que no se metan mas de 9 caracteres.
            txtUsuario.TextChanged += (sender, args) =>
            {
                ViewModel.ImpedirMaxCaracteres(9, txtUsuario);
            };

            // Cuando escribimos algo en el campo de texto, tenemos que controlar que no se metan mas de 9 caracteres.
            txtContrasenia.TextChanged += (sender, args) =>
            {
                ViewModel.ImpedirMaxCaracteres(9, txtContrasenia);
            };

        }

        /// <summary>
        /// Realiza las operaciones de configuración de la vista para que cuando se abra, esta esté personalizada.
        /// </summary>
        private void InitViews()
        {
            // Impedimos que salte el null exception dandole valor inicial a cadena vacía a los campos.
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
        }
    }
}