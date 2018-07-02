using SegundoParcialEnel.UI.Regristro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcialEnel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroPersona P = new RegistroPersona();
            P.Show();
        }

        private void articuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroArticulos A = new RegistroArticulos();
            A.Show();
        }

        private void cotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroCotizaciones C = new RegistroCotizaciones();
            C.Show();
        }
    }
}
