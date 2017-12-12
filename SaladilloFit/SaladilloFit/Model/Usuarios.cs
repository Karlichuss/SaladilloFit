using SQLite;
using System;

namespace SaladilloFit.Model
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [PrimaryKey, MaxLength(9), Column("DNI"), NotNull]
        public String DNI { get; set; }
        [MaxLength(20), Column("Nombre"), NotNull]
        public String Nombre { get; set; }
        [MaxLength(9), Column("Password"), NotNull]
        public String Password { get; set; }
        [Column("Horario")]
        public int Horario { get; set; }
        [Column("Edad")]
        public int Edad { get; set; }
        [Column("Altura")]
        public int Altura { get; set; }
        [Column("Peso")]
        public float Peso { get; set; }
        [Column("IMC")]
        public float IMC { get; set; }
        [Column("Objetivo")]
        public int Objetivo { get; set; }
        [MaxLength(7), Column("Tipo")]
        public String Tipo { get; set; }

        public float CalcularIMC()
        {
            return float.Parse((Peso/Math.Pow(Altura/100, 2)).ToString());
        }
    }
}
