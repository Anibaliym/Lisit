using App.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Mappings
{
    public class ComunaMap : IEntityTypeConfiguration<Comuna>
    {
        public void Configure(EntityTypeBuilder<Comuna> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.IdRegion).HasColumnName("IdRegion").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.Nombre).HasColumnName("Nombre").HasColumnType("varchar").IsRequired();
        }
    }
}
