using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.AspNet
{
    public class VeiculoApp
    {

        CorRepositorio _corRepositorio = new CorRepositorio();
        MarcaRepositorio _marcaRepositorio = new MarcaRepositorio();
        ModeloRepositorio _modeloRepositorio = new ModeloRepositorio();
        VeiculoRepositorio _veiculoRepositorio = new VeiculoRepositorio();



        public VeiculoApp()
        {
            PopularControles();
        }

        public List<Marca> Marcas { get; private set; }

        private void PopularControles()
        {
            Marcas = _marcaRepositorio.Selecionar();
        }
    }
}