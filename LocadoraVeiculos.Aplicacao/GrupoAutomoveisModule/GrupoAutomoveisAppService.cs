using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule
{
    public class GrupoAutomoveisAppService
    {
        private readonly IGrupoAutomoveisRepository grupoRepository;

        public GrupoAutomoveisAppService(IGrupoAutomoveisRepository grupoAutomoveisRepository)
        {
            this.grupoRepository = grupoAutomoveisRepository;
        }

        public string InserirNovo(GrupoAutomoveis grupoAutomoveis)
        {
            string resultadoValidacao = grupoAutomoveis.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                grupoRepository.InserirNovo(grupoAutomoveis);

            return resultadoValidacao;
        }

        public string Editar(int id, GrupoAutomoveis grupoAutomoveis)
        {
            string resultadoValidacao = grupoAutomoveis.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                grupoRepository.Editar(id, grupoAutomoveis);

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            if (grupoRepository.Excluir(id))
                return true;

            return false;
        }

        public GrupoAutomoveis SelecionarPorId(int id)
        {
            return grupoRepository.SelecionarPorId(id);
        }

        public List<GrupoAutomoveis> SelecionarTodos()
        {
            return (List<GrupoAutomoveis>)grupoRepository.SelecionarTodos();
        }

        public List<GrupoAutomoveis> Pesquisar(string texto)
        {
            return (List<GrupoAutomoveis>)grupoRepository.Pesquisar(texto);
        }
    }
}
