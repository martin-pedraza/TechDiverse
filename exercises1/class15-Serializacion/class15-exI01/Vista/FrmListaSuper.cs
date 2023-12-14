using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Vista
{
    public partial class FrmListaSuper : Form
    {
        private List<string> listaSupermercado;
        public FrmListaSuper()
        {
            InitializeComponent();
            listaSupermercado = new List<string>();
        }

        private void CargarLista()
        {
            lstObjetos.DataSource = null;
            lstObjetos.DataSource = listaSupermercado;
            Guardar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaModificacion frm = new FrmAltaModificacion("Agregar Objeto", "", "Agregar");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                listaSupermercado.Add(frm.Objeto);
                CargarLista();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstObjetos.SelectedValue != null)
            {
                listaSupermercado.RemoveAt(lstObjetos.SelectedIndex);
                CargarLista();
            }
            else
            {
                MessageBox.Show("Seleccionar un elemento");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lstObjetos.SelectedValue != null)
            {
                FrmAltaModificacion frm = new FrmAltaModificacion("Modificar objeto", lstObjetos.SelectedValue.ToString(), "Modificar");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    listaSupermercado[lstObjetos.SelectedIndex] = frm.Objeto;
                    CargarLista();
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un elemento");
            }
        }

        private void FrmListaSuper_Load(object sender, EventArgs e)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string completa = ruta + @"\listaSupermercado.xml";
            if (File.Exists(completa))
            {
                using StreamReader sr = new StreamReader(completa);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                listaSupermercado = xmlSerializer.Deserialize(sr) as List<string>;
            }
            CargarLista();
        }

        private void Guardar()
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string completa = ruta + @"\listaSupermercado.xml";

            using StreamWriter sr = new StreamWriter(completa);
            XmlSerializer xmlSerializer = new XmlSerializer (typeof(List<string>));
            xmlSerializer.Serialize(sr, listaSupermercado);
        }
    }
}
