using SaladilloFit.Assets;
using SaladilloFit.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SaladilloFit
{
    public partial class App : Application
    {
        public static Usuarios_Repository Usuarios_Repository;
        public static Horarios_Repository Horarios_Repository;
        public static Objetivos_Repository Objetivos_Repository;

        public App(String filename)
        {
            InitializeComponent();

            Usuarios_Repository = new Usuarios_Repository(filename);
            Horarios_Repository = new Horarios_Repository(filename);
            Objetivos_Repository = new Objetivos_Repository(filename);

            MainPage = new Login_View();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
