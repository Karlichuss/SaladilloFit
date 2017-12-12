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
    public partial class Gerente_View : ContentPage
    {
        Gerente_ViewModel ViewModel;

        public Gerente_View(Usuarios Usuario)
        {
            InitializeComponent();

            ViewModel = new Gerente_ViewModel(this, Navigation, Usuario, txtNombre, txtDNI, pckHorario, txtEdad, txtAltura, txtPeso, pckObjetivo, lblStatus, lstUsuarios);

            InitViews();

            // Cuando hacemos click en Añadir, introduce en la base de datos un nuevo usuario con los datos del formulario.
            btnAniadir.Clicked += async (sender, args) =>
            {
                await ViewModel.Aniadir_Usuario();
            };

            // Cuando hacemos click en Cambiar Usuario, volvemos a la vista de Login.
            btnLogout.Clicked += (sender, args) =>
            {
                ViewModel.Cerrar_Sesion();
            };

        }

        public void InitViews()
        {
            ViewModel.RellenarPickersAsync();
        }
    }
}