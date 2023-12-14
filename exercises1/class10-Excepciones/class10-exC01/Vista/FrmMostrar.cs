using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmMostrar : Form
    {
        Centralita centralita;
        TipoLlamada tipoLlamada;

        public TipoLlamada TipoLlamada { set { tipoLlamada = value; } }
        public FrmMostrar(Centralita c, TipoLlamada tipo)
        {
            InitializeComponent();
            centralita = c;
            TipoLlamada = tipo;
        }

        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            switch (tipoLlamada)
            {
                case TipoLlamada.Local:
                    rtbMostrar.Text = centralita.GananciaPorLocal.ToString();
                    break;
                case TipoLlamada.Provincial:
                    rtbMostrar.Text = centralita.GananciaPorProvincial.ToString();
                    break;
                case TipoLlamada.Todas:
                    rtbMostrar.Text = centralita.GananciaPorTotal.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
