using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVP_ASP.Models
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Proveedor { get; set; }
        public double Tel { get; set; }
        public string Correo { get; set; }
    }
}