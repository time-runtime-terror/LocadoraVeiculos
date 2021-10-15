using System;
using LocadoraVeiculos.netCore.Dominio.Shared;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using System.Drawing;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;

namespace LocadoraVeiculos.netCore.Dominio.VeiculoModule
{
    public class Veiculo : EntidadeBase, IEquatable<Veiculo>
    {

        public Veiculo() { }

        public Veiculo(byte[] foto, string placa, string modelo, string marca, string tipoCombustivel, int capacidadeTanque, int quilometragem, GrupoAutomoveis grupo)
        {
            Foto = foto;
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            TipoCombustivel = tipoCombustivel;
            CapacidadeTanque = capacidadeTanque;
            Quilometragem = quilometragem;
            GrupoAutomoveis = grupo;
        }

        public Bitmap Imagem
        {
            get
            {
                if (GrupoAutomoveis == null)
                    return null;

                using (var ms = new MemoryStream(Foto))
                {
                    return new Bitmap(ms);
                }
            }
        }

        public byte[] Foto { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string TipoCombustivel { get; set; }
        public int CapacidadeTanque { get; set; }
        public int Quilometragem { get; set;  }
        public GrupoAutomoveis GrupoAutomoveis { get; set; }
        public int? IdGrupoAutomoveis { get; set; }
        public bool EstaAlugado { get; set; }
        public List<Locacao> Locacoes { get; set; } = new List<Locacao>();

        public string NomeGrupo 
        {
            get
            {
                if (GrupoAutomoveis == null)
                   return  "Sem Categoria";

                return GrupoAutomoveis.NomeGrupo;
            }
        }

        public override string ToString()
        {
            return $"{Modelo} {Placa}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Veiculo);
        }

        public bool Equals(Veiculo obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   Foto.SequenceEqual(veiculo.Foto) &&
                   Placa == veiculo.Placa &&
                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   Quilometragem == veiculo.Quilometragem &&
                   EqualityComparer<GrupoAutomoveis>.Default.Equals(GrupoAutomoveis, veiculo.GrupoAutomoveis) &&
                   NomeGrupo == veiculo.NomeGrupo;
        }

        public override int GetHashCode()
        {
            int hashCode = -1944787682;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Bitmap>.Default.GetHashCode(Imagem);
            hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(Foto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Placa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Modelo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Marca);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TipoCombustivel);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(CapacidadeTanque);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Quilometragem);
            hashCode = hashCode * -1521134295 + EqualityComparer<GrupoAutomoveis>.Default.GetHashCode(GrupoAutomoveis);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomeGrupo);
            return hashCode;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Placa))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Placa é obrigatório";

            if (Foto == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Foto é obrigatório";

            if (string.IsNullOrEmpty(Modelo))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Modelo é obrigatório";

            if (string.IsNullOrEmpty(Marca))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Marca é obrigatório";

            if (string.IsNullOrEmpty(TipoCombustivel))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Por favor selecione um combustível";


            if (CapacidadeTanque == 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Capacidade do Tanque é obrigatório";

            if (Quilometragem == 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometragem é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
