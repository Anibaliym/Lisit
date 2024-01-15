using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;

namespace App.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("GUID").IsRequired();
            builder.Property(c => c.Rut).HasColumnName("Rut").HasColumnType("varchar").IsRequired();
            builder.Property(c => c.Nombre).HasColumnName("Nombre").HasColumnType("varchar").IsRequired();
            builder.Property(c => c.ApellidoPaterno).HasColumnName("ApellidoPaterno").HasColumnType("varchar").IsRequired();
            builder.Property(c => c.Contrasena).HasColumnName("Contrasena").HasColumnType("varchar").IsRequired();
            builder.Property(c => c.Rol).HasColumnName("Rol").HasColumnType("varchar").IsRequired();
        }
    }
}
