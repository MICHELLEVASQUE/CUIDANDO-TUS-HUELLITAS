using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginproyectvet
{
    [Table("CompraProductos")]
    public class CompraProductos
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("Producto")]
        public string Producto { get; set; }

        [Column("Precio")]
        public double Precio { get; set; }

        [Column("Cantidad")]
        public string Cantidad { get; set; }

        [Column("Total")]
        public double Total { get; set; }

        [Column("NumCuenta")]
        public string NumCuenta { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }

        [Column("Telefono")]
        public string Telefono { get; set; }
    }
}
