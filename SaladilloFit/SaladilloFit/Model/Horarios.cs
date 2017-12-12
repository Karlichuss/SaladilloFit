using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Model
{
    [Table("Horarios")]
    public class Horarios
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(15), Column("Horario")]
        public String Horario { get; set; }
    }
}
