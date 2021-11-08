using LocadoraVeiculos.Aplicacao.ParceiroModule;
using LocadoraVeiculos.Infra.ExtensionMethods;
using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using LocadoraVeiculos.WindowsApp.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.ParceiroModule
{
    public class OperacoesParceiro : ICadastravel
    {
        private readonly ParceiroAppService parceiroAppService = null;
        private readonly TabelaParceiroControl tabelaParceiro = null;


        public OperacoesParceiro(ParceiroAppService parceiroApp)
        {

            parceiroAppService = parceiroApp;
            tabelaParceiro = new TabelaParceiroControl();
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarParceiro tela = new TelaCadastrarParceiro();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                //Log.Information("Inserindo um parceiro");
                Log.Logger.Aqui().FuncionalidadeUsada();
                Stopwatch watch = Stopwatch.StartNew();

                parceiroAppService.InserirNovo(tela.Parceiro);

                List<Parceiro> parceiros = parceiroAppService.SelecionarTodos();

                tabelaParceiro.AtualizarRegistros(parceiros);

                Dashboard.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro.Nome}] inserido com sucesso");

                watch.Stop();

                Log.Information("Parceiro: [{idParceiro}] inserido com sucesso! ({Ms}ms)", tela.Parceiro.Id, watch.ElapsedMilliseconds);
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um parceiro para poder editar!", "Edição de Parceiro",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Parceiro parceiroSelecionado = parceiroAppService.SelecionarPorId(id);


            TelaCadastrarParceiro tela = new TelaCadastrarParceiro();

            tela.Parceiro = parceiroSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                //Log.Information("Editando um parceiro");
                Log.Logger.Aqui().FuncionalidadeUsada();
                Stopwatch watch = Stopwatch.StartNew();

                parceiroAppService.Editar(id, tela.Parceiro);

                List<Parceiro> parceiros = parceiroAppService.SelecionarTodos();

                tabelaParceiro.AtualizarRegistros(parceiros);

                Dashboard.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro.Nome}] editado com sucesso");

                watch.Stop();

                Log.Information("Parceiro: [{idParceiro}] editado com sucesso! ({Ms}ms)", tela.Parceiro.Id, watch.ElapsedMilliseconds);
            }
        }

       

        public void ExcluirRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um parceiro para poder excluir!", "Exclusão de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Parceiro parceiroSelecionado = parceiroAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o parceiro: [{parceiroSelecionado.Nome}] ?",
                "Exclusão de Parceiros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Log.Information("Excluindo Parceiro...");
                Log.Logger.Aqui().FuncionalidadeUsada();
                Stopwatch watch = Stopwatch.StartNew();

                parceiroAppService.Excluir(id);

                List<Parceiro> parceiros = parceiroAppService.SelecionarTodos();

                tabelaParceiro.AtualizarRegistros(parceiros);

                Dashboard.Instancia.AtualizarRodape($"Parceiro: [{parceiroSelecionado.Nome}] removido com sucesso");

                watch.Stop();

                Log.Information("Parceiro: [{idParceiro}] excluido com sucesso! ({Ms}ms)", id, watch.ElapsedMilliseconds);

            }
        }

        public UserControl ObterTabela()
        {
            List<Parceiro> parceiros = parceiroAppService.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(parceiros);


            return tabelaParceiro;
        }

        public void DesagruparRegistros()
        {
            List<Parceiro> parceiros = parceiroAppService.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(parceiros);
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void Pesquisar(string text)
        {
            throw new NotImplementedException();
        }


        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

       

    }
}
