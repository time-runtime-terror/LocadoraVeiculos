using LocadoraVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Controladores.Shared
{
    public abstract class Controlador<T> where T : EntidadeBase
    {
        public abstract string InserirNovo(T registro);
        public abstract string Editar(int id, T registro);
        public abstract bool Existe(int id);
        public abstract bool Excluir(int id);
        public abstract List<T> SelecionarTodos();

        public abstract T SelecionarPorId(int id);

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }



    }
}
