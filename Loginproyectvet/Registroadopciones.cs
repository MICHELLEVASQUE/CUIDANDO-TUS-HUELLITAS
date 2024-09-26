using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginproyectvet
{
    [Table("RegistroAdopciones")]
    public class RegistroAdopciones
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("Salario")]
        public string Salario { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }

        [Column("Telefono")]
        public string Telefono { get; set; }

        [Column("Especie")]
        public string Especie { get; set; }
    }
}
