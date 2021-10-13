using LocadoraVeiculos.Infra.ORM.Modules.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Modules.VeiculoModule
{
    public class VeiculoRepositoryEF : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepositoryEF(LocadoraDbContext dbContext) : base(dbContext)
        {

        }

        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public void AtualizarStatusAluguel(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }
    }
}
