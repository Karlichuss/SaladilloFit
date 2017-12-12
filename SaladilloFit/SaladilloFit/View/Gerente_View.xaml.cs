using System;
using SaladilloFit.Model;
using SaladilloFit.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaladilloFit.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gerente_View : ContentPage
    {
        Gerente_ViewModel ViewModel;

        public Gerente_View(Usuarios Usuario)
        {
            InitializeComponent();

            ViewModel = new Gerente_ViewModel(this, Navigation, Usuario, txtNombre, txtDNI, pckHorario, txtEdad, txtAltura, txtPeso, pckObjetivo, lblStatus, lstUsuarios);

            InitViews();

            // Cuando hacemos click en Iniciar Sesión, realiza las comprobaciones de que el usuario y la contraseña son correctas y realiza la navegación a la vista que corresponda.
            btnAniadir.Clicked += async (sender, args) =>
            {
                await ViewModel.Añadir_Usuario();
            };
            
            // Cuando hacemos click en Cambiar Usuario, volvemos a la vista de Login.
            btnLogout.Clicked += (sender, args) =>
            {
                ViewModel.Cerrar_Sesion();
            };

        }

        public void InitViews()
        {
            ViewModel.RellenarPickers();
        }
    }
}