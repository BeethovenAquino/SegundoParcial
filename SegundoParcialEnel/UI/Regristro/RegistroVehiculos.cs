﻿using SegundoParcialEnel.Entidades;
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
    public partial class RegistroVehiculos : Form
    {
        public RegistroVehiculos()
        {
            InitializeComponent();
        }

        private Vehiculos LlenarClase()
        {

            Vehiculos vehiculo = new Vehiculos();

            vehiculo.VehiculoID = Convert.ToInt32(VehiculoIDnumericUpDown.Value);
            vehiculo.Descripcion = DescripciontextBox.Text;
            vehiculo.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            vehiculo.Precio = Convert.ToInt32(PrecionumericUpDown.Value);
            vehiculo.TotalMantenimiento = Convert.ToInt32(TotalMantenimientotextBox.Text);
           

            return vehiculo;
        }
        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && VehiculoIDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(VehiculoIDnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripciontextBox, "Ingrese una descripcion");
                paso = true;
            }

            if (validar == 2 && CantidadnumericUpDown.Value == 0)
            {

                errorProvider.SetError(CantidadnumericUpDown, "Ingrese una Cantidad");
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


            if (VehiculoIDnumericUpDown.Value == 0)
                paso = BLL.VehiculosBLL.Guardar(LlenarClase());
            else
                paso = BLL.VehiculosBLL.Modificar(LlenarClase());


            if (paso)
            {

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VehiculoIDnumericUpDown.Value = 0;
                DescripciontextBox.Clear();
                CantidadnumericUpDown.Value = 0;
                PrecionumericUpDown.Value = 0;
                TotalMantenimientotextBox.Clear();
                errorProvider.Clear();
            }
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            VehiculoIDnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            CantidadnumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            TotalMantenimientotextBox.Clear();
            errorProvider.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(VehiculoIDnumericUpDown.Value);

            if (BLL.VehiculosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VehiculoIDnumericUpDown.Value = 0;
                DescripciontextBox.Clear();
                CantidadnumericUpDown.Value = 0;
                PrecionumericUpDown.Value = 0;
                TotalMantenimientotextBox.Clear();
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

            int id = Convert.ToInt32(VehiculoIDnumericUpDown.Value);
            Vehiculos vehiculo = BLL.VehiculosBLL.Buscar(id);

            if (vehiculo != null)
            {

                DescripciontextBox.Text = vehiculo.Descripcion;
                CantidadnumericUpDown.Value = vehiculo.Cantidad;
                PrecionumericUpDown.Value = vehiculo.Precio;
                TotalMantenimientotextBox.Text = vehiculo.TotalMantenimiento.ToString();
             
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
