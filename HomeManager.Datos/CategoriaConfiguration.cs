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
    class CategoriaConfiguration: EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(c => c.Id)
               .HasColumnName("CategoriaId");

            Property(c => c.Nombre)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Categorias_Nombre") { IsUnique = true }));
        }
    }
    
}
