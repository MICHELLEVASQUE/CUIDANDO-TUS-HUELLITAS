using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Loginproyectvet
{
    [Table("Registros")]
   public class Registro
    {
        [PrimaryKey, AutoIncrement]
        [SQLite.Column("id")]
        public int Id { get; set; }

        [SQLite.Column("NombrePropietario")]
        public string? NombrePropietario { get; set; }

        [SQLite.Column("Direccion")]
        public string? Direccion { get; set; }

        [SQLite.Column("Telefono")]
        public string? Telefono { get; set; }

        [SQLite.Column("DUI")]
        public string? DUI { get; set; }


        [Column("MascotaNombre")]

        public string? MascotaNombre { get; set; }

        [Column("Especie")]

        public string? Especie { get; set; }

        [Column("Edad")]
        public string? Edad { get; set; }

        [Column("Raza")]
        public string? Raza { get; set; }

        [Column("MF")]
        public string? MF { get; set; }
    }
}
