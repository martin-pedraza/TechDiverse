using Entidades;
namespace Vista
{
    public partial class FrmCalculador : Form
    {
        public FrmCalculador()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKilometros.Text == String.Empty || txtLitros.Text == String.Empty)
                {
                    throw new ParametrosVaciosException("Campos vacios");
                }
                int numeroUno = int.Parse(txtKilometros.Text);
                int numeroDos = int.Parse(txtLitros.Text);
                float resultado = Calculador.Calcular(numeroUno, numeroDos);
                rboResultado.Text = resultado.ToString();
            }
            catch (ParametrosVaciosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato no valido");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("No se puede dividir por cero");
            }

        }
    }
}