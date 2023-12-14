namespace class05_exI01
{
    partial class FormHola
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
            lblNombre = new Label();
            lblApellido = new Label();
            btnSaludar = new Button();
            cboMateria = new ComboBox();
            lblMateria = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(43, 46);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(195, 46);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.Location = new Point(43, 28);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(53, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblApellido.Location = new Point(195, 28);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(52, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido";
            // 
            // btnSaludar
            // 
            btnSaludar.Location = new Point(43, 151);
            btnSaludar.Name = "btnSaludar";
            btnSaludar.Size = new Size(75, 23);
            btnSaludar.TabIndex = 4;
            btnSaludar.Text = "Saludar";
            btnSaludar.UseVisualStyleBackColor = true;
            btnSaludar.Click += btnSaludar_Click;
            // 
            // cboMateria
            // 
            cboMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMateria.FormattingEnabled = true;
            cboMateria.Location = new Point(43, 109);
            cboMateria.Name = "cboMateria";
            cboMateria.Size = new Size(252, 23);
            cboMateria.TabIndex = 5;
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblMateria.Location = new Point(43, 91);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(50, 15);
            lblMateria.TabIndex = 6;
            lblMateria.Text = "Materia";
            // 
            // FormHola
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 201);
            Controls.Add(lblMateria);
            Controls.Add(cboMateria);
            Controls.Add(btnSaludar);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormHola";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "¡Hola, Windows Forms!";
            Load += FormHola_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        public Label lblNombre;
        private Label lblApellido;
        private Button btnSaludar;
        private ComboBox cboMateria;
        private Label lblMateria;
    }
}