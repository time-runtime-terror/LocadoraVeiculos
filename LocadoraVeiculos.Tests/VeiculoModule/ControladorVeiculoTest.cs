﻿using FluentAssertions;
using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Tests.VeiculoModule
{
    [TestClass]
    [TestCategory("Controladores")]

    public class ControladorVeiculoTest
    {
        ControladorVeiculo controlador = null;
        byte[] imagem = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

    public ControladorVeiculoTest()
        {
            controlador = new ControladorVeiculo();
            Db.Update("DELETE FROM [TBVEICULO]");
        }

        [TestMethod]
        public void DeveInserir_Veiculo()
        {
            //arrange
            Veiculo novoVeiculo = new Veiculo(imagem, "ABC-1234", "Vectra", "Chevrolet", "Comum", "70L", "2000km", "Economico");

            //action
            controlador.InserirNovo(novoVeiculo);

            //assert
            Veiculo veiculoEncontrado = controlador.SelecionarPorId(novoVeiculo.Id);
            veiculoEncontrado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveEditar_UmVeiculo()
        {
            //arrange
            Veiculo veiculo = new Veiculo(imagem, "ABC-1234", "Vectra", "Chevrolet", "Comum", "70L", "2000km", "Economico");
            controlador.InserirNovo(veiculo);

            Veiculo novoVeiculo = new Veiculo(imagem, "ABC-1234", "Gol", "Volkswagen", "Comum", "70L", "3200km", "Economico");

            //action
            controlador.Editar(veiculo.Id, novoVeiculo);

            //assert
            Veiculo veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveExcluir_UmVeiculo()
        {
            //arrange            
            Veiculo veiculo = new Veiculo(imagem, "ABC-1234", "Vectra", "Chevrolet", "Comum", "70L", "2000km", "Economico");
            controlador.InserirNovo(veiculo);

            //action            
            controlador.Excluir(veiculo.Id);

            //assert
            Veiculo veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);
            veiculoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Veiculo_PorId()
        {
            //arrange
            Veiculo veiculo = new Veiculo(imagem, "ABC-1234", "Vectra", "Chevrolet", "Comum", "70L", "2000km", "Economico");
            controlador.InserirNovo(veiculo);

            //action
            Veiculo veiculoEncontrado = controlador.SelecionarPorId(veiculo.Id);

            //assert
            veiculoEncontrado.Should().Be(veiculo);
        }

    }
}
