using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo04.Colecoes.Testes
{
    [TestClass]
    public class VetorTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            //var strings = new string[10];

            //strings[0] = "String 1";
            //strings[10] = "String 10";


            var decimais = new Decimal[3] {1.7m,0.3m,15 };

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"Tamanho do vetor: {decimais.Length}");

        }


        [TestMethod]
        public void RedimTeste()
        {
            decimal[] decimais = { 1.7m, 0.3m, 15 };

            Array.Resize(ref decimais, 4);

            decimais[3] = 17.2m;
        }


        [TestMethod]
        public void OrdenacaoTeste()
        {
            decimal[] decimais = { 1.7m, 0.3m, 15 };

            Array.Sort(decimais);

            Assert.IsTrue(decimais[0] == 0.3m);
        }

        [TestMethod]
        public void ExecutarMedia()
        {
            Console.WriteLine(CalcMedia(1.7m, 0.3m, 15, 2.5m));
        }


        [TestMethod]
        public void StringsSaoVetoresTeste()
        {
            var nome = "Pedro";

            foreach (var caractere in nome)
            {
                Console.WriteLine(caractere);
            }
        }

        private decimal CalcMedia(decimal valor1, decimal valor2)
        {
            return (valor1 + valor2) / 2;
        }

        private decimal CalcMedia(params decimal[] valores)
        {
            var soma = 0m;

            foreach (var valor in valores)
            {
                soma += valor;
            }
            
            return soma / valores.Length;

        }


    }
}


