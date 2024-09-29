using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Loginproyectvet
{
    [Table("Registros")]
    public partial class Donar

    {

        [PrimaryKey, AutoIncrement]
        [SQLite.Column("id")]
        public int Id { get; set; }

        [SQLite.Column("NombreFundacion ")]



        public string NombreFundacion { get; set; }

        [SQLite.Column("Direccion")]
        public string Direccion { get; set; }

        [SQLite.Column("CuentaActual")]
        public string CuentaActual { get; set; }

        [SQLite.Column("DUI")]
        public string DUI { get; set; }


        [Column("NumeroCuenta")]

        public string NumeroCuenta { get; set; }

        [Column("Cantidad")]

        public string Cantidad { get; set; }


    }
}
