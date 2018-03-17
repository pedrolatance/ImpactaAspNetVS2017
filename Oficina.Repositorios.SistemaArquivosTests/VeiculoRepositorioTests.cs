using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {

        [TestMethod()]
        public void InserirTest()
        {
            var repositorio = new VeiculoRepositorio();

            var veiculo = new VeiculoPasseio();

            //veiculo.Id = 1;
            veiculo.Placa = "ABC-1245";
            veiculo.Ano = 2015;
            veiculo.Observacao = "Nada a declarar";
            veiculo.Cambio = Cambio.Manual;
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Cor = new CorRepositorio().Selecionar(1);
            veiculo.Modelo = new ModeloRepositorio().Selecionar(3);
            veiculo.Carroceria = TipoCarroceria.Hatch;

            repositorio.Inserir(veiculo);

            Console.WriteLine(veiculo.ToString());

        }
    }
}