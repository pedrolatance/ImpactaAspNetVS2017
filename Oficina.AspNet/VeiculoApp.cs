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

        private CorRepositorio _corRepositorio = new CorRepositorio();
        private MarcaRepositorio _marcaRepositorio = new MarcaRepositorio();
        private ModeloRepositorio _modeloRepositorio = new ModeloRepositorio();
        private VeiculoRepositorio _veiculoRepositorio = new VeiculoRepositorio();



        public VeiculoApp()
        {
            PopularControles();
        }

        public List<Marca> Marcas { get; private set; }
        public string MarcaSelecionada { get; private set; }
        public List<Modelo> Modelos { get; set; } = new List<Modelo>();
        public List<Cor> Cores { get; private set; }
        public List<Combustivel> Combustiveis { get; private set; }
        public List<Cambio> Cambios { get; private set; }

        private void PopularControles()
        {
            Marcas = _marcaRepositorio.Selecionar();
            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = _modeloRepositorio.SelecionarPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            Cores = _corRepositorio.Selecionar();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();
        }

        public void Gravar()
        {
            var veiculo = new VeiculoPasseio();

            var formulario = HttpContext.Current.Request.Form;


            veiculo.Ano = Convert.ToInt32(formulario["ano"]);
            veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);
            veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
            veiculo.Cor = _corRepositorio.Selecionar(Convert.ToInt32(formulario["cor"]));
            veiculo.Modelo = _modeloRepositorio.Selecionar(Convert.ToInt32(formulario["modelo"]));
            veiculo.Placa = formulario["placa"];
            veiculo.Observacao = formulario["observacao"];
            veiculo.Carroceria = TipoCarroceria.Pickup;


            _veiculoRepositorio.Inserir(veiculo);
        }
    }
}