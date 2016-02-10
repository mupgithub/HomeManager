using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeManager.Web.Models
{
    public class HomeManagerDbContext: IdentityDbContext<ApplicationUser>
    {
        public HomeManagerDbContext()
                : base("DefaultConnection")
        {
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<IdentityUser>().ToTable("Usuarios").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("LoginUsuario");
            modelBuilder.Entity<IdentityUserRole>().ToTable("RolesUsuario");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("PeticionesUsuario");

        }

    }
}