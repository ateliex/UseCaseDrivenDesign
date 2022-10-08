using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ateliex.Modules.Cadastro.Modelos
{
    public class ModelosDbConfiguration :
        IEntityTypeConfiguration<Modelo>,
        IEntityTypeConfiguration<Recurso>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(p => p.CodigoDeModelo);

            builder.Property(p => p.CodigoDeModelo).HasMaxLength(16).HasColumnName("CodigoDeModelo");

            builder.OwnsOne(p => p.Codigo).Property(p => p.Valor).HasMaxLength(16).HasColumnName("CodigoDeModelo");

            builder.HasMany(a => a.Recursos).WithOne(b => b.Modelo).HasForeignKey(a => a.CodigoDeModelo);

            builder.Property(p => p.Version).IsRowVersion();
        }

        public void Configure(EntityTypeBuilder<Recurso> builder)
        {
            builder.HasKey(p => new { p.CodigoDeModelo, p.Id });

            builder.Property(p => p.Version).IsRowVersion();
        }
    }
}
