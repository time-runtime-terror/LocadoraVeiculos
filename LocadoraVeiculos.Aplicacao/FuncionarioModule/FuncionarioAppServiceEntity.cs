using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppServiceEntity : BaseAppServiceEntity<FuncionarioEntity>
    {

        public FuncionarioAppServiceEntity(IFuncionarioRepositoryEntity funcionarioRepository) : base(funcionarioRepository)
        {
        }
    }
}
