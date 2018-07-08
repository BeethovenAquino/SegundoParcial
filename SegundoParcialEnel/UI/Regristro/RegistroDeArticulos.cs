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
    public partial class RegistroDe_Vehiculos : Form
    {
        public RegistroDe_Vehiculos()
        {
            InitializeComponent();
        }

        private Articulos LlenarClase()
        {

            Articulos articulo = new Articulos();
            InventariotextBox.Text = 0.ToString();
            articulo.ArticuloID = Convert.ToInt32(ArticuloIDnumericUpDown.Value);
            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Costo = Convert.ToInt32(CostonumericUpDown.Value);
            articulo.Precio = Convert.ToInt32(PrecionumericUpDown.Value);
            articulo.Ganancia = Convert.ToInt32(GanancianumericUpDown.Value);
            articulo.Inventario = Convert.ToInt32(InventariotextBox.Text);

            return articulo;
        }
        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && ArticuloIDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(ArticuloIDnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripciontextBox, "Ingrese una descripcion");
                paso = true;
            }

            if (validar == 2 && CostonumericUpDown.Value == 0)
            {

                errorProvider.SetError(CostonumericUpDown, "Ingrese un Costo");
                paso = true;
            }

            if (validar == 2 && PrecionumericUpDown.Value == 0)
            {

                errorProvider.SetError(PrecionumericUpDown, "Ingrese un precio");
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


            if (ArticuloIDnumericUpDown.Value == 0)
                paso = BLL.ArticulosBLL.Guardar(LlenarClase());
            else
                paso = BLL.ArticulosBLL.Modificar(LlenarClase());


            if (paso)
            {

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ArticuloIDnumericUpDown.Value = 0;
                DescripciontextBox.Clear();
                CostonumericUpDown.Value = 0;
                PrecionumericUpDown.Value = 0;
                GanancianumericUpDown.Value=0;
                InventariotextBox.Clear();
                errorProvider.Clear();
            }
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            ArticuloIDnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            CostonumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            GanancianumericUpDown.Value = 0;
            InventariotextBox.Clear();
            errorProvider.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(ArticuloIDnumericUpDown.Value);

            if (BLL.ArticulosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ArticuloIDnumericUpDown.Value = 0;
                DescripciontextBox.Clear();
                CostonumericUpDown.Value = 0;
                PrecionumericUpDown.Value = 0;
                GanancianumericUpDown.Value = 0;
                InventariotextBox.Clear();
                errorProvider.Clear();
            }

            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(ArticuloIDnumericUpDown.Value);
            Articulos articulo = BLL.ArticulosBLL.Buscar(id);

            if (articulo != null)
            {

                DescripciontextBox.Text = articulo.Descripcion;
                CostonumericUpDown.Value = articulo.Costo;
                PrecionumericUpDown.Value = articulo.Precio;
                GanancianumericUpDown.Value = articulo.Ganancia;
                InventariotextBox.Text = articulo.Inventario.ToString(); 
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GananciatextBox_TextChanged(object sender, EventArgs e)
        {
            PrecionumericUpDown.Value -= Convert.ToInt32(CostonumericUpDown);

            PrecionumericUpDown.Value= (Convert.ToDecimal(PrecionumericUpDown) / Convert.ToInt32(CostonumericUpDown)) * 100;

        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CostonumericUpDown.Value != 0 && PrecionumericUpDown.Value != 0)
            {

                GanancianumericUpDown.Text = Convert.ToString(CostonumericUpDown.Value / PrecionumericUpDown.Value * 100);

            }
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PrecionumericUpDown.Value != 0 && GanancianumericUpDown.Value != 0)
            {
                GanancianumericUpDown.Value /= 100;

              CostonumericUpDown.Value=  Convert.ToDecimal(PrecionumericUpDown.Value) * Convert.ToInt32(GanancianumericUpDown.Value);
            }
        }
    }
 }


