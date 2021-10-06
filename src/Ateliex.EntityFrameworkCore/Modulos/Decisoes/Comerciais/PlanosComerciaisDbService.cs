using Ateliex.Modulos.Decisoes.Comerciais.ConsultaDePlanosComerciais;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ateliex.Modulos.Decisoes.Comerciais
{
    public class PlanosComerciaisDbService : IConsultaDePlanosComerciais, IRepositorioDePlanosComerciais
    {
        private readonly AteliexDbContext db;

        public PlanosComerciaisDbService(AteliexDbContext db)
        {
            this.db = db;
        }

        public PlanoComercial[] ConsultaPlanosComerciais(SolicitacaoDeConsultaDePlanosComerciais solicitacao)
        {
            try
            {
                var planosComerciais = db.PlanosComerciais
                    .Include(p => p.Custos)
                    .Include(p => p.Itens)
                        .ThenInclude(p => p.Modelo)
                            .ThenInclude(p => p.Recursos)
                    .ToArray();

                return planosComerciais;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException("Erro ao consultar modelos.", ex);
            }
        }

        public PlanoComercial ObtemPlanoComercial(string id)
        {
            try
            {
                var planoComercial = db.PlanosComerciais.Find(id);

                return planoComercial;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter planoComercial '{id}'.", ex);
            }
        }

        public PlanoComercial[] ObtemObservavelDePlanosComerciais()
        {
            try
            {
                var planosComerciais = db.PlanosComerciais
                    .Include(p => p.Custos)
                    .Include(p => p.Itens)
                        .ThenInclude(p => p.Modelo)
                            .ThenInclude(p => p.Recursos)
                    .ToArray();

                //var observable = planosComerciais.ToObservable();

                return planosComerciais;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException("Erro em Planos Comerciais.", ex);
            }
        }

        public void Add(PlanoComercial planoComercial)
        {
            try
            {
                db.PlanosComerciais.AddAsync(planoComercial);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao adicionar planoComercial '{planoComercial.Codigo}'.", ex);
            }
        }

        public void Update(PlanoComercial planoComercial)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException();
            }
        }

        public void Remove(PlanoComercial planoComercial)
        {
            try
            {
                db.PlanosComerciais.Remove(planoComercial);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao excluir planoComercial '{planoComercial.Codigo}'.", ex);
            }
        }

        public void SaveChanges()
        {
            var items = db.ChangeTracker.Entries<ItemDePlanoComercial>().ToArray();

            foreach (var item in items)
            {
                item.State.ToString();
            }

            db.SaveChanges();
        }
    }
}
