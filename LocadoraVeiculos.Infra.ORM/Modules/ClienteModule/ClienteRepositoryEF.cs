using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.ClienteModule
{
    public class ClienteRepositoryEF : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly LocadoraDbContext _dbContext;
        private readonly DbSet<Cliente> _dbSet;

        public ClienteRepositoryEF(LocadoraDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Cliente>();
        }

        public override Cliente SelecionarPorId(int id)
        {
            try
            {
                return _dbSet
                    .Where(x => x.Id == id)
                    .Include(e => e.Empresa)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<Cliente> SelecionarTodos()
        {
            try
            {
                return _dbSet
                    .OrderBy(x => x.Id)
                    .Include(e => e.Empresa)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarStatusLocacaoAtiva(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> SelecionarTodasPessoasFisicas()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> SelecionarTodasPessoasJuridicas()
        {
            throw new NotImplementedException();
        }
    }
}
