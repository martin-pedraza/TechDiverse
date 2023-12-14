using Biblioteca;

namespace Vista
{
    public partial class FrmAvisador : Form
    {
        private Persona persona;
        public FrmAvisador()
        {
            InitializeComponent();
        }

        public void NotificarCambio(string cambio)
        {
            MessageBox.Show(cambio);
        }

        private void brnActualizar_Click(object sender, EventArgs e)
        {
            if (this.brnActualizar.Text == "Crear")
            {
                this.brnActualizar.Text = "Actualizar";
                persona = new Persona();
                persona.EventoString += NotificarCambio;
            }
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            lblNombreCompleto.Text = persona.Mostrar();
        }
    }
}