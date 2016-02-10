namespace HomeManager.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeticionesUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.LoginUsuario",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.Usuarios", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RolesUsuario",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.Usuarios");
            DropForeignKey("dbo.PeticionesUsuario", "User_Id", "dbo.Usuarios");
            DropForeignKey("dbo.RolesUsuario", "UserId", "dbo.Usuarios");
            DropForeignKey("dbo.RolesUsuario", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.LoginUsuario", "UserId", "dbo.Usuarios");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.PeticionesUsuario", new[] { "User_Id" });
            DropIndex("dbo.RolesUsuario", new[] { "UserId" });
            DropIndex("dbo.RolesUsuario", new[] { "RoleId" });
            DropIndex("dbo.LoginUsuario", new[] { "UserId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.RolesUsuario");
            DropTable("dbo.LoginUsuario");
            DropTable("dbo.PeticionesUsuario");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Roles");
        }
    }
}
