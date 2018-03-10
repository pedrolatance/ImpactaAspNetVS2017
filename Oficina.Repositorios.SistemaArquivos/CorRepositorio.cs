using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Oficina.Dominio;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class CorRepositorio
    {
        public List<Cor> Selecionar()
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(@"dados\cor.txt"))
            {

                var cor = new Cor();

                cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);
                
                cores.Add(cor);
    
            }

            return cores;

        }
    }
}
