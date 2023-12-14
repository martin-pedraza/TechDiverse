using System;
using System.IO;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmIdentificacionComputadora : Form
    {
        public FrmIdentificacionComputadora()
        {
            InitializeComponent();
        }

        private void FrmIdentificacionComputadora_Load(object sender, System.EventArgs e)
        {
            Text = $"Compu de {Environment.UserName}";
            ConfigurarLogoSistemaOperativo();
            lblSistemaOperativo.Text += Environment.OSVersion.ToString();
            lblNombreMaquina.Text += Environment.MachineName;
            ConfigurarArquitectura();
            lblCantProcesadores.Text += Environment.ProcessorCount + " procesadores lógicos";
            lblDirectorioActual.Text += Environment.NewLine;
            lblDirectorioActual.Text += Environment.CurrentDirectory;
            ConfigurarEspacioTotalYDisponible();
        }

        private void ConfigurarEspacioTotalYDisponible()
        {
            long espacioTotalBytes = 0;
            long espacioDisponibleBytes = 0;

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                espacioTotalBytes += drive.TotalSize;
                espacioDisponibleBytes += drive.AvailableFreeSpace;
            }

            double espacioTotal = Math.Round(espacioTotalBytes * 9.31e-10);
            double espacioDisponible = Math.Round(espacioDisponibleBytes * 9.31e-10);

            lblEspacioTotal.Text = $"Espacio total: {espacioTotal} Gigabytes";
            lblEspacioDisponible.Text = $"Espacio disponible: {espacioDisponible} Gigabytes";
        }

        private void ConfigurarLogoSistemaOperativo()
        {
            if (OperatingSystem.IsMacOS())
            {
                picboxSistemaOperativo.Image = Properties.Resources.mac;
            }
            if (OperatingSystem.IsWindows())
            {
                picboxSistemaOperativo.Image = Properties.Resources.windows;
            }
            if (OperatingSystem.IsLinux())
            {
                picboxSistemaOperativo.Image = Properties.Resources.linux;
            }
        }

        private void ConfigurarArquitectura()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                lblArquitectura.Text += "64 BITS";
            }
            else
            {
                lblArquitectura.Text += "32 BITS";
            }
        }
    }
}
