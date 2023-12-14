using Biblioteca;
namespace Vista
{
    public partial class FrmPersonas : Form
    {
        public FrmPersonas()
        {
            InitializeComponent();
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            Recargar();
        }

        private void Recargar()
        {
            lstPersonas.DataSource = PersonaDAO.Leer();
        }

        private void lstPersonas_DoubleClick(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedItems.Count == 1)
            {
                Persona persona = (Persona)lstPersonas.SelectedItem;
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedItems.Count == 1)
            {
                Persona persona = (Persona)lstPersonas.SelectedItem;
                PersonaDAO.Modificar(persona.Id, txtNombre.Text, txtApellido.Text);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtApellido.Text))
            {
                PersonaDAO.Guardar(txtNombre.Text, txtApellido.Text);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedItems.Count == 1)
            {
                Persona persona = (Persona)lstPersonas.SelectedItem;
                PersonaDAO.Borrar(persona.Id);
            }
        }
    }
}