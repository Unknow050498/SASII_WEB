namespace MVP_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Con_Admin = c.String(),
                        Con_Mast = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DirLocal = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Folios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        noFolio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Producto = c.String(),
                        Clave = c.String(),
                        Presentacion = c.String(),
                        Precio = c.Double(nullable: false),
                        MU = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        StockMin = c.Int(nullable: false),
                        IVA = c.Int(nullable: false),
                        Proveedores = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prod_Prov",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cProv = c.String(),
                        cProd = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clave = c.String(),
                        Provedor = c.String(),
                        Correo = c.String(),
                        Telefono = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clave = c.String(),
                        Proveedor = c.String(),
                        Tel = c.Double(nullable: false),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        claveVendedor = c.String(),
                        Nombre = c.String(),
                        Puesto = c.String(),
                        Salario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vendedor = c.String(),
                        FolioAsociado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ventas");
            DropTable("dbo.Vendedores");
            DropTable("dbo.Proveedores");
            DropTable("dbo.Provedores");
            DropTable("dbo.Prod_Prov");
            DropTable("dbo.Inventarios");
            DropTable("dbo.Folios");
            DropTable("dbo.Direccions");
            DropTable("dbo.Contras");
        }
    }
}
