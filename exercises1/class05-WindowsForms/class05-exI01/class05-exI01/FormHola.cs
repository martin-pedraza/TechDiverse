namespace class05_exI01
{
    public partial class FormHola : Form
    {
        public FormHola()
        {
            InitializeComponent();
        }

        private void btnSaludar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text)
                && !String.IsNullOrEmpty(txtApellido.Text))
            {
                string mensaje = $"Soy {txtNombre.Text} {txtApellido.Text} y mi materia favorita es {cboMateria.SelectedItem}";
                FormSaludo formSaludo = new FormSaludo(mensaje);
                formSaludo.Show();
            }
            else
            {
                string nombre = String.IsNullOrEmpty(txtNombre.Text) ? "Nombre\n" : "";
                string apellido = String.IsNullOrEmpty(txtApellido.Text) ? "Apellido" : "";
                MessageBox.Show($"Se deben completar los siguientes campos:\n{nombre}{apellido}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormHola_Load(object sender, EventArgs e)
        {
            cboMateria.Items.Add("Matemática");
            cboMateria.Items.Add("Sistema de Procesamiento de Datos");
            cboMateria.Items.Add("Inglés");
            cboMateria.Items.Add("Programación I");
            cboMateria.Items.Add("Laboratorio de Computación I");
            cboMateria.Items.Add("Arquitectura y Sistemas Operativos");
            cboMateria.Items.Add("Estadística");
            cboMateria.Items.Add("Inglés II");
            cboMateria.Items.Add("Programación II");
            cboMateria.Items.Add("Laboratorio de Computación II");
            cboMateria.Items.Add("Metodología de La Investigación");

            cboMateria.SelectedIndex = 0;
        }
    }
}