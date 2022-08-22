using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVP_ASP.Models
{
    public class MVP_ASPContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVP_ASPContext() : base("name=MVP_ASPContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Inventario> Inventario { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Provedores> Provedores { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Vendedores> Vendedores { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Contras> Contras { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Direccion> Direccion { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Folios> Folios { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Prod_Prov> Prod_Prov { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Proveedores> Proveedores { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Ventas> Ventas { get; set; }

        public System.Data.Entity.DbSet<MVP_ASP.Models.Empleados> Empleados { get; set; }
    }
}
