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
    public class ProductoConfiguration: EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguration()
        {
            ToTable("Productos");
            Property(p => p.Codigo)
               .HasMaxLength(15)
               .IsRequired()
               .HasColumnAnnotation("Index",
                   new IndexAnnotation(new IndexAttribute("AK_Productos_Codigo") { IsUnique = true }));

            Property(p => p.Descripcion)
                .HasMaxLength(80)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Productos_Descripcion") { IsUnique = true }));

            Property(p => p.UltimoPrecio).HasPrecision(18, 2).IsRequired();
            HasRequired(p => p.Categoria).WithMany(c => c.Productos).WillCascadeOnDelete(false);

        }
    }
}
