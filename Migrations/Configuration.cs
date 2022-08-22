namespace MVP_ASP.Migrations
{
    using MVP_ASP.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVP_ASP.Models.MVP_ASPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVP_ASP.Models.MVP_ASPContext context)
        {
            context.Contras.AddOrUpdate(c => c.Id,  
                new Contras() { Con_Admin = "Admin1", Con_Mast = "Mast1" },
                new Contras() { Con_Admin = "Admin2", Con_Mast = "Mast2" }
                );
            context.Direccion.AddOrUpdate(d => d.Id,
                new Direccion() { DirLocal = "Mexico", Correo = "ejemplo1@gmail.com" },
                new Direccion() { DirLocal = "Puebla", Correo = "ejemplo2@gmail.com" }
                );
            context.Empleados.AddOrUpdate(d => d.Id,
                new Empleados() { Nombre = "Alberto", Apellido = "Mendez", Telefono = "5515907866", Email = "alb.mend@gmail.com", Rol = "Cargador", Sede = "S/N" },
                new Empleados() { Nombre = "Alberto", Apellido = "Mendez", Telefono = "5515907866", Email = "alb.mend@gmail.com", Rol = "Cargador", Sede = "S/N" }
                );
            context.Folios.AddOrUpdate(f => f.Id,
                new Folios() { Id = 1, noFolio = "1234" },
                new Folios() { Id = 2, noFolio = "5678" }
                );      
            context.Inventario.AddOrUpdate(i => i.Id,
                new Inventario() { Id = 1, Producto = "Papas", Clave = "S4BRI7", Presentacion = "Papas con sal.", Precio = 10, MU = 0, Cantidad = 10, StockMin = 5, IVA = 16, Proveedores = "Sabritas" },
                new Inventario() { Id = 2, Producto = "Refresco", Clave = "C0C4R3", Presentacion = "Deliciosa coca-cola", Precio = 20, MU = 0, Cantidad = 30, StockMin = 10, IVA = 16, Proveedores = "Coca-Cola" }
                );
            context.Prod_Prov.AddOrUpdate(pp => pp.Id,
                new Prod_Prov() { Id = 1, cProv = "Prov 1", cProd = "Prod 1" },
                new Prod_Prov() { Id = 2, cProv = "Prov 2", cProd = "Prod 2" }
                );
            context.Provedores.AddOrUpdate(p => p.Id,
                new Provedores() { Id = 1, Clave = "PRO1", Provedor = "Bonafont", Correo = "agua@bonafont.com", Telefono = 5516890677 },
                new Provedores() { Id = 2, Clave = "PRO2", Provedor = "Bonafont", Correo = "agua@bonafont.com", Telefono = 5589702334 }
                );
            context.Proveedores.AddOrUpdate(pee => pee.Id,
                new Proveedores() { Id = 1, Clave = "PROVEE1", Proveedor = "Bonafont", Tel = 5516890677, Correo = "agua@bonafont.com" },
                new Proveedores() { Id = 2, Clave = "PROVEE2", Proveedor = "Bonafont", Tel = 5516890677,  Correo = "agua@bonafont.com" }
                );
            context.Vendedores.AddOrUpdate(v => v.Id,
                new Vendedores() { Id = 1, claveVendedor = "EMPL1", Nombre = "Empleado 1", Puesto = "Repartidor", Salario = 5000 },
                new Vendedores() { Id = 2, claveVendedor = "EMPL2", Nombre = "Empleado 2", Puesto = "Distribuidor", Salario = 8000 }
                );
            context.Ventas.AddOrUpdate(ve => ve.Id,
                new Ventas() { Id = 1, Vendedor = "Vendedor 1", FolioAsociado = "3M9LE1" },
                new Ventas() { Id = 2, Vendedor = "Vendedor 2", FolioAsociado = "3M9L32" }
                );
        }

        
    }
}
