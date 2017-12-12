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

        #endregion

        #region Select

        public async Task<List<Objetivos>> GetAllItems()
        {
            List<Objetivos> lst = new List<Objetivos>();
            try
            {
                lst = await conn.Table<Objetivos>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return lst;
        }

        public static async Task<Objetivos> GetItem(int id)
        {
            Objetivos objetivo;

            ObservableCollection<Objetivos> objetivos = new ObservableCollection<Objetivos>(await App.Objetivos_Repository.GetAllItems());
            objetivo = objetivos.SingleOrDefault(p => p.Id == id);

            return objetivo;
        }

        public async Task<List<String>> GetObjetivos()
        {
            List<Objetivos> lst = new List<Objetivos>();
            List<String> nombres = new List<String>();

            try
            {
                lst = await conn.Table<Objetivos>().ToListAsync();

                foreach(Objetivos o in lst)
                {
                    nombres.Add(o.Objetivo);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return nombres;
        }

        #endregion
    }
}
