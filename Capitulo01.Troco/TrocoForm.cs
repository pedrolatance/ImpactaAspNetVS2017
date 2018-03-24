using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo01.Troco
{
    public partial class TrocoForm : Form
    {
        public TrocoForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            // Definir variáveis e converter os valores de tela para os tipos
            //correspondentes das variáveis
            decimal valorCompra = Convert.ToDecimal(valorCompraTextBox.Text);
            decimal valorPago = Convert.ToDecimal(valorPagoTextBox.Text);

            //Definir variável troco e calcular a diferença a ser devolvida
            decimal troco = valorPago - valorCompra;

            //Mostrar valor do troco na tela
            trocoTextBox.Text = troco.ToString("c");

            

            var moedas = new decimal[6] { 1, 0.5m, 0.25m, 0.1m, 0.05m, 0.01m };

            for (int i = 0; i <= 5; i++)
            {
                var quantidadeMoeda = (int)(troco / moedas[i]);
                troco %= moedas[i];
                moedasListView.Items[i].Text = quantidadeMoeda.ToString();
            }


            ////Definir as quantidades de cada moeda
            //var moedas1 = (int)troco;
            //troco %= 1;

            //var moedas050 = (int)(troco / 0.5m);
            //troco %= 0.5m;

            //var moedas025 = (int)(troco / 0.25m);
            //troco %= 0.25m;

            //var moedas010 = (int)(troco / 0.1m);
            //troco %= 0.1m;

            //var moedas005 = (int)(troco / 0.05m);
            //troco %= 0.05m;

            //var moedas001 = (int)(troco / 0.01m);


            ////Mostrar na tela as quantidades de cada moeda.
            //moedasListView.Items[0].Text = moedas1.ToString();
            //moedasListView.Items[1].Text = moedas050.ToString();
            //moedasListView.Items[2].Text = moedas025.ToString();
            //moedasListView.Items[3].Text = moedas010.ToString();
            //moedasListView.Items[4].Text = moedas005.ToString();
            //moedasListView.Items[5].Text = moedas001.ToString();


        }
    }
}
