using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;

namespace LocadoraVeiculos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService : BaseAppService<Funcionario>
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository)
            : base(funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public bool ExisteFuncionario(string usuario, string senha)
        {
            return funcionarioRepository.ExisteFuncionario(usuario, senha);
        }
    }
}
