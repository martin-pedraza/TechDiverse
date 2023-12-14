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
    public partial class FrmAlta : Form
    {
        int codigoJuego;
        public FrmAlta(int codigoJuego) : this()
        {
            btnGuardar.Text = "Modificar";
            nupPrecio.Maximum = 10000;
            this.codigoJuego = codigoJuego;
            PintarForm();
        }

        private void PintarForm()
        {
            Juego juego = JuegoDAO.LeerPorId(codigoJuego);
            txtNombre.Text = juego.Nombre;
            txtGenero.Text = juego.Genero;
            nupPrecio.Value = (decimal)juego.Precio;
        }
        public FrmAlta()
        {
            InitializeComponent();
        }

        private void FrmAlta_Load(object sender, EventArgs e)
        {
            cmbUsuarios.DataSource = UsuarioDAO.Leer();
        }

        protected virtual void btnGuardar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Modificar")
            {
                JuegoDAO.Modificar(new Juego(
                    codigoJuego,
                    ((Usuario)cmbUsuarios.SelectedItem).CodigoUsuario,
                    txtGenero.Text,
                    txtNombre.Text,
                    (double)nupPrecio.Value
                    ));
            }
            else
            {
                JuegoDAO.Guardar(new Juego(
                    ((Usuario)cmbUsuarios.SelectedItem).CodigoUsuario,
                    txtGenero.Text,
                    txtNombre.Text,
                    (double)nupPrecio.Value
                    ));
            }
            DialogResult = DialogResult.OK;
        }
    }
}
