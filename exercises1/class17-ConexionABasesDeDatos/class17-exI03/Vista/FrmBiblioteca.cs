using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Vista
{
    public partial class FrmBiblioteca : Form
    {
        public FrmBiblioteca()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefrescarBiblioteca();
        }

        private void RefrescarBiblioteca()
        {
            dtgvBiblioteca.Update();
            dtgvBiblioteca.DataSource = JuegoDAO.Leer();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dtgvBiblioteca.SelectedRows.Count > 0)
            {
                Biblioteca.Biblioteca biblioteca = (Biblioteca.Biblioteca)dtgvBiblioteca.CurrentRow.DataBoundItem;
                JuegoDAO.Eliminar(biblioteca.CodigoJuego);
                RefrescarBiblioteca();
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrmAlta frmAlta = new FrmAlta();
            if (frmAlta.ShowDialog() == DialogResult.OK)
            {
                RefrescarBiblioteca();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvBiblioteca.SelectedRows.Count > 0)
            {
                Biblioteca.Biblioteca biblioteca = (Biblioteca.Biblioteca)dtgvBiblioteca.CurrentRow.DataBoundItem;
                FrmAlta frmAlta = new FrmAlta(biblioteca.CodigoJuego);
                if (frmAlta.ShowDialog() == DialogResult.OK)
                {
                    RefrescarBiblioteca();
                }
            }
        }

    }
}
