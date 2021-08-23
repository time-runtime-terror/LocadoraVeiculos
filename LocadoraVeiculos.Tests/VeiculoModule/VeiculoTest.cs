using LocadoraVeiculos.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.CombustivelModule;

namespace LocadoraVeiculos.Tests.VeiculoModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class VeiculoTest
    {
        byte[] foto = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        [TestMethod]
        public void DeveValidarCampoPlaca()
        {
            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoPlaca()
        {
            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);

            //arrange
            var veiculo = new Veiculo(foto, "", "Vectra", "Chevrolet", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Placa é obrigatório");
        }

        [TestMethod]
        public void DeveValidarCampoModelo()
        {
            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoModelo()
        {

            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "", "Chevrolet", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Modelo é obrigatório");
        }

        [TestMethod]
        public void DeveValidarCampoMarca()
        {

            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);
            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoMarca()
        {
            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Marca é obrigatório");
        }



        [TestMethod]
        public void DeveValidarCampoCapacidadeTanque()
        {
            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoCapacidadeTanque()
        {
            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", combustivel.Diesel, "", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Capacidade do Tanque é obrigatório");
        }

        [TestMethod]
        public void DeveValidarCampoQuilometragem()
        {
            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoQuilometragem()
        {

            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);
            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", combustivel.Diesel, "70L", "", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Quilometragem é obrigatório");
        }

        [TestMethod]
        public void DeveValidarCampoTipoVeiculo()
        {
            var combustivel = new Combustivel(3.0, 6.0, 8.9, 7.1);
            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", combustivel.Diesel, "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

    }
}
