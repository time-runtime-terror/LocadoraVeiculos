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
    public class FuncionarioRepositoryEF : BaseRepository<FuncionarioEntity>, IFuncionarioRepositoryEntity
    {

        public FuncionarioRepositoryEF(FuncionarioDbContext dbContext) : base(dbContext)
        {

        }
    }
}
