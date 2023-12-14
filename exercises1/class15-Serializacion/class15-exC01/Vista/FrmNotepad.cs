using Biblioteca;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmNotepad : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private string ultimoArchivo;
        private PuntoJson<string> puntoJson;
        private PuntoXml<string> puntoXml;
        private PuntoTxt puntoTxt;

        private string UltimoArchivo
        {
            get
            {
                return ultimoArchivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ultimoArchivo = value;
                }
            }
        }

        public FrmNotepad()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de texto|*.txt|Archivo JSON|*.json|Archivo XML|*.xml";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto|*.txt|Archivo JSON|*.json|Archivo XML|*.xml";
            puntoJson = new PuntoJson<string>();
            puntoXml = new PuntoXml<string>();
            puntoTxt = new PuntoTxt();
        }

        private void FrmNotepad_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "0 caracteres";
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ultimoArchivo = openFileDialog.FileName;

                try
                {
                    switch (Path.GetExtension(UltimoArchivo))
                    {
                        case ".json":
                            richTextBox1.Text = puntoJson.Leer(UltimoArchivo);
                            break;
                        case ".xml":
                            richTextBox1.Text = puntoXml.Leer(UltimoArchivo);
                            break;
                        case ".txt":
                            richTextBox1.Text = puntoTxt.Leer(UltimoArchivo);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MostrarVentanaDeError(ex);
                }
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(UltimoArchivo))
            {
                GuardarComo();
            }
            else
            {
                Guardar();
            }
        }

        private void GuardarComo()
        {
            UltimoArchivo = SeleccionarUbicacionGuardado();

            try
            {
                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".json":
                        puntoJson.GuardarComo(UltimoArchivo, richTextBox1.Text);
                        break;
                    case ".xml":
                        puntoXml.GuardarComo(UltimoArchivo, richTextBox1.Text);
                        break;
                    case ".txt":
                        puntoTxt.GuardarComo(UltimoArchivo, richTextBox1.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarVentanaDeError(ex);
            }
        }

        private void Guardar()
        {
            try
            {
                switch (Path.GetExtension(UltimoArchivo))
                {
                    case ".json":
                        puntoJson.Guardar(UltimoArchivo, richTextBox1.Text);
                        break;
                    case ".xml":
                        puntoXml.Guardar(UltimoArchivo, richTextBox1.Text);
                        break;
                    case ".txt":
                        puntoTxt.Guardar(UltimoArchivo, richTextBox1.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarVentanaDeError(ex);
            }
        }

        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        private void MostrarVentanaDeError(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Error: {ex.Message}");
            stringBuilder.AppendLine("Detalle:");
            stringBuilder.AppendLine(ex.StackTrace);

            MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripLabel1.Text = $"{richTextBox1.Text.Length} caracteres";
        }
    }
}