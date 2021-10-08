using LocadoraVeiculos.netCore.Dominio.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.Shared
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntidadeBase
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual void InserirNovo(TEntity registro)
        {
            try
            {
                _dbSet.Add(registro);

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
                using (LocadoraDbContext db = new LocadoraDbContext())
                {
                    var idExiste = SelecionarTodos().Where(x => x.Id == id).Any();

                    if(idExiste == true)
                    {
                        registro.Id = id;
                        db.Set<TEntity>().Update(registro);
                        
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool Excluir(int id)
        {
            try
            {
                var registroEncontrado = _dbSet.Find(id);

                if (registroEncontrado != null)
                {
                    _dbSet.Remove(registroEncontrado);

                    _dbContext.SaveChanges();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public virtual TEntity SelecionarPorId(int id)
        {
            try
            {
                return _dbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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
                return _dbSet.AsNoTracking().OrderBy(x => x.Id).ToList();
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
            throw new NotImplementedException();
        }
    }
}
