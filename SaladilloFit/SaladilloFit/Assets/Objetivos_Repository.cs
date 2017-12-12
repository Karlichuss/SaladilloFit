using SaladilloFit.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Assets
{
    public class Objetivos_Repository
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
        public Objetivos_Repository(string dbPath)
        {
            // Inicializamos el SQLiteconnection.
            conn = new SQLiteAsyncConnection(dbPath);
            // Creamos la tabla Objetivos.
            // Para que la ejecucion no siga y se espere a que esté creada la tabla ponemos el wait
            conn.CreateTableAsync<Objetivos>().Wait();
        }

        internal static Objetivos GetItem(int objetivo)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Select

        #endregion
    }
}
