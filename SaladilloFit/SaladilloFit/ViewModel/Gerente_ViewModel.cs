using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaladilloFit.Model;
using SaladilloFit.View;
using Xamarin.Forms;
using SaladilloFit.Assets;

namespace SaladilloFit.ViewModel
{
    class Gerente_ViewModel
    {
        private Page page;
        private INavigation navigation;
        private Usuarios usuario;
        private Entry txtNombre;
        private Entry txtDNI;
        private Picker pckHorario;
        private Entry txtEdad;
        private Entry txtAltura;
        private Entry txtPeso;
        private Picker pckObjetivo;
        private Label lblStatus;
        private ListView lstUsuarios;

        public Gerente_ViewModel(Page gerente_View, INavigation navigation, Usuarios usuario, Entry txtNombre, Entry txtDNI, Picker pckHorario, Entry txtEdad, Entry txtAltura, Entry txtPeso, Picker pckObjetivo, Label lblStatus, ListView lstUsuarios)
        {
            this.page = gerente_View;
            this.navigation = navigation;
            this.usuario = usuario;
            this.txtNombre = txtNombre;
            this.txtDNI = txtDNI;
            this.pckHorario = pckHorario;
            this.txtEdad = txtEdad;
            this.txtAltura = txtAltura;
            this.txtPeso = txtPeso;
            this.pckObjetivo = pckObjetivo;
            this.lblStatus = lblStatus;
            this.lstUsuarios = lstUsuarios;
        }

        public async Task RellenarPickersAsync()
        {
            pckHorario.ItemsSource = await App.Horarios_Repository.GetHorarios();
            pckObjetivo.ItemsSource = await App.Objetivos_Repository.GetObjetivos();
        }

        public async Task Aniadir_Usuario()
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtDNI.Text) || String.IsNullOrEmpty(txtEdad.Text) || String.IsNullOrEmpty(txtAltura.Text) || String.IsNullOrEmpty(txtPeso.Text) || pckHorario.SelectedIndex == -1 || pckObjetivo.SelectedIndex == -1)
            {
                lblStatus.Text = "Por favor, revise los datos.";
            }
            else if (txtDNI.Text.Length!=9)
            {
                lblStatus.Text = "Por favor, revise los datos.";
            }
            else if (String.IsNullOrEmpty((await Usuarios_Repository.ExisteNombre(txtNombre.Text)).Nombre))
            {
                lblStatus.Text = "El usuario ya existe.";
            }
            else
            {
                lblStatus.Text = "";

                await App.Usuarios_Repository.Add_Item(txtNombre.Text, txtDNI.Text, txtDNI.Text, pckHorario.SelectedIndex, txtEdad.Text, txtAltura.Text, txtPeso.Text, pckObjetivo.SelectedIndex);

                RellenarListaAsync();
            }
        }

        public async Task RellenarListaAsync()
        {
            lstUsuarios.ItemsSource = await App.Usuarios_Repository.GetAllItems();
        }

        public void Cerrar_Sesion()
        {
            navigation.PushModalAsync(new Login_View());
        }
    }
}
