using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
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

        public FuncionarioRepositoryEF(LocadoraDbContext dbContext) : base(dbContext)
        {

        }

        public Dictionary<string, object> AdicionarParametroFuncionario(string campoUsuario, object valorUsuario, string campoSenha, object valorSenha)
        {
            throw new NotImplementedException();
        }

        public bool ExisteFuncionario(string usuario, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
