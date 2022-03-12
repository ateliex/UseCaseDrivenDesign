using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ateliex.Modules.Decisoes.Comerciais
{
    internal class PlanosComerciaisDbConfiguration :
        IEntityTypeConfiguration<PlanoComercial>,
        IEntityTypeConfiguration<Custo>,
        IEntityTypeConfiguration<ItemDePlanoComercial>
    {
        public void Configure(EntityTypeBuilder<PlanoComercial> builder)
        {
            builder.HasKey(p => p.Codigo);

            builder.Property(p => p.Codigo).ValueGeneratedNever();
        }

        public void Configure(EntityTypeBuilder<Custo> builder)
        {
            builder.HasKey(p => new { p.PlanoComercialCodigo, p.Id, p.Descricao });
        }

        public void Configure(EntityTypeBuilder<ItemDePlanoComercial> builder)
        {
            //builder.OwnsOne(p => p.CustoDeProducao);

            builder.HasKey(p => new { p.PlanoComercialCodigo, p.ModeloCodigo });
        }
    }
}
