using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface INotificadorEmail
    {
        IEnumerable<Email> ObterEmailsAgendados();
        bool EnviarEmailAgendado(Email email);
    }
}
