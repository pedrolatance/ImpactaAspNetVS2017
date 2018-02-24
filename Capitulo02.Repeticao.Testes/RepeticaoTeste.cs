using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo02.Repeticao.Testes
{
    [TestClass]
    public class RepeticaoTeste
    {
        [TestMethod]
        public void ForAninhadoTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
                Console.WriteLine(new string('-', 50));
            }
        }

        [TestMethod]
        public void EstruturaForTeste()
        {
            int i = 1;
            for (Console.WriteLine("Iniciou"); i <= 3; Console.WriteLine(i))
            {
                i++;
            }

            /*
                 for( inicialização; critério de execução; pós-execução)
                 {
                    execução;
                 }
            */
        }

        [TestMethod]
        public void ForApenasComCondicaoTeste()
        {
            var i = 1;

            for (; i <= 3;)
            {
                Console.WriteLine(i++);
            }
        }

        [TestMethod]
        public void ContinueTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i <= 5)
                {
                    //A função "continue" pula para o proximo incremento
                    continue;
                }

                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void BreakTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i > 5)
                {
                    //A função "break" interrompe o laço for.
                    break;
                }

                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void WhileTeste()
        {
            var i = 1;

            while (i <= 10)
            {
                Console.WriteLine(i++);
            }
        }

        [TestMethod]
        public void DoWhileTeste()
        {
            do
            {
                Console.WriteLine("Entrou");
            } while (1 == 2);
        }
    }
}
