using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo02.Fretes
{
    public partial class FretesForm : Form
    {
        public FretesForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                Calcular();
            }
        }

        private void Calcular()
        {
            var percentual = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);

            //ToDo: Exemplificar o novo Switch do C# 7.
            switch (ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percentual = 0.2m;
                    break;
                case "RJ":
                    percentual = 0.3m;
                    break;
                case "MG":
                    percentual = 0.35m;
                    break;
                case "AM":
                    percentual = 0.6m;
                    break;
                default:
                    percentual = 0.75m;
                    break;
            }

            freteTextBox.Text = percentual.ToString("p1");
            totalTextBox.Text = (valor * (1 + percentual)).ToString("c");

        }

        private bool ValidarFormulario()
        {
            if (nomeTextBox.Text == string.Empty)
            {
                nomeTextBox.Focus();

                MessageBox.Show("O campo Nome é obrigatório!",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (ufComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a UF.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (valorTextBox.Text == string.Empty)
            {
                MessageBox.Show("O campo Valor é obrigatório!",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else
            {
                try
                {
                    Convert.ToDecimal(valorTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("O campo Valor está com formato inválido.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }
    }
}
