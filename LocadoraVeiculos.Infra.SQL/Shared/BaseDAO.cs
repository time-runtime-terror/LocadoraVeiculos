using System.Collections.Generic;

namespace LocadoraVeiculos.Infra.SQL.Shared
{
    public abstract class BaseDAO
    {
        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
