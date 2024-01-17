using App.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Mappings
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.Nombre).HasColumnName("Nombre").HasColumnType("varchar").IsRequired();
        }
    }
}
