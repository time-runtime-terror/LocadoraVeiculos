using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.CombustivelModule
{
    public class Combustivel : IEquatable<Combustivel>
    {
        //Devem ser registrados nome, usuário de acesso,
        //senha de acesso, data de entrada na empresa e o salário do funcionário.
        public Combustivel(double gasolina, double etanol, double diesel, double gnv)
        {
            Gasolina = gasolina;
            Etanol = etanol;
            Diesel = diesel;
            Gnv = gnv;  
        }

        public double Gasolina { get; set; }

        public double Etanol { get; set; }

        public double Diesel { get; set; }

        public double Gnv { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Combustivel);
        }

        public bool Equals(Combustivel other)
        {
            return other != null
               && Gasolina == other.Gasolina
               && Etanol == other.Etanol
               && Diesel == other.Diesel
               && Gnv == other.Gnv;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (Gasolina == 0)
            {
                resultadoValidacao = "\nO campo Gasolina não pode ser 0";
            }

            if (Gasolina < 0)
            {
                resultadoValidacao += "\nO campo Gasolina não pode ser menor que 0";
            }

            if (Etanol == 0)
            {
                resultadoValidacao += "\nO campo Etanol não pode ser 0";
            }

            if (Etanol < 0)
            {
                resultadoValidacao += "\nO campo Etanol não pode ser menor que 0";
            }

            if (Diesel == 0)
            {
                resultadoValidacao += "\nO campo Diesel não pode ser 0";
            }

            if (Diesel < 0)
            {
                resultadoValidacao += "\nO campo Diesel não pode ser menor que 0";
            }

            if (Gnv == 0)
            {
                resultadoValidacao += "\nO campo Gnv não pode ser 0";
            }

            if (Gnv < 0)
            {
                resultadoValidacao += "\nO campo Gnv não pode ser menor que 0";
            }

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }


    }
}
