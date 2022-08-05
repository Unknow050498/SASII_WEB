using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVP_ASP.Models
{
    public class Provedores
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Provedor { get; set; }
        public string Correo { get; set; }
        public double Telefono { get; set; }
    }
}