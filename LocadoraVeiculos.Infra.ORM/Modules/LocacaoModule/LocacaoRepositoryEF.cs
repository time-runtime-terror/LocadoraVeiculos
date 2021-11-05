using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.LocacaoModule
{
    public class LocacaoRepositoryEF : BaseRepository<Locacao>, ILocacaoRepository
    {
        private readonly LocadoraDbContext _dbContext;
        private readonly DbSet<Locacao> _dbSet;

        public LocacaoRepositoryEF(LocadoraDbContext db) : base(db)
        {
            _dbContext = db;
            _dbSet = _dbContext.Locacoes;
        }

        public override void Editar(int id, Locacao locacaoAlterada)
        {
            try
            {
                Locacao locacaoParaAlterar = _dbSet.SingleOrDefault(x => x.Id.Equals(id));

                //if (locacaoParaAlterar != null && _dbContext.Entry(locacaoParaAlterar).State != EntityState.Modified)
                //    _dbContext.Entry(locacaoParaAlterar).State = EntityState.Detached;

                locacaoAlterada.Id = id;

                _dbContext.Entry(locacaoParaAlterar).CurrentValues.SetValues(locacaoAlterada);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Locacao SelecionarPorId(int id)
        {
            try
            {
                return _dbContext.Locacoes
                        .Include(l => l.Cliente)
                        .Include(l => l.Veiculo)
                        .ThenInclude(v => v.GrupoAutomoveis)
                        .Include(l => l.Taxas)
                        .AsSplitQuery()
                        .FirstOrDefault(l => l.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<Locacao> SelecionarTodos()
        {
            try
            {
                return _dbSet
                    .Include(l => l.Cliente)
                    .Include(l => l.Veiculo)
                    .Include(l => l.Taxas)
                    .OrderBy(x => x.Id)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegistrarDevolucao(Locacao registro)
        {
            try
            {
                _dbContext.Attach(registro).State = EntityState.Modified;

                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            return _dbSet
                .Where(l => l.Devolucao != "Pendente")
                .Include(t => t.Taxas)
                .AsSplitQuery()
                .Include(v => v.Veiculo)
                .Include(c => c.Cliente)
                .ToList();
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
                return _dbSet
               .Where(l => l.Devolucao == "Pendente")
               .Include(t => t.Taxas)
               .AsSplitQuery()
               .Include(v => v.Veiculo)
               .AsSplitQuery()
               .Include(c => c.Cliente)
               .AsSplitQuery()
               .ToList();
              
        }
    }
}
