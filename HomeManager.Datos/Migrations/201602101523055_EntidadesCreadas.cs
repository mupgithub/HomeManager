namespace HomeManager.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntidadesCreadas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoriaId)
                .Index(t => t.Nombre, unique: true, name: "AK_Categorias_Nombre");
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 15),
                        Descripcion = c.String(nullable: false, maxLength: 80),
                        UltimoPrecio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .Index(t => t.Codigo, unique: true, name: "AK_Productos_Codigo")
                .Index(t => t.Descripcion, unique: true, name: "AK_Productos_Descripcion")
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FacturaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facturas", t => t.FacturaId)
                .Index(t => new { t.FacturaId, t.ProductoId }, unique: true, name: "AK_DetalleFactura");
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProveedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(maxLength: 15),
                        Ciudad = c.String(nullable: false, maxLength: 30),
                        CodigoPostal = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nombre, unique: true, name: "AK_Proveedor_Nombre");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleFacturas", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Productoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Proveedors", "AK_Proveedor_Nombre");
            DropIndex("dbo.Facturas", new[] { "ProveedorId" });
            DropIndex("dbo.DetalleFacturas", "AK_DetalleFactura");
            DropIndex("dbo.Productoes", new[] { "CategoriaId" });
            DropIndex("dbo.Productoes", "AK_Productos_Descripcion");
            DropIndex("dbo.Productoes", "AK_Productos_Codigo");
            DropIndex("dbo.Categorias", "AK_Categorias_Nombre");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Facturas");
            DropTable("dbo.DetalleFacturas");
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
