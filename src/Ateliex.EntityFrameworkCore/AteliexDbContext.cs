using Ateliex.Modules.Cadastro.Modelos;
using Ateliex.Modules.Decisoes;
using Ateliex.Modules.Decisoes.Comerciais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;

namespace Ateliex
{
    public class AteliexDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<PlanoComercial> PlanosComerciais { get; set; }

        public AteliexDbContext()
        {

        }

        public AteliexDbContext(DbContextOptions<AteliexDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder
            //    //.UseLazyLoadingProxies()
            //    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Comum.

            ////modelBuilder.Entity<Pessoa>()
            ////    .OwnsOne(p => p.Endereco);

            ////modelBuilder.Entity<PessoaJuridica>()
            ////    .OwnsOne(p => p.InformacoesBancarias);

            //modelBuilder.Entity<Pessoa>()
            //    .OwnsMany(p => p.ContatosDeTelefone);

            //modelBuilder.Entity<ContatoDeTelefone>()
            //    .HasKey(p => p.Id);

            //modelBuilder.Entity<ContatoDeTelefone>()
            //    .OwnsOne(p => p.Telefone);

            //modelBuilder.Entity<Pessoa>()
            //    .OwnsMany(p => p.ContatosDeEmail);

            //modelBuilder.Entity<ContatoDeEmail>()
            //    .HasKey(p => p.Id);

            //modelBuilder.Entity<ContatoDeEmail>()
            //    .OwnsOne(p => p.Email);

            //modelBuilder.Entity<Unidade>()
            //    .HasKey(p => p.Sigla);

            //// Cadastro - Unidades.

            //// Cadastro - Cores.

            ////modelBuilder.Entity<CorInterna>()
            ////    .HasKey(p => p.Codigo);

            //// Cadastro - Materiais - Fabricantes.

            ////modelBuilder.Entity<CorDeFabricante>()
            ////    .HasKey(p => new { p.FabricanteId, p.ComponenteId, p.CatalogoNome, p.Codigo });

            ////modelBuilder.Entity<CorDeFabricante>()
            ////    .Property(p => p.CustoPadrao)
            ////    .HasColumnType("DECIMAL (18, 2)");

            ////modelBuilder.Entity<CorDeFabricante>()
            ////    .HasOne(p => p.CorDeUsoInterno)
            ////    .WithMany()
            ////    .HasForeignKey(p => p.CorDeUsoInternoCodigo);

            ////modelBuilder.Entity<CorDeFabricante>()
            ////    .HasOne(p => p.Catalogo)
            ////    .WithMany(p => p.Cores)
            ////    .HasForeignKey(p => new { p.FabricanteId, p.ComponenteId, p.CatalogoNome })
            ////    .IsRequired();

            //modelBuilder.Entity<FabricacaoDeComponente>()
            //    .HasKey(p => new { p.FabricanteId, p.ComponenteId });

            //modelBuilder.Entity<FabricacaoDeComponente>()
            //    .HasOne(p => p.Componente)
            //    .WithMany(p => p.Fabricantes)
            //    .HasForeignKey(p => p.ComponenteId);

            //modelBuilder.Entity<FabricacaoDeComponente>()
            //    .HasOne(p => p.Fabricante)
            //    .WithMany(p => p.ComponentesFabricados)
            //    .HasForeignKey(p => p.FabricanteId);

            ////modelBuilder.Entity<Catalogo>()
            ////    .HasKey(p => new { p.FabricanteId, p.ComponenteId, p.Nome });

            ////modelBuilder.Entity<Catalogo>()
            ////    .HasMany(p => p.Cores)
            ////    .WithOne(p => p.Catalogo)
            ////    .HasForeignKey(p => new { p.FabricanteId, p.ComponenteId, p.CatalogoNome })
            ////    .IsRequired();

            ////modelBuilder.Entity<DisponibilidadeDeEmbalagem>()
            ////    .HasKey(p => new { p.FabricanteId, p.ComponenteId, p.CatalogoNome, p.EmbalagemNome });

            ////modelBuilder.Entity<DisponibilidadeDeEmbalagem>()
            ////    .OwnsOne(p => p.Embalagem);

            //// Cadastro - Materiais - Fornecedores.

            //modelBuilder.Entity<FornecimentoDeMaterial>()
            //    .HasKey(p => new { p.FornecedorId, p.MaterialId });

            ////modelBuilder.Entity<FornecimentoDeMaterial>()
            ////    .OwnsOne(p => p.TamanhoMinimoPorPedido);

            //modelBuilder.Entity<FornecimentoDeMaterial>()
            //    .Property(p => p.UltimoPreco)
            //    .HasColumnType("DECIMAL (18, 2)");

            //modelBuilder.Entity<DisponibilidadeDeMeioDePagamento>()
            //    .HasKey(p => new { p.FornecedorId, p.MeioDePagamentoId });

            //// Cadastro - Materiais - Fornecedores.

            ////modelBuilder.Entity<Material>()
            ////    .OwnsOne(p => p.Embalagem);

            //modelBuilder.Entity<Material>()
            //    .Property(p => p.CustoPadrao)
            //    .HasColumnType("DECIMAL (18, 2)");

            ////

            //modelBuilder.Entity<AplicacaoDeInvestimento>()
            //    .HasKey(p => new { p.ModeloCodigo, p.InvestimentoId });

            modelBuilder.Entity<Modelo>()
                .HasKey(p => p.Codigo);

            modelBuilder.Entity<Modelo>()
                .Property(p => p.Codigo)
                .ValueGeneratedNever();

            modelBuilder.Entity<Modelo>()
                .Ignore(p => p.Id);

            modelBuilder.Entity<Modelo>()
                .Property(p => p.Version).IsRowVersion();

            modelBuilder.Entity<Recurso>()
                .HasKey(p => new { p.ModeloCodigo, p.Id });

            modelBuilder.Entity<Recurso>()
                .Property(p => p.Version).IsRowVersion();

            //modelBuilder.Entity<TamanhoDeModelo>()
            //    .HasKey(p => p.Sigla);

            //modelBuilder.Entity<NecessidadeDeFerramentaDeProducao>()
            //    .HasKey(p => new { p.EtapaDeProducaoId, p.FerramentaId });

            //modelBuilder.Entity<NecessidadeDeMaterial>()
            //    .HasKey(p => new { p.ModeloCodigo, p.MaterialId });

            //modelBuilder.Entity<NecessidadeDeTipoDeRecurso>()
            //    .HasKey(p => new { p.EtapaId, p.TipoDeRecursoId });

            modelBuilder.Entity<PlanoComercial>()
                .HasKey(p => p.Codigo);

            modelBuilder.Entity<PlanoComercial>()
                .Property(p => p.Codigo)
                .ValueGeneratedNever();

            //modelBuilder.Entity<ItemDePlanoComercial>()
            //    .OwnsOne(p => p.CustoDeProducao);

            modelBuilder.Entity<Custo>()
                .HasKey(p => new { p.PlanoComercialCodigo, p.Id, p.Descricao });

            modelBuilder.Entity<ItemDePlanoComercial>()
                .HasKey(p => new { p.PlanoComercialCodigo, p.ModeloCodigo });

            //


            // Seed.


            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { Codigo = "TM01", Nome = "Tati Model 01" },
                new Modelo { Codigo = "TM02", Nome = "Tati Model 02" },
                new Modelo { Codigo = "TM03", Nome = "Tati Model 03" },
                new Modelo { Codigo = "TM04", Nome = "Tati Model 04" },
                new Modelo { Codigo = "TM05", Nome = "Tati Model 05" },
                new Modelo { Codigo = "TM06", Nome = "Tati Model 06" },
                new Modelo { Codigo = "TM07", Nome = "Tati Model 07" },
                new Modelo { Codigo = "TM08", Nome = "Tati Model 08" },
                new Modelo { Codigo = "TM09", Nome = "Tati Model 09" },
                new Modelo { Codigo = "TM10", Nome = "Tati Model 10" },
                new Modelo { Codigo = "TM11", Nome = "Tati Model 11" },
                new Modelo { Codigo = "TM12", Nome = "Tati Model 12" }
            );

            modelBuilder.Entity<Recurso>().HasData(
                new Recurso { ModeloCodigo = "TM01", Id = 1, Tipo = TipoDeRecurso.Material, Descricao = "Tecido", Custo = 20, Unidades = 2 },
                new Recurso { ModeloCodigo = "TM01", Id = 2, Tipo = TipoDeRecurso.Material, Descricao = "Linha", Custo = 4, Unidades = 20 },
                new Recurso { ModeloCodigo = "TM01", Id = 3, Tipo = TipoDeRecurso.Material, Descricao = "Outros", Custo = 5, Unidades = 1 },
                new Recurso { ModeloCodigo = "TM01", Id = 4, Tipo = TipoDeRecurso.Transporte, Descricao = "Transporte", Custo = 100, Unidades = 50 },
                new Recurso { ModeloCodigo = "TM01", Id = 5, Tipo = TipoDeRecurso.Humano, Descricao = "Costureira", Custo = 5, Unidades = 1 }
            );

            modelBuilder.Entity<PlanoComercial>().HasData(
                new PlanoComercial { Codigo = "PC01.A", Nome = "Normal", RendaBrutaMensal = 6000 },
                new PlanoComercial { Codigo = "PC01.B", Nome = "Moderado" },
                new PlanoComercial { Codigo = "PC01.C", Nome = "Ousado" }
            );

            modelBuilder.Entity<Custo>().HasData(
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 1, Tipo = TipoDeCusto.Fixo, Descricao = "Prolabore", Valor = 1000 },
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 2, Tipo = TipoDeCusto.Fixo, Descricao = "Aluguel", Valor = 900 },
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 3, Tipo = TipoDeCusto.Variavel, Descricao = "Cartão", Percentual = 10 },
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 4, Tipo = TipoDeCusto.Variavel, Descricao = "Comissão", Percentual = 10 },
                new Custo { PlanoComercialCodigo = "PC01.A", Id = 5, Tipo = TipoDeCusto.Variavel, Descricao = "Perda", Percentual = 2 }
            );

            modelBuilder.Entity<ItemDePlanoComercial>().HasData(
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM01", MargemPercentual = 1.93m },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM02" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM03" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM10" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM01" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM02" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM03" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM04" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM05" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM06" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM07" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM08" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM09" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM10" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM05" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM06" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM07" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM08" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM09" },
                new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM10" }
           );
        }

        private IDbContextTransaction transaction;

        public void BeginTransaction()
        {
            transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();

            transaction.Dispose();

            transaction = null;
        }

        public void Rollback()
        {
            transaction.Rollback();

            transaction.Dispose();

            transaction = null;
        }
    }
}
