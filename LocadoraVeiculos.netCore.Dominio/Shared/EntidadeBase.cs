using System;

namespace LocadoraVeiculos.netCore.Dominio.Shared
{
    public abstract class EntidadeBase
    {
        protected int id;

        public int Id { get; set; }

        public abstract string Validar();

        protected string QuebraDeLinha(string resultadoValidacao)
        {
            string quebraDeLinha = "";

            if (string.IsNullOrEmpty(resultadoValidacao) == false)
                quebraDeLinha = Environment.NewLine;

            return quebraDeLinha;
        }
    }
}
