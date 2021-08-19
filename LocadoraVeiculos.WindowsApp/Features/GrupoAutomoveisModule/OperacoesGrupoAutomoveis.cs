using LocadoraVeiculos.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule
{
    public class OperacoesGrupoAutomoveis : ICadastravel
    {
        private readonly ControladorGrupoAutomoveis controlador = null;
        private readonly TabelaGrupoAutomoveisControl tabelaGrupoAutomoveis = null;

        public OperacoesGrupoAutomoveis(ControladorGrupoAutomoveis controladorGrupoAutomoveis)
        {
            controlador = controladorGrupoAutomoveis;
            tabelaGrupoAutomoveis = new TabelaGrupoAutomoveisControl(controladorGrupoAutomoveis);
        }

        public void InserirNovoRegistro()
        { 

            TelaCadastroGrupoAutomoveis tela = new TelaCadastroGrupoAutomoveis();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.GrupoAutomoveis);

                tabelaGrupoAutomoveis.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Grupo Automóvel: [{tela.GrupoAutomoveis.NomeGrupo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um grupo de automóveis para editar!!", "Edição de Grupo de Automóveis",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoAutomoveis grupoAutomoveisSelecionado = controlador.SelecionarPorId(id);

            TelaCadastroGrupoAutomoveis tela = new TelaCadastroGrupoAutomoveis();

            tela.GrupoAutomoveis = grupoAutomoveisSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.GrupoAutomoveis);

                tabelaGrupoAutomoveis.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Grupo Automóvel: [{tela.GrupoAutomoveis.NomeGrupo}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um grupo de automóveis para excluir!!", "Exclusão de Grupo de Automóveis",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoAutomoveis grupoAutomoveisSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Grupo de Automóveis: [{grupoAutomoveisSelecionado.NomeGrupo}] ?",
                "Exclusão de Grupo de Automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                tabelaGrupoAutomoveis.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Grupo Automóvel: [{grupoAutomoveisSelecionado.NomeGrupo}] removido com sucesso");
            }
        }

        public void AgruparRegistros()
        {
            TelaAgrupamentoGrupoAutomoveis telaFiltro = new TelaAgrupamentoGrupoAutomoveis();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                tabelaGrupoAutomoveis.AgruparGrupoDeAutomoveis(telaFiltro.TipoAgrupamento);
            }
        }
        public void FiltrarRegistros()
        {
            
        }

        public UserControl ObterTabela()
        {
            tabelaGrupoAutomoveis.AtualizarRegistros();

            return tabelaGrupoAutomoveis;
        }

        public void DesagruparRegistros()
        {
            tabelaGrupoAutomoveis.DesagruparGrupoAutomoveis();
        }

        public void Pesquisar(string text)
        {
            throw new NotImplementedException();
        }
    }
}
