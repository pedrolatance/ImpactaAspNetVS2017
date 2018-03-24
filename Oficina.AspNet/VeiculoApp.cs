using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.IO;
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

            //ObterVeiculos();


            Cores = _corRepositorio.Selecionar();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();
        }

        private void ObterVeiculos()
        {
            var veiculos = new List<Veiculo>();

            for (int i = 0; i < 100000000; i++)
            {
                veiculos.Add(new VeiculoPasseio());
            }
        }

        public void Gravar()
        {
            try
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
            catch (FileNotFoundException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"O arquivo {ex.FileName} não foi encontrado.");
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Arquivo Veiculo.xml sem opção de escrita.");
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro", "A pasta do arquivo Veiculo.xml não foi encontrada.");
                throw;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Ooops! Ocorreu um erro e sua ação não foi realizada.");

                //logar o bjeto de exception ex.
                throw;
            }
            finally
            {
                //finally: chamado sempre, idenpendente de erro ou sucesso. É executado mesmo se há um return no código.
            }
        }
    }
}