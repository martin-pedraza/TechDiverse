namespace Vista
{
    public partial class FrmNotepad : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private string ultimoArchivo;

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
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo de texto|*.txt";
        }

        private void FrmNotepad_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = richTextBox1.Text.Length.ToString() + " caracteres";
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ultimoArchivo = openFileDialog.FileName;
                using StreamReader streamReader = new StreamReader(ultimoArchivo);
                richTextBox1.Text = streamReader.ReadToEnd();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripLabel1.Text = richTextBox1.Text.Length.ToString() + " caracteres";
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(UltimoArchivo))
            {
                UltimoArchivo = SeleccionarUbicacionGuardado();
            }

            using StreamWriter streamWriter = new StreamWriter(ultimoArchivo);
            streamWriter.Write(richTextBox1.Text);
        }

        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UltimoArchivo = SeleccionarUbicacionGuardado();

            using StreamWriter streamWriter = new StreamWriter(ultimoArchivo);
            streamWriter.Write(richTextBox1.Text);
        }
    }
}