using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.netCore.Dominio.Shared
{
    public interface IRepository<EntidadeBase>
    {
        void InserirNovo(EntidadeBase registro);

        string Editar(int id, EntidadeBase registro);

        bool Excluir(int id);

        bool Existe(int id);

        EntidadeBase SelecionarPorId(int id);

        IList<EntidadeBase> SelecionarTodos();

        IList<EntidadeBase> Pesquisar(string texto);

        Dictionary<string, object> ObtemParametrosRegistro(EntidadeBase registro);

        EntidadeBase ConverterEmRegistro(IDataReader reader);
    }
}
