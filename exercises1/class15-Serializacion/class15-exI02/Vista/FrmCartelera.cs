using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class FrmCartelera : Form
    {
        private static string rutaConfiguracion;

        static FrmCartelera()
        {
            rutaConfiguracion = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\configuracion.json";
        }
        public FrmCartelera()
        {
            InitializeComponent();
        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {
            lblTitulo.Text = txtTitulo.Text;
        }

        private void rtxtMensaje_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = rtxtMensaje.Text;
        }

        private void btnColorTitulo_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lblTitulo.ForeColor = dlg.Color;
            }
        }

        private void btnColorMensaje_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lblMensaje.ForeColor = dlg.Color;
            }
        }

        private void btnColorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pnlCartel.BackColor = dlg.Color;
            }
        }

        private void FrmCartelera_Load(object sender, EventArgs e)
        {
            if (File.Exists(rutaConfiguracion))
            {
                try
                {
                    using StreamReader sr = new StreamReader(rutaConfiguracion);
                    string datos = sr.ReadToEnd();
                    Cartel cartel = JsonSerializer.Deserialize<Cartel>(datos);

                    pnlCartel.BackColor = Color.FromArgb(cartel.ColorARGB);

                    txtTitulo.Text = cartel.Titulo.Contenido;
                    lblTitulo.ForeColor = Color.FromArgb(cartel.Titulo.ColorARGB);

                    rtxtMensaje.Text = cartel.Mensaje.Contenido;
                    lblMensaje.ForeColor = Color.FromArgb(cartel.Mensaje.ColorARGB);
                }
                catch (JsonException)
                {
                    Console.WriteLine("El archivo no se encuentra en el formato correcto");
                }
            }
        }

        private void btnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            Texto titulo = new Texto(lblTitulo.Text, lblTitulo.ForeColor.ToArgb());
            Texto mensaje = new Texto(lblMensaje.Text, lblMensaje.ForeColor.ToArgb());
            Cartel cartel = new Cartel(pnlCartel.BackColor.ToArgb(), titulo, mensaje);

            using StreamWriter sw = new StreamWriter(rutaConfiguracion);
            sw.WriteLine(JsonSerializer.Serialize(cartel));
        }

        private void btnImportarConfiguracion_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Json files(.json)|.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using StreamReader sr = new StreamReader(openFileDialog.FileName);
                    string datos = sr.ReadToEnd();
                    Cartel cartel = JsonSerializer.Deserialize<Cartel>(datos);

                    pnlCartel.BackColor = Color.FromArgb(cartel.ColorARGB);

                    txtTitulo.Text = cartel.Titulo.Contenido;
                    lblTitulo.ForeColor = Color.FromArgb(cartel.Titulo.ColorARGB);

                    rtxtMensaje.Text = cartel.Mensaje.Contenido;
                    lblMensaje.ForeColor = Color.FromArgb(cartel.Mensaje.ColorARGB);
                }
                catch (JsonException)
                {
                    Console.WriteLine("El archivo no se encuentra en el formato correcto");
                }
            }
        }

        private void btnEliminarConfiguracion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Estas seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes)
            {
                if (File.Exists(rutaConfiguracion))
                {
                    File.Delete(rutaConfiguracion);
                }

                txtTitulo.Text = "Título";
                lblTitulo.ForeColor = Control.DefaultForeColor;

                rtxtMensaje.Text = "Mensaje";
                lblMensaje.ForeColor = Control.DefaultForeColor;

                pnlCartel.BackColor = Control.DefaultBackColor;
            }
        }
    }
}
