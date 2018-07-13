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
            MatenimientoDetalle m = new MatenimientoDetalle();
            MantenimientoIDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            ImportetextBox.Clear();
            SubTotaltextBox.Clear();
            ITBIStextBox.Clear();
            TotaltextBox.Clear();
            ValidarerrorProvider.Clear();
            DetalleMantenimientodataGridView.DataSource = null;


           MantenimientoIDnumericUpDown.Value = mantenimiento.MantenimientoID;
            FechadateTimePicker.Value = mantenimiento.Fecha;
            SubTotaltextBox.Text= mantenimiento.Subtotal.ToString();
            ITBIStextBox.Text = mantenimiento.itbis.ToString();
            TotaltextBox.Text = mantenimiento.Total.ToString();


         
           

            //Cargar el detalle al Grid
            DetalleMantenimientodataGridView.DataSource = mantenimiento.Detalle;
            DetalleMantenimientodataGridView.Columns["ID"].Visible = false;
            DetalleMantenimientodataGridView.Columns["MantenimientoID"].Visible = false;
            DetalleMantenimientodataGridView.Columns["TallerID"].Visible = false;
            DetalleMantenimientodataGridView.Columns["ArticulosID"].Visible = false;
            DetalleMantenimientodataGridView.Columns["Articulos"].Visible = false;
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
           mantenimiento.VehiculoID = Convert.ToInt32(VehiculocomboBox.SelectedValue);
           mantenimiento.Fecha = FechadateTimePicker.Value;
           mantenimiento.Subtotal = Convert.ToDecimal(SubTotaltextBox.Text);
           mantenimiento.itbis = Convert.ToDecimal(ITBIStextBox.Text);
           mantenimiento.Total = Convert.ToDecimal(TotaltextBox.Text);




            foreach (DataGridViewRow item in DetalleMantenimientodataGridView.Rows)
            {

                mantenimiento.AgregarDetalle
                    (ToInt(item.Cells["id"].Value),
                     mantenimiento.MantenimientoID,
                       ToInt(item.Cells["tallerId"].Value),
                     ToInt(item.Cells["articulosId"].Value),
                      Convert.ToString(item.Cells["articulo"].Value),
                       ToInt(item.Cells["cantidad"].Value),
                    ToDecimal(item.Cells["precio"].Value),
                    ToDecimal(item.Cells["importe"].Value)
                    
                  );
            }
            return mantenimiento;
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<MatenimientoDetalle> detalle = new List<MatenimientoDetalle>();



            if (DetalleMantenimientodataGridView.DataSource != null)
            {
                detalle = (List<MatenimientoDetalle>)DetalleMantenimientodataGridView.DataSource;
            }



            //foreach (var item in BLL.ArticulosBLL.GetList(x => x.Inventario < CantidadnumericUpDown.Value))
            //{

            //    MessageBox.Show("No hay esa Existencia para Vender ", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}



            if (string.IsNullOrEmpty(ImportetextBox.Text))
            {
                MessageBox.Show("Importe esta vacio , Llene cantidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                detalle.Add(
                    new MatenimientoDetalle(id: 0,
                    mantenimientoId: (int)Convert.ToInt32(MantenimientoIDnumericUpDown.Value),
                    tallerId: (int)TallercomboBox.SelectedValue,
                       articulosId: (int)ArticulocomboBox.SelectedValue,
                            articulo: (string)BLL.ArticulosBLL.RetornarDescripcion(ArticulocomboBox.Text),
                        cantidad: (int)Convert.ToInt32(CantidadnumericUpDown.Value),
                        precio: (decimal)Convert.ToDecimal(PrecionumericUpDown.Value),
                        importe: (decimal)Convert.ToDecimal(ImportetextBox.Text)

                    ));

                
                DetalleMantenimientodataGridView.DataSource = null;
                DetalleMantenimientodataGridView.DataSource = detalle;


               
                DetalleMantenimientodataGridView.Columns["ID"].Visible = false;
                DetalleMantenimientodataGridView.Columns["MantenimientoID"].Visible = false;
                DetalleMantenimientodataGridView.Columns["TallerID"].Visible = false;
                DetalleMantenimientodataGridView.Columns["ArticulosID"].Visible = false;
                DetalleMantenimientodataGridView.Columns["Articulos"].Visible = false;



                subtotal += Convert.ToDecimal(ImportetextBox.Text);

                SubTotaltextBox.Text = subtotal.ToString();


                //if (MantenimientoIDnumericUpDown.Value != 0)
                //{

                //    subtotal += Convert.ToDecimal(ImportetextBox.Text);

                //    SubTotaltextBox.Text = subtotal.ToString();
                //}
                //else
                //{

                //    subtotal = importe;
                //    SubTotaltextBox.Text = subtotal.ToString();
                //}

                foreach (var item in detalle)
                {
                    subtotal += item.Importe;

                }



                itbis = Convert.ToDecimal(SubTotaltextBox.Text) * Convert.ToDecimal(0.18);

                ITBIStextBox.Text = itbis.ToString();

                total = Convert.ToDecimal(SubTotaltextBox.Text) + Convert.ToDecimal(ITBIStextBox.Text);

                TotaltextBox.Text = total.ToString();

            }
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

                subtotal -= detalle.ElementAt(DetalleMantenimientodataGridView.CurrentRow.Index).Importe;

                detalle.RemoveAt(DetalleMantenimientodataGridView.CurrentRow.Index);

                SubTotaltextBox.Text = subtotal.ToString();

                itbis = Convert.ToDecimal(SubTotaltextBox.Text) * Convert.ToDecimal(0.18);

                ITBIStextBox.Text = itbis.ToString();

                total = Convert.ToDecimal(SubTotaltextBox.Text) + Convert.ToDecimal(ITBIStextBox.Text);

                TotaltextBox.Text = total.ToString();








                DetalleMantenimientodataGridView.DataSource = null;
                DetalleMantenimientodataGridView.DataSource = detalle;

                
                DetalleMantenimientodataGridView.Columns["ID"].Visible = false;
                DetalleMantenimientodataGridView.Columns["MantenimientoID"].Visible = false;
                DetalleMantenimientodataGridView.Columns["TallerID"].Visible = false;
                DetalleMantenimientodataGridView.Columns["ArticulosID"].Visible = false;
                DetalleMantenimientodataGridView.Columns["Articulos"].Visible = false;

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

        private void RegistroMantenimiento_Load(object sender, EventArgs e)
        {

            DateTime fecha = Convert.ToDateTime(ProximadateTimePicker.Text);
            fecha = fecha.AddDays(90);

            ProximadateTimePicker.Text = fecha.ToString();
        }
    }
}
