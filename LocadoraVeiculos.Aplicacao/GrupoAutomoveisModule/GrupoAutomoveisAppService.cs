using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using System;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule
{
    public class GrupoAutomoveisAppService : BaseAppService<GrupoAutomoveis>
    {
        private readonly IGrupoAutomoveisRepository grupoRepository;

        public GrupoAutomoveisAppService(IGrupoAutomoveisRepository grupoAutomoveisRepository)
            : base(grupoAutomoveisRepository)
        {
            this.grupoRepository = grupoAutomoveisRepository;
        }

        public override string InserirNovo(GrupoAutomoveis grupoAutomoveis)
        {
            string resultadoValidacao = grupoAutomoveis.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    grupoRepository.InserirNovo(grupoAutomoveis);
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Falha ao tentar registrar grupo de automóveis");
                }
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, GrupoAutomoveis registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    grupoRepository.Editar(id, registro);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Falha ao tentar editar grupo de automóveis");
                }
            }
            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                if (grupoRepository.Excluir(id))
                    return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir grupo de automóveis");
            }

            return false;
        }
    }
}
