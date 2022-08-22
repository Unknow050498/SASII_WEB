using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVP_ASP.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Sede { get; set; }
    }
}