using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService
    {
        private readonly IFuncionarioRepository funcionarioRepository;


        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }



        public string RegistrarNovoFuncionario(Funcionario funcionario)
        {
            string resultadoValidacao = funcionario.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                funcionarioRepository.InserirNovo(funcionario);
            }

            return resultadoValidacao;
        }


        public string Editar(int id, Funcionario funcionario)
        {
            string resultadoValidacao = funcionario.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                funcionarioRepository.Editar(id, funcionario);

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            if (funcionarioRepository.Excluir(id))
                return true;

            return false;
        }

        public List<Funcionario> SelecionarTodos()
        {
            return (List<Funcionario>)funcionarioRepository.SelecionarTodos();
        }

        public Funcionario SelecionarPorId(int id)
        {
            return funcionarioRepository.SelecionarPorId(id);
        }

        public bool ExisteFuncionario(string usuario, string senha)
        {
            return funcionarioRepository.ExisteFuncionario(usuario, senha);
        }

        public List<Funcionario> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
