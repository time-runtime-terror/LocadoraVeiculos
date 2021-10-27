using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface IArmazenadorEmail
    {
        void AgendarEnvioEmail(Email email, string caminho);
    }
}
