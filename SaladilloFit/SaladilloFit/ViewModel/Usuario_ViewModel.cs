using SaladilloFit.Assets;
using SaladilloFit.Model;
using SaladilloFit.View;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaladilloFit.ViewModel
{
    public class Usuario_ViewModel
    {
        Page page;
        INavigation navigation;
        Usuarios usuario;

        Label lblSaludo;
        Label lblDNI;
        Label lblHorario;
        Label lblObjetivo;
        Label lblEdad;
        Label lblAltura;
        Label lblPeso;
        Label lblIMC;

        public Usuario_ViewModel(Page usuario_View, INavigation navigation, Usuarios usuario, Label lblSaludo, Label lblDNI, Label lblHorario, Label lblObjetivo, Label lblEdad, Label lblAltura, Label lblPeso, Label lblIMC)
        {
            this.page = usuario_View;
            this.navigation = navigation;
            this.usuario = usuario;
            this.lblSaludo = lblSaludo;
            this.lblDNI = lblDNI;
            this.lblHorario = lblHorario;
            this.lblObjetivo = lblObjetivo;
            this.lblEdad = lblEdad;
            this.lblAltura = lblAltura;
            this.lblPeso = lblPeso;
            this.lblIMC = lblIMC;
        }

        public async Task RellenarDatos()
        {
            lblSaludo.Text = "Bienvenido, " + usuario.Nombre;
            lblDNI.Text = usuario.DNI;
            lblHorario.Text =( await Horarios_Repository.GetItem(usuario.Horario)).Horario;
            lblObjetivo.Text =( await Objetivos_Repository.GetItem(usuario.Objetivo)).Objetivo;
            lblEdad.Text = usuario.Edad.ToString();
            lblAltura.Text = usuario.Altura.ToString();
            lblPeso.Text = usuario.Peso.ToString();
            lblIMC.Text = usuario.IMC.ToString();
        }

        public void Cerrar_Sesion()
        {
            navigation.PushModalAsync(new Login_View());
        }
    }
}
