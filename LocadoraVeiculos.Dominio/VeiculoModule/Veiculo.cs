using System;
using LocadoraVeiculos.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.VeiculoModule
{
    public class Veiculo : EntidadeBase, IEquatable<Veiculo>
    {
        public Veiculo(byte[] foto, string placa, string modelo, string marca, string tipoCombustivel, string capacidadeTanque, string quilometragem, string tipoVeiculo)
        {
            Foto = foto;
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            TipoCombustivel = tipoCombustivel;
            CapacidadeTanque = capacidadeTanque;
            Quilometragem = quilometragem;
            TipoVeiculo = tipoVeiculo;
        }

        public byte[] Foto { get; }
        public string Placa { get; }
        public string Modelo { get; }
        public string Marca { get; }
        public string TipoCombustivel { get; }
        public string CapacidadeTanque { get; }
        public string Quilometragem { get; }
        public string TipoVeiculo { get; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Veiculo);
        }

        public bool Equals(Veiculo obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   EqualityComparer<byte[]>.Default.Equals(Foto, veiculo.Foto) &&
                   Placa == veiculo.Placa &&
                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   Quilometragem == veiculo.Quilometragem &&
                   TipoVeiculo == veiculo.TipoVeiculo;
        }

        public override int GetHashCode()
        {
            int hashCode = -877309296;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(Foto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Placa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Modelo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Marca);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TipoCombustivel);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CapacidadeTanque);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Quilometragem);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TipoVeiculo);
            return hashCode;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Placa))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Placa é obrigatório";

            if (string.IsNullOrEmpty(Modelo))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Modelo é obrigatório";

            if (string.IsNullOrEmpty(Marca))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Marca é obrigatório";

            if (string.IsNullOrEmpty(TipoCombustivel))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Tipo do Combustivel é obrigatório";

            if (string.IsNullOrEmpty(CapacidadeTanque))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Capacidade do Tanque é obrigatório";

            if (string.IsNullOrEmpty(Quilometragem))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometragem é obrigatório";

            if (string.IsNullOrEmpty(TipoVeiculo))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Tipo do Veiculo é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
