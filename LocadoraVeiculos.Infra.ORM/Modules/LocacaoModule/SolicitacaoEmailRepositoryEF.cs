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
    public class SolicitacaoEmailRepositoryEF : BaseRepository<SolicitacaoEmail>, ISolicitacaoEmailRepository
    {
        private readonly LocadoraDbContext _dbContext;
        private readonly DbSet<SolicitacaoEmail> _dbSet;

        public SolicitacaoEmailRepositoryEF(LocadoraDbContext db) : base(db)
        {
            _dbContext = db;
            _dbSet = _dbContext.Emails;
        }

        public override SolicitacaoEmail SelecionarPorId(int id)
        {
            try
            {
                return _dbContext.Emails
                        .Include(s => s.Locacao)
                        .ThenInclude(l => l.Cliente)
                        .AsSplitQuery()
                        .FirstOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SolicitacaoEmail> SelecionarTodasSolicitacoesPendentes()
        {
            return _dbSet
                .Where(s => s.EnvioPendente == true)
                .Include(s => s.Locacao)
                .ThenInclude(l => l.Cliente)
                .OrderBy(x => x.Id)
                .ToList();
        }
    }
}
