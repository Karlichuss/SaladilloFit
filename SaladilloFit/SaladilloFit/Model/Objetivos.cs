using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Model
{
    [Table("Objetivos")]
    public class Objetivos
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(20), Column("Objetivo")]
        public String Objetivo { get; set; }
    }
}
