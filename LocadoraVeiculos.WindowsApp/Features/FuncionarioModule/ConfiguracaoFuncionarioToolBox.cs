using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Features.FuncionarioModule
{
    public class ConfiguracaoFuncionarioToolBox : IConfiguracaoToolBox
    {

        public string TipoCadastro
        {
            get { return "Cadastro de Funcionario"; }
        }

        public string ToolTipAdicionar 
        {
            get { return "Adicionar um novo Funcionario"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Funcionario existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Funcionario existente"; }
        }

        public string ToolTipFiltrar
        {
            get { return "Indisponivel"; }
        }

        public string ToolTipAgrupar
        {
            get { return "Indisponivel"; }
        }

        public string ToolTipDesagrupar
        {
            get { return "Indisponivel"; }
        }

        /// <summary>
        /// Setando estados dos botoes
        /// </summary>

        public bool BarraPesquisa => true;

        public bool BotaoAdicionar
        {
            get { return true; }
        }

        public bool BotaoDevolucao
        {
            get { return true; }
        }

        public bool BotaoEditar
        {
            get { return true; }
        }

        public bool BotaoExcluir
        {
            get { return true; }
        }

        public bool BotaoFiltrar
        {
            get { return false; }
        }

        public bool BotaoAgrupar
        {
            get { return false; }
        }
        public bool BotaoDesagrupar
        {
            get { return false; }
        }
    }
}
