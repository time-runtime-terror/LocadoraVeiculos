﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraVeiculos.Dominio.CombustivelModule;
using FluentAssertions;

namespace LocadoraVeiculos.Tests.CombustivelModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class CombustivelTest
    {
        [TestMethod]
        public void DeveValidarGasolina()
        {
            //arrange
            var combustivel = new Combustivel(3, 4, 5, 6);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarGasolina()
        {
            //arrange
            var combustivel = new Combustivel(-1, 4, 5, 6);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("\nO campo Gasolina não pode ser menor que 0");
        }

        [TestMethod]
        public void DeveValidarEtanol()
        {
            //arrange
            var combustivel = new Combustivel(3, 4.7, 5, 6);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarEtanol()
        {
            //arrange
            var combustivel = new Combustivel(3, 0, 5, 6);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("\nO campo Etanol não pode ser 0");
        }

        [TestMethod]
        public void DeveValidarDiesel()
        {
            //arrange
            var combustivel = new Combustivel(3, 5, 5, 6);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarDiesel()
        {
            //arrange
            var combustivel = new Combustivel(3, 5, 0, 6);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("\nO campo Diesel não pode ser 0");
        }

        [TestMethod]
        public void DeveValidarGnv()
        {
            //arrange
            var combustivel = new Combustivel(3, 5, 5, 6);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void NaoDeveValidarGnv()
        {
            //arrange
            var combustivel = new Combustivel(3, 5, 5, -3);

            //action
            var resultadoValidacao = combustivel.Validar();

            //assert
            resultadoValidacao.Should().Be("\nO campo Gnv não pode ser menor que 0");
        }

        [TestMethod]
        public void NaoDeveValidarTodosOsCampos()
        {
            //arrange
            var combustivel = new Combustivel(-3, 0, 0, -3);

            //action
            var resultadoValidacao = combustivel.Validar();

            var resultadoEsperado =
                "\nO campo Gasolina não pode ser menor que 0"
                + "\nO campo Etanol não pode ser 0"
                + "\nO campo Diesel não pode ser 0"
                + "\nO campo Gnv não pode ser menor que 0";

            //assert
            resultadoValidacao.Should().Be(resultadoEsperado);
        }


    }
}