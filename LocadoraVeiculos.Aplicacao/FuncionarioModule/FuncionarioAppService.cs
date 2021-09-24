using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using log4net;
using System;
using System.Reflection;

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
            try
            {
                return funcionarioRepository.ExisteFuncionario(usuario, senha);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
            
        }
    }
}
