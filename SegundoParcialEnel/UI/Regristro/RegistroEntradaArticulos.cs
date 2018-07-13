using SegundoParcialEnel.DAL;
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
    public partial class RegistroEntradaArticulos : Form
    {
        public RegistroEntradaArticulos()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            
            Repositorio<Articulos> repositori = new Repositorio<Articulos>(new Contexto());

            ArticulocomboBox.DataSource = repositori.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }

        private EntradaArticulos LlenarClase()
        {

            EntradaArticulos articulo = new EntradaArticulos();

            articulo.EntradaID = Convert.ToInt32(EntradaIDnumericUpDown.Value);
            articulo.Fecha = FechadateTimePicker.Value=DateTime.Now;
            articulo.Articulo = ArticulocomboBox.Text;
            articulo.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            articulo.ArticuloID = Convert.ToInt32(ArticulocomboBox.SelectedValue);

            return articulo;
        }
        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && EntradaIDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(EntradaIDnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && ArticulocomboBox.Text == string.Empty)
            {
                errorProvider.SetError(ArticulocomboBox, "Ingrese un Articulo");
                paso = true;
            }

            if (validar == 2 && CantidadnumericUpDown.Value == 0)
            {

                errorProvider.SetError(CantidadnumericUpDown, "Ingrese un Costo");
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


            if (EntradaIDnumericUpDown.Value == 0)
                paso = BLL.EntradaAriticulos.Guardar(LlenarClase());
            else
                paso = BLL.EntradaAriticulos.Modificar(LlenarClase());


            if (paso)
            {

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EntradaIDnumericUpDown.Value = 0;
                FechadateTimePicker.Value = DateTime.Now;
                CantidadnumericUpDown.Value = 0;
                ArticulocomboBox.Text.ToString();
                errorProvider.Clear();
            }
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            EntradaIDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            ArticulocomboBox.Text.ToString();
            errorProvider.Clear();

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(EntradaIDnumericUpDown.Value);

            if (BLL.EntradaAriticulos.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EntradaIDnumericUpDown.Value = 0;
                FechadateTimePicker.Value = DateTime.Now;
                CantidadnumericUpDown.Value = 0;
                ArticulocomboBox.Text.ToString();
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

            int id = Convert.ToInt32(EntradaIDnumericUpDown.Value);
            EntradaArticulos articulo = BLL.EntradaAriticulos.Buscar(id);

            if (articulo != null)
            {

                FechadateTimePicker.Value = articulo.Fecha;
                ArticulocomboBox.Text = articulo.Articulo;
                CantidadnumericUpDown.Value = articulo.Cantidad;
               
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RegistroEntradaArticulos_Load(object sender, EventArgs e)
        {

        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
    }
