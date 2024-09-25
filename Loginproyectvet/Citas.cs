using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginproyectvet
{
    [Table("Cita")]
    public class Citas
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }

        [Column("Telefono")]
        public string Telefono { get; set; }

        [Column("PropietarioNombre")]
        public string PropietarioNombre { get; set; }

        [Column("DUI")]
        public string DUI { get; set; }

        [Column("MascotaNombre")]
        public string MascotaNombre { get; set; }

        [Column("FechaHora")]
        public DateTime FechaHora { get; set; }
    }
}
