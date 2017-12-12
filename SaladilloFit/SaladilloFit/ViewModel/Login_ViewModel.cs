using SaladilloFit.Assets;
using SaladilloFit.Model;
using SaladilloFit.View;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaladilloFit.ViewModel
{
    public class Login_ViewModel
    {
        #region Declaracion de variables

        Page Page;
        INavigation Navigation;
        Entry txtUsuario;
        Entry txtContrasenia;
        Label lblStatus;

        Usuarios Usuario;

        #endregion

        #region Constructores

        public Login_ViewModel(Page Page, INavigation Navigation, Entry txtUsuario, Entry txtContrasenia, Label lblStatus)
        {
            this.Page = Page;
            this.Navigation = Navigation;
            this.txtUsuario = txtUsuario;
            this.txtContrasenia = txtContrasenia;
            this.lblStatus = lblStatus;
        }

        #endregion

        #region Metodos

        public async Task Iniciar_SesionAsync()
        {
            // Primero comprobamos que el usuario no ha dejado algún campo vacío.
            if (string.IsNullOrEmpty(txtUsuario.Text.ToString()) || string.IsNullOrEmpty(txtContrasenia.Text.ToString()))
            {
                lblStatus.Text = "Debe introducir Usuario y Contraseña (9 caracteres)";
            }
            else if (txtUsuario.Text.Length != 9)
            {
                lblStatus.Text = "Debe introducir usuario (9 caracteres)";
            }
            else if (txtContrasenia.Text.Length != 9)
            {
                lblStatus.Text = "Debe introducir contraseña (9 caracteres)";
            }
            else
            {
                Usuario = await Usuarios_Repository.GetUsuario(txtUsuario.Text);

                // Luego se comprueba si el usuario existe en la base de datos.
                if (String.IsNullOrEmpty(Usuario.Nombre))
                {
                    lblStatus.Text = "El usuario no esta dado de alta.";
                }
                else
                {
                    // Luego comprobamos si la contraseña introducida es correcta.
                    if (Usuario.Password != txtContrasenia.Text)
                    {
                        lblStatus.Text = "Contraseña incorrecta.";
                    }
                    else
                    {
                        // Si es cliente inicia la sesión de usuario
                        if (Usuario.Tipo == Usuarios_Repository.TIPO_USUARIO)
                        {
                            Usuario_View Usuario_View = new Usuario_View(Usuario);
                            await Navigation.PushModalAsync(Usuario_View);
                        }

                        // Si no, inicia la sesión de gerente
                        else
                        {
                            //Gerente_View Gerente_View = new Gerente_View(Usuario);
                            //await Navigation.PushModalAsync(Gerente_View);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Impide que al campo de texto pasado por parámetro se le pueda meter mas de maxCaracteres.
        /// </summary>
        /// <param name="maxCaracteres">Numero maximo de caracteres permitidos.</param>
        /// <param name="txt">El campo de texto a controlar.</param>
        public void ImpedirMaxCaracteres(int maxCaracteres, Entry txt)
        {
            if (txt.Text.Length > maxCaracteres)
            {
                txt.Text = txt.Text.Substring(0, maxCaracteres);
            }
        }

        #endregion



    }
}
