namespace Vista
{
    partial class FrmAvisador
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
            lblNombre = new Label();
            lblApellido = new Label();
            lblNombreCompleto = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            brnActualizar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(12, 65);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido";
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Location = new Point(12, 173);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(0, 15);
            lblNombreCompleto.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(105, 9);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(105, 62);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 4;
            // 
            // brnActualizar
            // 
            brnActualizar.Location = new Point(12, 117);
            brnActualizar.Name = "brnActualizar";
            brnActualizar.Size = new Size(193, 23);
            brnActualizar.TabIndex = 5;
            brnActualizar.Text = "Crear";
            brnActualizar.UseVisualStyleBackColor = true;
            brnActualizar.Click += brnActualizar_Click;
            // 
            // FrmAvisador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(226, 208);
            Controls.Add(brnActualizar);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombreCompleto);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAvisador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "El Avisador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblApellido;
        private Label lblNombreCompleto;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Button brnActualizar;
    }
}