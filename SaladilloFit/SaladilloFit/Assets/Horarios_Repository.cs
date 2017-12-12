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

        public async Task<List<Horarios>> GetAllItems()
        {
            List<Horarios> lst = new List<Horarios>();
            try
            {
                lst = await conn.Table<Horarios>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return lst;
        }

        public static async Task<Horarios> GetItem(int id)
        {
            Horarios horario;

            ObservableCollection<Horarios> horarios = new ObservableCollection<Horarios>(await App.Horarios_Repository.GetAllItems());
            horario = horarios.SingleOrDefault(p => p.Id == id);

            return horario;
        }

        #endregion

        #region Select

        #endregion
    }
}
