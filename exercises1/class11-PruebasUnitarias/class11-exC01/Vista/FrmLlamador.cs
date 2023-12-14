using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entidades.Provincial;

namespace Vista
{
    public partial class FrmLlamador : Form
    {
        Centralita centralita;
        public Centralita Centralita { get { return centralita; } }
        public FrmLlamador(Centralita c)
        {
            InitializeComponent();
            centralita = c;
        }

        private void FrmLlamador_Load(object sender, EventArgs e)
        {
            cmbFranja.DataSource = Enum.GetValues(typeof(Franja));
            cmbFranja.SelectedIndex = 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "0";
        }

        private void btnAsterisco_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "*";
        }

        private void btnNumeral_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "#";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text = String.Empty;
        }

        private void txtNroDestino_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNroDestino.Text) && txtNroDestino.Text[0] != '#')
            {
                cmbFranja.Enabled = false;
            }
            else
            {
                cmbFranja.Enabled = true;
            }
        }

        private void btnLlamar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNroDestino.Text))
            {
                float duracion = new Random().Next(1, 50);
                float costo = new Random().Next(0, 6) + 0.5f;
                txtNroOrigen.Text = "12341234";
                if (cmbFranja.Enabled)
                {
                    Franja franjas;
                    Enum.TryParse<Franja>(cmbFranja.SelectedValue.ToString(), out franjas);
                    Provincial p = new Provincial(duracion, franjas, txtNroDestino.Text, txtNroOrigen.Text);
                    try
                    {
                        centralita += p;

                    }
                    catch (CentralitaException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    Local l = new Local(duracion, txtNroDestino.Text, txtNroOrigen.Text, costo);
                    try
                    {
                        centralita += l;

                    }
                    catch (CentralitaException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                MessageBox.Show("Llamada realizada");
                txtNroOrigen.Text = String.Empty;
                txtNroDestino.Text = String.Empty;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
