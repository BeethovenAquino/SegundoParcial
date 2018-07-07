using SegundoParcialEnel.Entidades;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void articulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistroDe_Vehiculos A = new RegistroDe_Vehiculos();
            A.Show();
        }

        private void entradaArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroEntradaArticulos a = new RegistroEntradaArticulos();
            a.Show();
            
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroMantenimiento m = new RegistroMantenimiento();
            m.Show();

        }

        private void talleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroTalleres T = new RegistroTalleres();
            T.Show();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroVehiculos V = new RegistroVehiculos();
            V.Show();
        }
    }
}
