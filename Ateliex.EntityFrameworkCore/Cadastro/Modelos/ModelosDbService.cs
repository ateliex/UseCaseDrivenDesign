using Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ateliex.Cadastro.Modelos
{
    public class ModelosDbService : IConsultaDeModelos, IRepositorioDeModelos
    {
        private readonly AteliexDbContext db;

        public ModelosDbService(AteliexDbContext db)
        {
            this.db = db;
        }

        public ResultadoDaConsultaDeModelos ConsultaModelos(ParametrosDeConsultaDeModelos parametros)
        {
            try
            {
                var itens = db.Modelos
                    .Include(p => p.Recursos)
                    .Select(p => new ItemDeConsultaDeModelos
                    {

                        Codigo = p.Codigo,
                        Nome = p.Nome
                    })
                    .ToArray();

                var resposta = new ResultadoDaConsultaDeModelos
                {
                    Itens = itens
                };

                return resposta;
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

        public Modelo ObtemModelo(CodigoDeModelo codigo)
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

                throw new ApplicationException($"Erro ao adicionar modelo '{modelo.Codigo}'.", ex);
            }
        }

        public void Update(Modelo modelo)
        {
            try
            {
                db.SaveChangesAsync();
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

                db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // TODO: Tratar erros de persistência aqui.

                throw new ApplicationException($"Erro ao excluir modelo '{modelo.Codigo}'.", ex);
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
