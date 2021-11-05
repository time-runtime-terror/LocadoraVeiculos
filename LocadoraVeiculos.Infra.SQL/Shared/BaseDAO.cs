using LocadoraVeiculos.netCore.Dominio.Shared;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Infra.SQL.Shared
{
    public abstract class BaseDAO<T> where T: EntidadeBase
    {
        public abstract Dictionary<string, object> ObtemParametrosRegistro(T registro);

        public abstract T ConverterEmRegistro(IDataReader reader);

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
