using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVP_ASP.Models
{
    public class Vendedores
    {
        public int Id { get; set; }
        public string claveVendedor { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public double Salario { get; set; }
    }
}