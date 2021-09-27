using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using log4net;
using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace LocadoraVeiculos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService 
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public string InserirNovo(Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    funcionarioRepository.InserirNovo(registro);
                    //throw new Exception();
                }
                catch (Exception ex)
                {
                    //ver se precisa mudar o resultado da validação, pois ocorreu um erro
                    Log.Error(ex, "Falha ao tentar registrar o funcionário");
                }
            }

            return resultadoValidacao;
        }

        
        public string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    funcionarioRepository.Editar(id, registro);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Falha ao tentar editar funcionário");
                }
            }

           
            return resultadoValidacao;
        }

      
        public bool Excluir(int id)
        {
            try
            {
                if (funcionarioRepository.Excluir(id))
                    return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir um funcionário");
            }

            return false;
        }

        
        public Funcionario SelecionarPorId(int id)
        {
            
            try
            {
                return funcionarioRepository.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return null;
        }

       
        public List<Funcionario> SelecionarTodos()
        {
            
            try
            {
                return funcionarioRepository.SelecionarTodos();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return null;
        }

        public bool ExisteFuncionario(string usuario, string senha)
        {
            try
            {
                return funcionarioRepository.ExisteFuncionario(usuario, senha);

            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);

            }

            return false;
        }

        public List<Funcionario> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }

       
    }
}
