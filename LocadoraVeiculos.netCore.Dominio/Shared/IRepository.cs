using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.netCore.Dominio.Shared
{
    public interface IRepository<T> where T : EntidadeBase
    {
        void InserirNovo(T registro);

        void Editar(int id, T registro);

        bool Excluir(int id);

        bool Existe(int id);

        T SelecionarPorId(int id);

        List<T> SelecionarTodos();

        List<T> Pesquisar(string texto);

        Dictionary<string, object> ObtemParametrosRegistro(T registro);

        T ConverterEmRegistro(IDataReader reader);
    }
}
