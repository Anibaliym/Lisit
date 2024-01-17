using App.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Mappings
{
    public class AyudasSocialesMap : IEntityTypeConfiguration<AyudasSociales>
    {
        public void Configure(EntityTypeBuilder<AyudasSociales> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.IdComuna).HasColumnName("IdComuna").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.Descripcion).HasColumnName("Descripcion").HasColumnType("varchar").IsRequired();
            builder.Property(c => c.Anio).HasColumnName("Anio").HasColumnType("int").IsRequired();
        }
    }
}
