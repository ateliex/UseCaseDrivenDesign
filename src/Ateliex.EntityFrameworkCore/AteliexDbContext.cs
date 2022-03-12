using Ateliex.Modules.Cadastro.Modelos;
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AteliexDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            // Seed.

            // modelBuilder.Entity<Modelo>().HasData(
            //     new Modelo { CodigoDeModelo = "TM01", Nome = "Tati Model 01" },
            //     new Modelo { CodigoDeModelo = "TM02", Nome = "Tati Model 02" },
            //     new Modelo { CodigoDeModelo = "TM03", Nome = "Tati Model 03" },
            //     new Modelo { CodigoDeModelo = "TM04", Nome = "Tati Model 04" },
            //     new Modelo { CodigoDeModelo = "TM05", Nome = "Tati Model 05" },
            //     new Modelo { CodigoDeModelo = "TM06", Nome = "Tati Model 06" },
            //     new Modelo { CodigoDeModelo = "TM07", Nome = "Tati Model 07" },
            //     new Modelo { CodigoDeModelo = "TM08", Nome = "Tati Model 08" },
            //     new Modelo { CodigoDeModelo = "TM09", Nome = "Tati Model 09" },
            //     new Modelo { CodigoDeModelo = "TM10", Nome = "Tati Model 10" },
            //     new Modelo { CodigoDeModelo = "TM11", Nome = "Tati Model 11" },
            //     new Modelo { CodigoDeModelo = "TM12", Nome = "Tati Model 12" }
            // );

            // modelBuilder.Entity<Recurso>().HasData(
            //     new Recurso { CodigoDeModelo = "TM01", Id = 1, Tipo = TipoDeRecurso.Material, Descricao = "Tecido", Custo = 20, Unidades = 2 },
            //     new Recurso { CodigoDeModelo = "TM01", Id = 2, Tipo = TipoDeRecurso.Material, Descricao = "Linha", Custo = 4, Unidades = 20 },
            //     new Recurso { CodigoDeModelo = "TM01", Id = 3, Tipo = TipoDeRecurso.Material, Descricao = "Outros", Custo = 5, Unidades = 1 },
            //     new Recurso { CodigoDeModelo = "TM01", Id = 4, Tipo = TipoDeRecurso.Transporte, Descricao = "Transporte", Custo = 100, Unidades = 50 },
            //     new Recurso { CodigoDeModelo = "TM01", Id = 5, Tipo = TipoDeRecurso.Humano, Descricao = "Costureira", Custo = 5, Unidades = 1 }
            // );

            // modelBuilder.Entity<PlanoComercial>().HasData(
            //     new PlanoComercial { Codigo = "PC01.A", Nome = "Normal", RendaBrutaMensal = 6000 },
            //     new PlanoComercial { Codigo = "PC01.B", Nome = "Moderado" },
            //     new PlanoComercial { Codigo = "PC01.C", Nome = "Ousado" }
            // );

            // modelBuilder.Entity<Custo>().HasData(
            //     new Custo { PlanoComercialCodigo = "PC01.A", Id = 1, Tipo = TipoDeCusto.Fixo, Descricao = "Prolabore", Valor = 1000 },
            //     new Custo { PlanoComercialCodigo = "PC01.A", Id = 2, Tipo = TipoDeCusto.Fixo, Descricao = "Aluguel", Valor = 900 },
            //     new Custo { PlanoComercialCodigo = "PC01.A", Id = 3, Tipo = TipoDeCusto.Variavel, Descricao = "Cartão", Percentual = 10 },
            //     new Custo { PlanoComercialCodigo = "PC01.A", Id = 4, Tipo = TipoDeCusto.Variavel, Descricao = "Comissão", Percentual = 10 },
            //     new Custo { PlanoComercialCodigo = "PC01.A", Id = 5, Tipo = TipoDeCusto.Variavel, Descricao = "Perda", Percentual = 2 }
            // );

            // modelBuilder.Entity<ItemDePlanoComercial>().HasData(
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM01", MargemPercentual = 1.93m },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM02" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM03" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.A", ModeloCodigo = "TM10" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM01" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM02" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM03" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM04" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM05" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM06" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM07" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM08" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM09" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.B", ModeloCodigo = "TM10" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM05" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM06" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM07" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM08" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM09" },
            //     new ItemDePlanoComercial { PlanoComercialCodigo = "PC01.C", ModeloCodigo = "TM10" }
            //);
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
