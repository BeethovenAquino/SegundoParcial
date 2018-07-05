using SegundoParcialEnel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcialEnel.UI.Regristro
{
    public partial class RegistroTalleres : Form
    {
        public RegistroTalleres()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(TallerIDnumericUpDown.Value);
            Taller taller = BLL.TallerBLL.Buscar(id);

            if (taller != null)
            {

                NombretextBox.Text = taller.Nombre;
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private Taller LlenarClase()
        {

            Taller taller = new Taller();

            taller.TallerID = Convert.ToInt32(TallerIDnumericUpDown.Value);
            taller.Nombre = NombretextBox.Text;
            

            return taller;
        }
        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && TallerIDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(TallerIDnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && NombretextBox.Text == string.Empty)
            {
                errorProvider.SetError(NombretextBox, "Ingrese una Nombre");
                paso = true;
            }

           
            return paso;

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            errorProvider.Clear();


            if (TallerIDnumericUpDown.Value == 0)
                paso = BLL.TallerBLL.Guardar(LlenarClase());
            else
                paso = BLL.TallerBLL.Modificar(LlenarClase());


            if (paso)
            {

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TallerIDnumericUpDown.Value = 0;
                NombretextBox.Clear();
                errorProvider.Clear();
                
            }
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            TallerIDnumericUpDown.Value = 0;
            NombretextBox.Clear();
            errorProvider.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(TallerIDnumericUpDown.Value);

            if (BLL.TallerBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TallerIDnumericUpDown.Value = 0;
                NombretextBox.Clear();
                errorProvider.Clear();
            }

            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
