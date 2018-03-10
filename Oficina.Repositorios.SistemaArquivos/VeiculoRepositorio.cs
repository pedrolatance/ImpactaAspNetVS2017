using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Oficina.Dominio;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Oficina.Repositorios.SistemaArquivos
{
    private string 

    public class VeiculoRepositorio
    {
        public void Inserir(Veiculo veiculo)
        {
           var veiculos = XDocument.Load(_caminhoArquivoVeiculo);

           var registro = new StringWriter();
           new XmlSerializer(typeof(Veiculo)).Serialize(registro, veiculo);

           veiculos.Root.Add(registro.ToString());

           veiculos.Save(_caminhoArquivoVeiculo);
        }  
    }
}