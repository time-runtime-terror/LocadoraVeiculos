using LocadoraVeiculos.netCore.Dominio.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.Modules.Shared
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntidadeBase
    {
        public virtual void InserirNovo(TEntity registro)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    db.Set<TEntity>().Add(registro);

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public virtual void Editar(int id, TEntity registro)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    var idExiste = SelecionarTodos().Where(x => x.Id == id).Any();

                    if (idExiste == true)
                    {
                        registro.Id = id;
                        db.Set<TEntity>().Update(registro);

                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public virtual bool Excluir(int id)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    var registroEncontrado = db.Set<TEntity>().Find(id);

                    if (registroEncontrado != null)
                    {
                        db.Set<TEntity>().Remove(registroEncontrado);

                        db.SaveChanges();
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return true;
        }

        public virtual TEntity SelecionarPorId(int id)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    return db.Set<TEntity>()
                        .AsNoTracking()
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public virtual List<TEntity> SelecionarTodos()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    return db.Set<TEntity>()
                        .AsNoTracking()
                        .OrderBy(x => x.Id)
                        .ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public virtual List<TEntity> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }

        public virtual bool Existe(int id)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
                return db.Set<TEntity>().Any(x => x.Id == id);
        }
    }
}
