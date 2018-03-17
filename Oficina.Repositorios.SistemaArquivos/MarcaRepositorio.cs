using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using Oficina.Dominio;


namespace Oficina.Repositorios.SistemaArquivos
{
    public class MarcaRepositorio
    {
        private string _caminhoArquivoMarca = ConfigurationManager.AppSettings["caminhoArquivoMarca"];
        
        //ToDo: OO - Polimorfismo / Sobrecarga
        public List<Marca> Selecionar()
        {
            var marcas = new List<Marca>();

            foreach (var linha in File.ReadAllLines(_caminhoArquivoMarca))
            {
                
                //Lista separada por ";". Ex. 1;Ford
                var propriedades = linha.Split(';');

                var marca = new Marca();
                marca.Id = Convert.ToInt32(propriedades[0]);
                marca.Nome = propriedades[1];
                
                marcas.Add(marca);
            }

            return marcas;
        }

        public Marca Selecionar(int marcaId)
        {
            Marca marca = null;

            foreach (var linha in File.ReadAllLines(_caminhoArquivoMarca))
            {
                

                //Lista separada por ";". Ex. 1;Ford
                var propriedades = linha.Split(';');

                if (marcaId.ToString() == propriedades[0])
                {
                    marca = new Marca();
                    marca.Id = Convert.ToInt32(propriedades[0]);
                    marca.Nome = propriedades[1];
                
                    break;
                }       
            }

            return marca;

        } 
    }
}