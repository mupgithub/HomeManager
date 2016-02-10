namespace HomeManager.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreadaCapaDeDatos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeticionesUsuario", "User_Id", "dbo.Usuarios");
            DropForeignKey("dbo.LoginUsuario", "UserId", "dbo.Usuarios");
            DropForeignKey("dbo.RolesUsuario", "UserId", "dbo.Usuarios");
            DropIndex("dbo.LoginUsuario", new[] { "UserId" });
            DropIndex("dbo.RolesUsuario", new[] { "UserId" });
            DropIndex("dbo.PeticionesUsuario", new[] { "User_Id" });
            RenameColumn(table: "dbo.PeticionesUsuario", name: "User_Id", newName: "IdentityUser_Id");
            DropPrimaryKey("dbo.LoginUsuario");
            AddColumn("dbo.Usuarios", "Email", c => c.String(maxLength: 256));
            AddColumn("dbo.Usuarios", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "PhoneNumber", c => c.String());
            AddColumn("dbo.Usuarios", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Usuarios", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.PeticionesUsuario", "UserId", c => c.String());
            AddColumn("dbo.LoginUsuario", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.RolesUsuario", "IdentityUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Usuarios", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.PeticionesUsuario", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.LoginUsuario", new[] { "LoginProvider", "ProviderKey", "UserId" });
            CreateIndex("dbo.Roles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.RolesUsuario", "IdentityUser_Id");
            CreateIndex("dbo.Usuarios", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.PeticionesUsuario", "IdentityUser_Id");
            CreateIndex("dbo.LoginUsuario", "IdentityUser_Id");
            AddForeignKey("dbo.PeticionesUsuario", "IdentityUser_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.LoginUsuario", "IdentityUser_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.RolesUsuario", "IdentityUser_Id", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolesUsuario", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.LoginUsuario", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.PeticionesUsuario", "IdentityUser_Id", "dbo.Usuarios");
            DropIndex("dbo.LoginUsuario", new[] { "IdentityUser_Id" });
            DropIndex("dbo.PeticionesUsuario", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Usuarios", "UserNameIndex");
            DropIndex("dbo.RolesUsuario", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropPrimaryKey("dbo.LoginUsuario");
            AlterColumn("dbo.PeticionesUsuario", "IdentityUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Usuarios", "UserName", c => c.String());
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false));
            DropColumn("dbo.RolesUsuario", "IdentityUser_Id");
            DropColumn("dbo.LoginUsuario", "IdentityUser_Id");
            DropColumn("dbo.PeticionesUsuario", "UserId");
            DropColumn("dbo.Usuarios", "AccessFailedCount");
            DropColumn("dbo.Usuarios", "LockoutEnabled");
            DropColumn("dbo.Usuarios", "LockoutEndDateUtc");
            DropColumn("dbo.Usuarios", "TwoFactorEnabled");
            DropColumn("dbo.Usuarios", "PhoneNumberConfirmed");
            DropColumn("dbo.Usuarios", "PhoneNumber");
            DropColumn("dbo.Usuarios", "EmailConfirmed");
            DropColumn("dbo.Usuarios", "Email");
            AddPrimaryKey("dbo.LoginUsuario", new[] { "UserId", "LoginProvider", "ProviderKey" });
            RenameColumn(table: "dbo.PeticionesUsuario", name: "IdentityUser_Id", newName: "User_Id");
            CreateIndex("dbo.PeticionesUsuario", "User_Id");
            CreateIndex("dbo.RolesUsuario", "UserId");
            CreateIndex("dbo.LoginUsuario", "UserId");
            AddForeignKey("dbo.RolesUsuario", "UserId", "dbo.Usuarios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoginUsuario", "UserId", "dbo.Usuarios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeticionesUsuario", "User_Id", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
    }
}
