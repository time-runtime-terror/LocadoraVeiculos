using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WindowsApp.Features.Funcionário
{
    public class ConfiguracaoFuncionarioToolBox : IConfiguracaoToolBox
    {

        public string TipoCadastro
        {
            get { return "Cadastro de Funcionários"; }
        }

        public string ToolTipAdicionar 
        {
            get { return "Adicionar um novo Funcionário"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Funcionário existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Funcionário existente"; }
        }

        public string ToolTipFiltrar
        {
            get { return ""; }
        }

        public string ToolTipAgrupar
        {
            get { return ""; }
        }

        public string ToolTipDesagrupar
        {
            get { return ""; }
        }

        /// <summary>
        /// Setando estados dos botoes
        /// </summary>

        public bool BotaoAdicionar
        {
            get { return true; }
        }

        public bool BotaoCadastro
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
