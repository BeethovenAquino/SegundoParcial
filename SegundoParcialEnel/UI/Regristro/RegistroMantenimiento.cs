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
    public partial class RegistroMantenimiento : Form
    {
        public RegistroMantenimiento()
        {
            InitializeComponent();
            LlenarComboBox();
        }
        decimal subtotal = 0;
        decimal total = 0;
        decimal importe = 0;
        decimal itbis = 0;


        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;

        }


        private decimal ToDecimal(object valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor.ToString(), out retorno);
            return retorno;

        }

        private void LlenarCampos(Mantenimiento mantenimiento)
        {
            MantenimientoIDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            ImportetextBox.Clear();
            SubTotaltextBox.Clear();
            ITBIStextBox.Clear();
            TotaltextBox.Clear();
            ValidarerrorProvider.Clear();
            DetalleMantenimientodataGridView.DataSource = null;


            MatenimientoDetalle m = new MatenimientoDetalle();

            MantenimientoIDnumericUpDown.Value = mantenimiento.MantenimientoID;
            FechadateTimePicker.Value = mantenimiento.Fecha;
            SubTotaltextBox.Text = m.Subtotal.ToString();
            ITBIStextBox.Text = m.ITBIS.ToString();
            TotaltextBox.Text = m.total.ToString();

            foreach (var item in mantenimiento.Detalle)
            {
                subtotal += item.importe;

            }
            SubTotaltextBox.Text = subtotal.ToString();
            //Cargar el detalle al Grid
            DetalleMantenimientodataGridView.DataSource = mantenimiento.Detalle;

            //Ocultar columnas
           /* DetalleMantenimientodataGridView.Columns["Id"].Visible = false;
            DetalleMantenimientodataGridView.Columns["CiudadId"].Visible = false*/
        }

        private void LlenarComboBox()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Repositorio<Vehiculos> repositori = new Repositorio<Vehiculos>(new Contexto());
            Repositorio<Taller> repositor = new Repositorio<Taller>(new Contexto());
            ArticulocomboBox.DataSource = repositorio.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloID";
            ArticulocomboBox.DisplayMember = "Descripcion";

            VehiculocomboBox.DataSource = repositori.GetList(c => true);
            VehiculocomboBox.ValueMember = "VehiculoID";
            VehiculocomboBox.DisplayMember = "Descripcion";

            TallercomboBox.DataSource = repositor.GetList(c => true);
            TallercomboBox.ValueMember = "TallerID";
            TallercomboBox.DisplayMember = "Nombre";

        }

        private bool Validar()
        {
            bool paso = false;

            if (CantidadnumericUpDown.Value == 0)
            {
                ValidarerrorProvider.SetError(CantidadnumericUpDown,
                   "No debes dejar la Cantidad Vacia vacia");
                paso = true;
            }

            if (DetalleMantenimientodataGridView.RowCount == 0)
            {
                ValidarerrorProvider.SetError(DetalleMantenimientodataGridView,
                    "Es obligatorio Agregar un Articulo ");
                paso = true;
            }

            return paso;
        }

        private bool ValidarE()
        {
            bool paso = false;



            if (MantenimientoIDnumericUpDown.Value == 0)
            {
                ValidarerrorProvider.SetError(MantenimientoIDnumericUpDown,
                   "Llene el campo");
                paso = true;
            }


            return paso;


        }

        private Mantenimiento LlenaClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoID = Convert.ToInt32(MantenimientoIDnumericUpDown.Value);
            mantenimiento.Fecha = FechadateTimePicker.Value = DateTime.Now;

            foreach (DataGridViewRow item in DetalleMantenimientodataGridView.Rows)
            {

                mantenimiento.agregarDetalle
                    (ToInt(item.Cells["ID"].Value),
                    ToInt(item.Cells["MantenimientoID"].Value),
                    ToInt(item.Cells["ArticuloID"].Value),
                    ToInt(item.Cells["VehiculoID"].Value),
                      ToInt(item.Cells["TallerID"].Value),
                      ToInt(item.Cells["Cantidad"].Value),
                        ToInt(item.Cells["Precio"].Value),
                         ToInt(item.Cells["Importe"].Value)

                  );

            }
            return mantenimiento;
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<MatenimientoDetalle> Detalle = new List<MatenimientoDetalle>();

            Mantenimiento mantenimiento = new Mantenimiento();

            if (DetalleMantenimientodataGridView.DataSource != null)
            {
                mantenimiento.Detalle = (List<MatenimientoDetalle>)DetalleMantenimientodataGridView.DataSource;
            }

            mantenimiento.Detalle.Add(
                new MatenimientoDetalle(iD: 0,
                mantenimientoID: (int)Convert.ToInt32(MantenimientoIDnumericUpDown.Value),
                articuloID: (int)Convert.ToInt32(ArticulocomboBox.SelectedValue),
                vehiculoID: (int)Convert.ToInt32(VehiculocomboBox.SelectedValue),
                tallerID: (int)Convert.ToInt32(TallercomboBox.SelectedValue),
                cantidad: (int)Convert.ToInt32(CantidadnumericUpDown.Value),
                precio: (decimal)Convert.ToDecimal(PrecionumericUpDown.Value),
                importe: (decimal)Convert.ToDecimal(ImportetextBox.Text)


                    ));

            DetalleMantenimientodataGridView.DataSource = null;
            DetalleMantenimientodataGridView.DataSource = mantenimiento.Detalle;


            subtotal += Convert.ToDecimal(ImportetextBox.Text);

            SubTotaltextBox.Text = subtotal.ToString();

            itbis = Convert.ToDecimal(SubTotaltextBox.Text) * Convert.ToDecimal(0.18);

            ITBIStextBox.Text = itbis.ToString();

            total = Convert.ToDecimal(SubTotaltextBox.Text) + Convert.ToDecimal(ITBIStextBox.Text);

            TotaltextBox.Text = total.ToString();

        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            decimal precio = Convert.ToDecimal(PrecionumericUpDown.Value);


            ImportetextBox.Text = BLL.MantenimientoBLL.CalcularImporte(precio, cantidad).ToString();
        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {

            int cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            decimal precio = Convert.ToDecimal(PrecionumericUpDown.Value);


            ImportetextBox.Text = BLL.MantenimientoBLL.CalcularImporte(precio, cantidad).ToString();
        }

        private void ArticulocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in BLL.ArticulosBLL.GetList(x => x.Descripcion == ArticulocomboBox.Text))

            {
                PrecionumericUpDown.Value = item.Precio;

            }
        }

        private void SubTotaltextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (DetalleMantenimientodataGridView.Rows.Count > 0
              && DetalleMantenimientodataGridView.CurrentRow != null)
            {

                List<MatenimientoDetalle> detalle = (List<MatenimientoDetalle>)DetalleMantenimientodataGridView.DataSource;

                subtotal -= detalle.ElementAt(DetalleMantenimientodataGridView.CurrentRow.Index).importe;

                detalle.RemoveAt(DetalleMantenimientodataGridView.CurrentRow.Index);

                SubTotaltextBox.Text = subtotal.ToString();

                itbis = Convert.ToDecimal(SubTotaltextBox.Text) * Convert.ToDecimal(0.18);

                ITBIStextBox.Text = itbis.ToString();

                total = Convert.ToDecimal(SubTotaltextBox.Text) + Convert.ToDecimal(ITBIStextBox.Text);

                TotaltextBox.Text = total.ToString();








                DetalleMantenimientodataGridView.DataSource = null;
                DetalleMantenimientodataGridView.DataSource = detalle;


            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            MantenimientoIDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value=0;
            ImportetextBox.Clear();
            SubTotaltextBox.Clear();
            ITBIStextBox.Clear();
            TotaltextBox.Clear();
            ValidarerrorProvider.Clear();
            DetalleMantenimientodataGridView.DataSource = null;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento = LlenaClase();
            bool Paso = false;

            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MantenimientoIDnumericUpDown.Value == 0)
            {
                Paso = BLL.MantenimientoBLL.Guardar(mantenimiento);
                ValidarerrorProvider.Clear();
            }
            else
            {

                Paso = BLL.MantenimientoBLL.Modificar(mantenimiento);
                ValidarerrorProvider.Clear();
            }

            if (Paso)
            {

                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                MantenimientoIDnumericUpDown.Value = 0;
                FechadateTimePicker.Value = DateTime.Now;
                CantidadnumericUpDown.Value = 0;
                ImportetextBox.Clear();
                SubTotaltextBox.Clear();
                ITBIStextBox.Clear();
                TotaltextBox.Clear();
                ValidarerrorProvider.Clear();
                DetalleMantenimientodataGridView.DataSource = null;
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarE())
            {


                MessageBox.Show("Favor Llenar Casilla!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                int id = Convert.ToInt32(MantenimientoIDnumericUpDown.Value);
                if (BLL.MantenimientoBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MantenimientoIDnumericUpDown.Value = 0;
                    FechadateTimePicker.Value = DateTime.Now;
                    CantidadnumericUpDown.Value = 0;
                    ImportetextBox.Clear();
                    SubTotaltextBox.Clear();
                    ITBIStextBox.Clear();
                    TotaltextBox.Clear();
                    ValidarerrorProvider.Clear();
                    DetalleMantenimientodataGridView.DataSource = null;
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MantenimientoIDnumericUpDown.Value);
            Mantenimiento mantenimiento = BLL.MantenimientoBLL.Buscar(id);

            if (mantenimiento != null)
            {
                LlenarCampos(mantenimiento);

            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
