using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaladilloFit.View;
using Xamarin.Forms;
using SaladilloFit.Model;
using SaladilloFit.Assets;

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
            this.lblSaludo = lblSaludo;
            this.lblDNI = lblDNI;
            this.lblHorario = lblHorario;
            this.lblObjetivo = lblObjetivo;
            this.lblEdad = lblEdad;
            this.lblAltura = lblAltura;
            this.lblPeso = lblPeso;
            this.lblIMC = lblIMC;
        }

        public void RellenarDatos()
        {
            lblSaludo.Text = "Bienvenido, " + usuario.Nombre;
            lblDNI.Text = usuario.DNI;
            lblHorario.Text = Horarios_Repository.GetItem(usuario.Horario).Horario;
            lblObjetivo.Text = Objetivos_Repository.GetItem(usuario.Objetivo).Objetivo;
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
