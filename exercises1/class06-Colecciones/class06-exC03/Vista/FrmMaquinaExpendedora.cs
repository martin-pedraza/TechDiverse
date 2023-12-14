using Entidades;

namespace Vista
{
    public partial class FrmMaquinaExpendedora : Form
    {
        Dictionary<int, Stack<Producto>> maquinaExpendedora = new Dictionary<int, Stack<Producto>>();
        Stack<Producto> posicionUno = new Stack<Producto>();
        Stack<Producto> posicionDos = new Stack<Producto>();
        Stack<Producto> posicionTres = new Stack<Producto>();
        Stack<Producto> posicionCuatro = new Stack<Producto>();
        Stack<Producto> posicionCinco = new Stack<Producto>();
        Stack<Producto> posicionSeis = new Stack<Producto>();
        Stack<Producto> posicionSiete = new Stack<Producto>();
        Stack<Producto> posicionOcho = new Stack<Producto>();
        Stack<Producto> posicionNueve = new Stack<Producto>();
        Queue<string> fila = new Queue<string>();
        List<string> lista = new List<string>();

        public FrmMaquinaExpendedora()
        {
            InitializeComponent();
            maquinaExpendedora.Add(1, posicionUno);
            maquinaExpendedora.Add(2, posicionDos);
            maquinaExpendedora.Add(3, posicionTres);
            maquinaExpendedora.Add(4, posicionCuatro);
            maquinaExpendedora.Add(5, posicionCinco);
            maquinaExpendedora.Add(6, posicionSeis);
            maquinaExpendedora.Add(7, posicionSiete);
            maquinaExpendedora.Add(8, posicionOcho);
            maquinaExpendedora.Add(9, posicionNueve);

            posicionUno.Push(new Producto("Seven up", "700", "1000"));
            posicionUno.Push(new Producto("Seven up", "700", "1001"));
            posicionUno.Push(new Producto("Seven up", "700", "1002"));
            posicionDos.Push(new Producto("Agua mineral", "250", "1000"));
            posicionDos.Push(new Producto("Agua mineral", "250", "1001"));
            posicionDos.Push(new Producto("Agua mineral", "250", "1002"));
            posicionTres.Push(new Producto("Bonobom", "150", "1000"));
            posicionTres.Push(new Producto("Bonobom", "150", "1001"));
            posicionTres.Push(new Producto("Bonobom", "150", "1002"));

            posicionCuatro.Push(new Producto("Baggio", "350", "1000"));
            posicionCuatro.Push(new Producto("Baggio", "350", "1001"));
            posicionCuatro.Push(new Producto("Baggio", "350", "1002"));
            posicionCinco.Push(new Producto("Huevo Kinder", "450", "1000"));
            posicionCinco.Push(new Producto("Huevo Kinder", "450", "1001"));
            posicionCinco.Push(new Producto("Huevo Kinder", "450", "1002"));
            posicionSeis.Push(new Producto("Rocklet", "150", "1000"));
            posicionSeis.Push(new Producto("Rocklet", "150", "1001"));
            posicionSeis.Push(new Producto("Rocklet", "150", "1002"));

            posicionSiete.Push(new Producto("Mini oreo", "600", "1000"));
            posicionSiete.Push(new Producto("Mini oreo", "600", "1001"));
            posicionSiete.Push(new Producto("Mini oreo", "600", "1002"));
            posicionOcho.Push(new Producto("Gomitas Mogul", "500", "1000"));
            posicionOcho.Push(new Producto("Gomitas Mogul", "500", "1001"));
            posicionOcho.Push(new Producto("Gomitas Mogul", "500", "1002"));
            posicionNueve.Push(new Producto("Levite", "400", "1000"));
            posicionNueve.Push(new Producto("Levite", "400", "1001"));
            posicionNueve.Push(new Producto("Levite", "400", "1002"));
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            IngresarNumero("1");
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            IngresarNumero("2");
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            IngresarNumero("3");
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            IngresarNumero("4");
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            IngresarNumero("5");
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            IngresarNumero("6");
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            IngresarNumero("7");
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            IngresarNumero("8");
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            IngresarNumero("9");
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            IngresarNumero("0");
        }

        private void IngresarNumero(string numero)
        {
            txtDisplay.Text += numero;
        }

        private void FrmMaquinaExpendedora_Load(object sender, EventArgs e)
        {
            lblNombre1.Text = CargarInfo(1)[0];
            lblNombre2.Text = CargarInfo(2)[0];
            lblNombre3.Text = CargarInfo(3)[0];
            lblNombre4.Text = CargarInfo(4)[0];
            lblNombre5.Text = CargarInfo(5)[0];
            lblNombre6.Text = CargarInfo(6)[0];
            lblNombre7.Text = CargarInfo(7)[0];
            lblNombre8.Text = CargarInfo(8)[0];
            lblNombre9.Text = CargarInfo(9)[0];

            lblCantidad1.Text = CargarInfo(1)[1];
            lblCantidad2.Text = CargarInfo(2)[1];
            lblCantidad3.Text = CargarInfo(3)[1];
            lblCantidad4.Text = CargarInfo(4)[1];
            lblCantidad5.Text = CargarInfo(5)[1];
            lblCantidad6.Text = CargarInfo(6)[1];
            lblCantidad7.Text = CargarInfo(7)[1];
            lblCantidad8.Text = CargarInfo(8)[1];
            lblCantidad9.Text = CargarInfo(9)[1];

            lboxFila.Items.Clear();
            foreach (string item in lista)
            {
                lboxFila.Items.Add(item);
            }
        }

        private string[] CargarInfo(int posicion)
        {
            string[] array = new string[2];
            for (int index = 0; index < maquinaExpendedora.Count; index++)
            {
                if (index + 1 == posicion)
                {
                    Stack<Producto> pila = maquinaExpendedora.ElementAt(index).Value;
                    if (pila.Count > 0)
                    {
                        string nombreProducto = pila.Peek().Nombre;
                        string cantidadProducto = pila.Count().ToString();
                        array[0] = nombreProducto;
                        array[1] = "Hay " + cantidadProducto;
                    }
                }
            }
            return array;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (fila.Count > 0)
            {
                int numeroIngresado = txtDisplay.Text != "" ? int.Parse(txtDisplay.Text) : 0;
                if (maquinaExpendedora.ContainsKey(numeroIngresado))
                {
                    Stack<Producto> pila = maquinaExpendedora[numeroIngresado];
                    if (pila.Count > 0)
                    {
                        Producto producto = pila.Peek();
                        string persona = fila.Peek();
                        txtMensaje.Text = $"{persona} compró {producto.Mostrar()} - {producto.Codigo}";
                        pila.Pop();
                        fila.Dequeue();
                        lista.Remove(persona);
                        FrmMaquinaExpendedora_Load(sender, e);
                    }
                    else
                    {
                        txtMensaje.Text = "Error, el producto no tiene disponibilidad";
                    }

                }
                else
                {
                    txtMensaje.Text = "Error, el producto no existe";
                }
            }
            else
            {
                btnAgregar_Click(sender, e);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            if (frmCliente.ShowDialog() == DialogResult.OK)
            {
                fila.Enqueue(frmCliente.Nombre);
                lista.Add(frmCliente.Nombre);
                FrmMaquinaExpendedora_Load(sender, e);
            }
        }
    }
}