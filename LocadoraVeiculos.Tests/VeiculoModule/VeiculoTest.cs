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

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoPlaca()
        {
            

            //arrange
            var veiculo = new Veiculo(foto, "", "Vectra", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Placa é obrigatório");
        }

        [TestMethod]
        public void DeveValidarCampoModelo()
        {
            

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoModelo()
        {

           

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Modelo é obrigatório");
        }

        [TestMethod]
        public void DeveValidarCampoMarca()
        {

           
            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoMarca()
        {
            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Marca é obrigatório");
        }

        [TestMethod]
        public void DeveValidarTipoCombustivel()
        {


            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarTipoCombustivel()
        {

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("Por favor selecione um combustível");
        }



        [TestMethod]
        public void DeveValidarCampoCapacidadeTanque()
        {
            

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoCapacidadeTanque()
        {
            

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Capacidade do Tanque é obrigatório");
        }

        [TestMethod]
        public void DeveValidarCampoQuilometragem()
        {
           

            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarCampoQuilometragem()
        {
           
            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "70L", "", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("O campo Quilometragem é obrigatório");
        }

        [TestMethod]
        public void DeveValidarCampoTipoVeiculo()
        {
            
            //arrange
            var veiculo = new Veiculo(foto, "ABC-1234", "Vectra", "Chevrolet", "Gasolina", "70L", "2000km", null);

            //action
            var resultadoValidacao = veiculo.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

    }
}
