using LocadoraVeiculos.netCore.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.FuncionarioModule
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
         bool ExisteFuncionario(string usuario, string senha);

        Dictionary<string, object> AdicionarParametroFuncionario(string campoUsuario, object valorUsuario, string campoSenha, object valorSenha);
    }
 
}
