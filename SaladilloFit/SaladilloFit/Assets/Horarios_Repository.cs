using SaladilloFit.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Assets
{
    public class Horarios_Repository
    {
        #region Declaracion de variables

        private SQLiteAsyncConnection conn;
        private String StatusMessage;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor. Realiza el enlace de la base de datos con el modelo y crea la tabla. 
        /// </summary>
        /// <param name="dbPath">La ruta de la base de datos.</param>
        public Horarios_Repository(string dbPath)
        {
            // Inicializamos el SQLiteconnection.
            conn = new SQLiteAsyncConnection(dbPath);
            // Creamos la tabla Horarios.
            // Para que la ejecucion no siga y se espere a que esté creada la tabla ponemos el wait
            conn.CreateTableAsync<Horarios>().Wait();
        }

        internal static Horarios GetItem(int horario)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Select

        #endregion
    }
}
