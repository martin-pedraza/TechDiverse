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
            cboMateria.Items.Add("Matem�tica");
            cboMateria.Items.Add("Sistema de Procesamiento de Datos");
            cboMateria.Items.Add("Ingl�s");
            cboMateria.Items.Add("Programaci�n I");
            cboMateria.Items.Add("Laboratorio de Computaci�n I");
            cboMateria.Items.Add("Arquitectura y Sistemas Operativos");
            cboMateria.Items.Add("Estad�stica");
            cboMateria.Items.Add("Ingl�s II");
            cboMateria.Items.Add("Programaci�n II");
            cboMateria.Items.Add("Laboratorio de Computaci�n II");
            cboMateria.Items.Add("Metodolog�a de La Investigaci�n");

            cboMateria.SelectedIndex = 0;
        }
    }
}