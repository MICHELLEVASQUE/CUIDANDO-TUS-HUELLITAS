using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginproyectvet
{
    [Table("MascotaHospitalizada")]
    public class MascotaHospitalizada
    {

        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("Nombre")]
        public string? Nombre { get; set; }

        [Column("Especie")]
        public string? Especie { get; set; }

        [Column("Raza")]
        public string? Raza { get; set; }

        [Column("Edad")]
        public string? Edad { get; set; }

        [Column("Peso")]
        public string? Peso { get; set; }

        [Column("Propietario")]
        public string? Propietario { get; set; }

        [Column("DUI")]
        public string? DUI { get; set; }

        [Column("Telefono")]
        public string? Telefono { get; set; }


        [Column("EstadoHospitalizacion")]
        public string? EstadoHospitalizacion { get; set; }
    }
}
