using LocadoraVeiculos.netCore.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.CupomModule
{
    public interface ICupomRepository : IRepository<Cupom>
    {
        List<Cupom> SelecionarCuponsAtivos(DateTime dataAtual);

        Cupom SelecionarPorId(int id, bool carregarParceiro = false);
    }
}
