using SaladilloFit.Model;
using SaladilloFit.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaladilloFit.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario_View : ContentPage
    {
        Usuario_ViewModel ViewModel;

        public Usuario_View(Usuarios Usuario)
        {
            InitializeComponent();

            ViewModel = new Usuario_ViewModel(this, Navigation, Usuario, lblSaludo, lblDNI, lblHorario, lblObjetivo, lblEdad, lblAltura, lblPeso, lblIMC);

            InitViews();

            // Cuando hacemos click en Cerrar Sesión, realiza las comprobaciones de que el usuario y la contraseña son correctas y realiza la navegación a la vista que corresponda.
            btnLogout.Clicked += (sender, args) =>
            {
                ViewModel.Cerrar_Sesion();
            };
        }

        private void InitViews()
        {
            ViewModel.RellenarDatos();
        }
    }
}