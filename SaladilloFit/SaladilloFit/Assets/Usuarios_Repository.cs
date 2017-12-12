using SaladilloFit.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Assets
{
    public class Usuarios_Repository
    {
        #region Declaracion de variables

        private SQLiteAsyncConnection conn;
        private String StatusMessage;

        public const string TIPO_GERENTE = "GERENTE";
        public const string TIPO_USUARIO = "USUARIO";

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor. Realiza el enlace de la base de datos con el modelo y crea la tabla. 
        /// </summary>
        /// <param name="dbPath">La ruta de la base de datos.</param>
        public Usuarios_Repository(string dbPath)
        {
            // Inicializamos el SQLiteconnection.
            conn = new SQLiteAsyncConnection(dbPath);
            // Creamos la tabla Usuarios.
            // Para que la ejecucion no siga y se espere a que esté creada la tabla ponemos el wait
            conn.CreateTableAsync<Usuarios>().Wait();
        }

        #endregion

        #region Add

        /// <summary>
        /// Añade un nuevo elemento en la tabla.
        /// </summary>
        /// <param name="DNI">El nombre del elemento a añadir</param>
        /// <param name="Nombre">El precio del elemento a añadir</param>
        /// <param name="Password">El precio del elemento a añadir</param>
        /// <param name="Tipo">El precio del elemento a añadir</param>

        /// <returns></returns>
        public async Task Add_Item(String DNI, String Nombre, String Password)
        {
            int result = 0;
            try
            {
                //Comprobamos que el nombre y el precio sean validos.
                if (string.IsNullOrEmpty(DNI) || string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Password))
                {
                    throw new Exception("Valid values required");
                }
                // Introducimos el nuevo usuario.
                result = await conn.InsertAsync(new Usuarios { DNI = DNI, Nombre = Nombre, Password = Password, Tipo = TIPO_USUARIO });

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
        }

        #endregion

        #region Select

        /// <summary>
        /// Obtiene de la tabla todos los usuarios.
        /// </summary>
        /// <returns>Una colección de todos los elementos que se encuentren en la tabla.</returns>
        public async Task<List<Usuarios>> GetAllItems()
        {
            List<Usuarios> lst = new List<Usuarios>();
            try
            {
                lst = await conn.Table<Usuarios>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return lst;
        }

        /// <summary>
        /// Obtiene el usuario de la base de datos con el DNI pasado por parámetro, si es que existe.
        /// </summary>
        /// <param name="DNI">Id del elemento a comprobar.</param>
        /// <returns>El mismo usuario, o null si no existe.</returns>
        public static async Task<Usuarios> GetUsuario(String DNI)
        {
            Usuarios usuario;

            ObservableCollection<Usuarios> usuarios = new ObservableCollection<Usuarios>(await App.Usuarios_Repository.GetAllItems());
            usuario = usuarios.SingleOrDefault(p => p.DNI == DNI);

            return usuario;
        }

        #endregion
    }
}
