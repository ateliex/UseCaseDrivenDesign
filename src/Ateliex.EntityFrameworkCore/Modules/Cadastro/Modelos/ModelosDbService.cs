﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ateliex.Modules.Cadastro.Modelos
{
    public class ModelosDbService : IConsultaDeModelos, IRepositorioDeModelos
    {
        private readonly AteliexDbContext db;

        public ModelosDbService(AteliexDbContext db)
        {
            this.db = db;
        }

        public async Task<Modelo[]> ConsultaModelos(SolicitacaoDeConsultaDeModelos solicitacao)
        {
            try
            {
                var modelos = await db.Modelos
                    .Include(p => p.Recursos)
                    .ToArrayAsync();

                return modelos;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException("Erro ao consultar modelos.", ex);
            }
        }

        public Modelo[] ObtemModelos()
        {
            try
            {
                var modelos = db.Modelos
                    .Include(p => p.Recursos)
                    .ToArray();

                return modelos;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException("Erro ao obter modelos.", ex);
            }
        }

        public async Task<Modelo> ObtemModelo(CodigoDeModelo codigo)
        {
            try
            {
                var modelo = await db.Modelos
                    .Include(p => p.Recursos)
                    .FirstOrDefaultAsync(p => p.CodigoDeModelo == codigo.Valor);

                if (modelo == default(Modelo))
                {
                    throw new ApplicationException();
                }

                return modelo;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter modelo '{codigo.Valor}'.", ex);
            }
        }

        public Modelo ObtemModeloParaEdicao(CodigoDeModelo codigo)
        {
            try
            {
                var modelo = db.Modelos.Find(codigo.Valor);

                return modelo;
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao obter modelo '{codigo.Valor}'.", ex);
            }
        }

        public void Add(Modelo modelo)
        {
            try
            {
                db.Modelos.Add(modelo);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao adicionar modelo '{modelo.CodigoDeModelo}'.", ex);
            }
        }

        public void Update(Modelo modelo)
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

        public void Remove(Modelo modelo)
        {
            try
            {
                db.Modelos.Remove(modelo);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao excluir modelo '{modelo.CodigoDeModelo}'.", ex);
            }
        }

        public void SaveChanges()
        {
            var items = db.ChangeTracker.Entries<Recurso>().ToArray();

            foreach (var item in items)
            {
                item.State.ToString();
            }

            db.SaveChanges();
        }
    }
}
