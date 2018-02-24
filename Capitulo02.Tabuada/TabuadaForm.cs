using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo02.Tabuada
{
    public partial class TabuadaForm : Form
    {
        public TabuadaForm()
        {
            InitializeComponent();
        }

        private void tabuadaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permitir apenas NÚMEROS, BACKSPACE E ENTER.
            if (
                e.KeyChar >= '0' && e.KeyChar <= '9' ||
                e.KeyChar == '\b' || e.KeyChar == '\r')
            {
                //Se a tecla ENTER for pressionada
                //chamar método CalcularTabuada.
                if (e.KeyChar == '\r' && tabuadaTextBox.Text != string.Empty)
                {
                    CalcularTabuada();
                }
            }
            else
            {
                //Caso não seja uma tecla válida
                //anular a tecla digitada
                e.KeyChar = '\0';
            }
        }

        private void CalcularTabuada()
        {
            //Limpar lista anterior
            tabuadaListBox.Items.Clear();

            //Calcular tabuada
            var tabuada = Convert.ToInt32(tabuadaTextBox.Text);

            for (int i = 0; i <= 10; i++)
            {
                tabuadaListBox.Items.Add($"{tabuada} * {i} = {tabuada * i}");
            }
            tabuadaTextBox.Focus();
            tabuadaTextBox.SelectAll();
        }

        private void TabuadaForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //A propriedade do Form KeyPreview deve estar True
            // para aceitar ACS para limpar tela
            if (e.KeyChar == 27)
            {
                LimparTela();
            }
        }

        private void LimparTela()
        {
            //Limpa a todos os campos e retornar cursor no Tabuada TextBox
            tabuadaTextBox.Clear();
            tabuadaListBox.Items.Clear();
            tabuadaTextBox.Focus();
        }
    }
}
