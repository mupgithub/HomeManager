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
    public class DetalleFacturaConfiguration: EntityTypeConfiguration<DetalleFactura>
    {
        public DetalleFacturaConfiguration()
        {
            Property(df => df.ProductoId)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_DetalleFactura", 2) { IsUnique = true }));

            Property(df => df.FacturaId)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_DetalleFactura", 1) { IsUnique = true }));
            
            Property(df => df.Precio).HasPrecision(18, 2).IsRequired();

            HasRequired(df => df.Factura).WithMany(f => f.DetalleFactura).WillCascadeOnDelete(false);
        }
    }
}
