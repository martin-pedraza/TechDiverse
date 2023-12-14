using Entidades;

namespace Vista
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            lboPais.Items.Add("Argentina");
            lboPais.Items.Add("Chile");
            lboPais.Items.Add("Uruguay");

            lboPais.SelectedIndex = 0;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            int edad = (int)nudoEdad.Value;
            string genero = radMasculino.Checked ? radMasculino.Text : radFemenino.Checked ? radFemenino.Text : radNoBinario.Text;
            string pais = lboPais.Text;
            string[] cursos = new string[] { cboCsharp.Checked?cboCsharp.Text:"", cboCplus.Checked?cboCplus.Text:"", cboJavascript.Checked?cboJavascript.Text:"" };
            Ingresante ingresante = new Ingresante(cursos, direccion, edad, genero, nombre, pais);
            MessageBox.Show(ingresante.Mostrar());
        }
    }
}