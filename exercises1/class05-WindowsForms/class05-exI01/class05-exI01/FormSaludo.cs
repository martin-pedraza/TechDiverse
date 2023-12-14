using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace class05_exI01
{
    public partial class FormSaludo : Form
    {
        private string titulo;
        private string mensaje;

        public FormSaludo(string mensaje, string titulo = "¡Hola, Windows Forms!")
        {
            Mensaje = mensaje;
            Titulo = titulo;
            InitializeComponent();
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }

        private void FormSaludo_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = Titulo;
            lblMensaje.Text = Mensaje;
        }
    }
}
