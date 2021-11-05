using LocadoraVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Features.VeiculoModule;
using System.Collections.Generic;
using System.Windows.Forms;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
using log4net;
using System.Reflection;
using System;
using Serilog;
using System.Diagnostics;
using LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule;

namespace LocadoraVeiculos.WindowsApp.Feature.VeiculoModule
{
    public class OperacoesVeiculos : ICadastravel
    {
        private readonly VeiculoAppService veiculosService = null;
        private readonly GrupoAutomoveisAppService grupoAutoService;
        private readonly TabelaVeiculosControl tabelaVeiculo = null;

        public OperacoesVeiculos(VeiculoAppService veiculosAppService, GrupoAutomoveisAppService grupoAutomoveisService)
        {
            veiculosService = veiculosAppService;
            grupoAutoService = grupoAutomoveisService;
            tabelaVeiculo = new TabelaVeiculosControl(veiculosAppService);
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarVeiculos tela = new TelaCadastrarVeiculos(grupoAutoService);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Log.Information("Inserindo veiculo...");
                Stopwatch watch = Stopwatch.StartNew();

                veiculosService.InserirNovo(tela.Veiculo);

                //List<Veiculo> veiculos = veiculosService.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Veículo: [{tela.Veiculo.Modelo}] inserido com sucesso");

                watch.Stop();

                Log.Information("Veiculo: [{idVeiculo}] inserido com sucesso! ({Ms}ms)", tela.Veiculo.Id, watch.ElapsedMilliseconds);
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();            

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder editar!", "Edição de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Veiculo veiculoSelecionado = veiculosService.SelecionarPorId(id);

            TelaCadastrarVeiculos tela = new TelaCadastrarVeiculos(grupoAutoService);

            tela.Veiculo = veiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Log.Information("Editando veiculo...");

                Stopwatch watch = Stopwatch.StartNew();

                veiculosService.Editar(id, tela.Veiculo);

                tabelaVeiculo.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Veículo: [{tela.Veiculo.Modelo}] editado com sucesso");

                watch.Stop();

                Log.Information("Veiculo: [{idVeiculo}] editado com sucesso! ({Ms}ms)", tela.Veiculo.Id, watch.ElapsedMilliseconds);

            }
           
        }

        public void ExcluirRegistro()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder excluir!", "Exclusão de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }   Veiculo veiculoSelecionado = veiculosService.SelecionarPorId(id);

            if (veiculoSelecionado.EstaAlugado)
            {
                Dashboard.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionado.Modelo}] não pôde ser excluído pois está alugado!");
                return;
            }

            if (MessageBox.Show($"Tem certeza que deseja excluir o Veiculo: [{veiculoSelecionado.Id}] ?",
                "Exclusão de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Log.Information("Excluindo veiculo...");

                Stopwatch watch = Stopwatch.StartNew();

                veiculosService.Excluir(id);

                List<Veiculo> veiculos = veiculosService.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionado.Modelo}] removido com sucesso");

                watch.Stop();

                Log.Information("Veiculo: [{idVeiculo}] excluido com sucesso! ({Ms}ms)", id, watch.ElapsedMilliseconds);

            }
            
        }

        public UserControl ObterTabela()
        {
            List<Veiculo> veiculos = veiculosService.SelecionarTodos();

            tabelaVeiculo.AtualizarRegistros();            

            return tabelaVeiculo;
        }

        public void AgruparRegistros()
        {
            AgrupamentoVeiculosForm telaFiltro = new AgrupamentoVeiculosForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                tabelaVeiculo.AgruparVeiculos(telaFiltro.TipoAgrupamento);
            }        
                
        }

        public void DesagruparRegistros()
        {
            tabelaVeiculo.DesagruparVeiculos();          
        }

        public void FiltrarRegistros()
        {
            
        }

        public void Pesquisar(string text)
        {
            List<Veiculo> veiculosEncontrados = veiculosService.Pesquisar(text);

            tabelaVeiculo.AtualizarRegistros(veiculosEncontrados);
        }
    }
}
