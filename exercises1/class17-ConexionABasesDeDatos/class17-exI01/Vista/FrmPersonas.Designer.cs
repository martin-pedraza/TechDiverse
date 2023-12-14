namespace Vista
{
    partial class FrmPersonas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lstPersonas = new ListBox();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLeer = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(118, 12);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 1;
            // 
            // lstPersonas
            // 
            lstPersonas.FormattingEnabled = true;
            lstPersonas.ItemHeight = 15;
            lstPersonas.Location = new Point(12, 41);
            lstPersonas.Name = "lstPersonas";
            lstPersonas.Size = new Size(206, 94);
            lstPersonas.TabIndex = 2;
            lstPersonas.DoubleClick += lstPersonas_DoubleClick;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 141);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(118, 141);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 23);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(12, 170);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLeer
            // 
            btnLeer.Location = new Point(118, 170);
            btnLeer.Name = "btnLeer";
            btnLeer.Size = new Size(100, 23);
            btnLeer.TabIndex = 6;
            btnLeer.Text = "Leer";
            btnLeer.UseVisualStyleBackColor = true;
            btnLeer.Click += btnLeer_Click;
            // 
            // FrmPersonas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 205);
            Controls.Add(btnLeer);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(lstPersonas);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPersonas";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private ListBox lstPersonas;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLeer;
    }
}