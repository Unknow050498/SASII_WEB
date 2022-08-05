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
            context.Inventarios.AddOrUpdate(i => i.Id,
                new Inventario() { Id = 1, Producto = "Papas", Clave = "S4BRI7", Presentacion = "Papas con sal.", Precio = 10, MU = 0, Cantidad = 10, StockMin = 5, IVA = 16, Proveedores = "Sabritas" },
                new Inventario() { Id = 2, Producto = "Refresco", Clave = "C0C4R3", Presentacion = "Deliciosa coca-cola", Precio = 20, MU = 0, Cantidad = 30, StockMin = 10, IVA = 16, Proveedores = "Coca-Cola" }
                );

            context.Provedores.AddOrUpdate(p => p.Id,
                new Provedores() { Id = 1, Clave = "PRO", Provedor = "Bonafont", Correo = "agua@bonafont.com", Telefono = 5516890677 },
                new Provedores() { Id = 2, Clave = "PRO", Provedor = "Bonafont", Correo = "agua@bonafont.com", Telefono = 5589702334 }
                );

            context.Vendedores.AddOrUpdate(v => v.Id,
                new Vendedores() {Id = 1, claveVendedor = "EMPL1", Nombre = "Empleado 1", Puesto = "Repartidor", Salario = 5000 },
                new Vendedores() {Id = 2, claveVendedor = "EMPL2", Nombre = "Empleado 2", Puesto = "Distribuidor", Salario = 8000 }
                );
        }
    }
}
