using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.FuncionarioModule
{
    public class FuncionarioRepositoryEF : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Funcionario> _dbSet;

        public FuncionarioRepositoryEF(LocadoraDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Funcionario>();
        }

        public Dictionary<string, object> AdicionarParametroFuncionario(string campoUsuario, object valorUsuario, string campoSenha, object valorSenha)
        {
            throw new NotImplementedException();
        }

        public bool ExisteFuncionario(string usuario, string senha)
        {
            try
            {
                return _dbSet.Where(x => x.NomeUsuario == usuario && x.Senha == senha).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
