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
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void InserirNovo(TEntity registro)
        {
            try
            {
                _dbSet.Add(registro);
                //_dbContext.Attach(registro).State = EntityState.Added;

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual void Editar(int id, TEntity registro)
        {
            try
            {
                TEntity registroParaAlterar = _dbSet.SingleOrDefault(x => x.Id.Equals(id));

                if (registroParaAlterar != null && _dbContext.Entry(registroParaAlterar).State != EntityState.Modified)
                    _dbContext.Entry(registroParaAlterar).State = EntityState.Detached;

                registro.Id = id;

                _dbContext.Entry(registroParaAlterar).CurrentValues.SetValues(registro);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
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
            try
            {
                return _dbSet
                    .FirstOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<TEntity> SelecionarTodos()
        {
            try
            {
                return _dbSet
                    .OrderBy(x => x.Id)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
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
