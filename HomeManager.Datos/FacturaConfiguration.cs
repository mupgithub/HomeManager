using HomeManager.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Datos
{
    class FacturaConfiguration: EntityTypeConfiguration<Factura>
    {
        public FacturaConfiguration()
        {
            Property(f => f.Fecha).IsRequired();
            Property(f => f.Importe).HasPrecision(18, 2).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            HasRequired(f => f.Proveedor).WithMany(p => p.Facturas).WillCascadeOnDelete(false);
            
        }
    }
}
