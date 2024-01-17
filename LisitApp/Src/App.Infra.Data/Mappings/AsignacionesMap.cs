using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings
{
    public class AsignacionesMap : IEntityTypeConfiguration<Asignaciones>
    {
        public void Configure(EntityTypeBuilder<Asignaciones> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.IdUsuario).HasColumnName("IdUsuario").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.IdUsuario).HasColumnName("IdUsuario").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.FechaAsignacion).HasColumnName("FechaAsignacion").HasColumnType("DateTime").IsRequired();
        }
    }
}
