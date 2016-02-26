using HomeManager.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Datos
{
    public class ProveedorConfiguration: EntityTypeConfiguration<Proveedor>
    {
        public ProveedorConfiguration()
        {
            ToTable("Proveedores");
            Property(p => p.Nombre)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Proveedor_Nombre") {IsUnique = true}));

            Property(p => p.Direccion).HasMaxLength(100).IsRequired();
            Property(p => p.Ciudad).HasMaxLength(30).IsRequired();
            Property(p => p.CodigoPostal).HasMaxLength(10).IsRequired();
            Property(p => p.Telefono).HasMaxLength(15).IsOptional();
           
        }

    }
}
