using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVP_ASP.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public string Clave { get; set; }
        public string Presentacion { get; set; }
        public double Precio { get; set; }
        public int MU { get; set; }
        public int Cantidad { get; set; }
        public int StockMin { get; set; }
        public int IVA { get; set; }
        public string Proveedores { get; set; }
    }
}