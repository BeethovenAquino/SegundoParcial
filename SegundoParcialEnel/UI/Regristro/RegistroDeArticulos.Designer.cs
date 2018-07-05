namespace SegundoParcialEnel.UI.Regristro
{
    partial class RegistroDe_Vehiculos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ArticuloIDnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.DescripciontextBox = new System.Windows.Forms.TextBox();
            this.CostonumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PrecionumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GananciatextBox = new System.Windows.Forms.TextBox();
            this.InventariotextBox = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloIDnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostonumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecionumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ArticuloID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Costo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Inventario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ganancia";
            // 
            // ArticuloIDnumericUpDown
            // 
            this.ArticuloIDnumericUpDown.Location = new System.Drawing.Point(105, 64);
            this.ArticuloIDnumericUpDown.Name = "ArticuloIDnumericUpDown";
            this.ArticuloIDnumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.ArticuloIDnumericUpDown.TabIndex = 6;
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::SegundoParcialEnel.Properties.Resources.buscar2;
            this.Buscarbutton.Location = new System.Drawing.Point(262, 24);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(83, 60);
            this.Buscarbutton.TabIndex = 24;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Image = global::SegundoParcialEnel.Properties.Resources.borrar_32;
            this.Eliminarbutton.Location = new System.Drawing.Point(262, 319);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(83, 64);
            this.Eliminarbutton.TabIndex = 23;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Image = global::SegundoParcialEnel.Properties.Resources.new_32;
            this.Nuevobutton.Location = new System.Drawing.Point(172, 319);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(83, 64);
            this.Nuevobutton.TabIndex = 22;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Image = global::SegundoParcialEnel.Properties.Resources.save_32;
            this.Guardarbutton.Location = new System.Drawing.Point(79, 319);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(83, 64);
            this.Guardarbutton.TabIndex = 21;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Guardarbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // DescripciontextBox
            // 
            this.DescripciontextBox.Location = new System.Drawing.Point(108, 129);
            this.DescripciontextBox.Multiline = true;
            this.DescripciontextBox.Name = "DescripciontextBox";
            this.DescripciontextBox.Size = new System.Drawing.Size(131, 64);
            this.DescripciontextBox.TabIndex = 25;
            // 
            // CostonumericUpDown
            // 
            this.CostonumericUpDown.Location = new System.Drawing.Point(86, 226);
            this.CostonumericUpDown.Name = "CostonumericUpDown";
            this.CostonumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.CostonumericUpDown.TabIndex = 26;
            // 
            // PrecionumericUpDown
            // 
            this.PrecionumericUpDown.Location = new System.Drawing.Point(79, 260);
            this.PrecionumericUpDown.Name = "PrecionumericUpDown";
            this.PrecionumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.PrecionumericUpDown.TabIndex = 27;
            // 
            // GananciatextBox
            // 
            this.GananciatextBox.Location = new System.Drawing.Point(271, 228);
            this.GananciatextBox.Name = "GananciatextBox";
            this.GananciatextBox.Size = new System.Drawing.Size(100, 20);
            this.GananciatextBox.TabIndex = 28;
            // 
            // InventariotextBox
            // 
            this.InventariotextBox.Location = new System.Drawing.Point(96, 293);
            this.InventariotextBox.Name = "InventariotextBox";
            this.InventariotextBox.ReadOnly = true;
            this.InventariotextBox.Size = new System.Drawing.Size(100, 20);
            this.InventariotextBox.TabIndex = 29;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RegistroDe_Vehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InventariotextBox);
            this.Controls.Add(this.GananciatextBox);
            this.Controls.Add(this.PrecionumericUpDown);
            this.Controls.Add(this.CostonumericUpDown);
            this.Controls.Add(this.DescripciontextBox);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.ArticuloIDnumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistroDe_Vehiculos";
            this.Text = "RegistroDe_Vehiculos";
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloIDnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostonumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecionumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ArticuloIDnumericUpDown;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.TextBox DescripciontextBox;
        private System.Windows.Forms.NumericUpDown CostonumericUpDown;
        private System.Windows.Forms.NumericUpDown PrecionumericUpDown;
        private System.Windows.Forms.TextBox GananciatextBox;
        private System.Windows.Forms.TextBox InventariotextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}