namespace Vista
{
    partial class FormRegistro
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
            gboDetalles = new GroupBox();
            nudoEdad = new NumericUpDown();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            txtNombre = new TextBox();
            lblEdad = new Label();
            lblNombre = new Label();
            gboGenero = new GroupBox();
            radNoBinario = new RadioButton();
            radFemenino = new RadioButton();
            radMasculino = new RadioButton();
            gboCursos = new GroupBox();
            cboJavascript = new CheckBox();
            cboCplus = new CheckBox();
            cboCsharp = new CheckBox();
            lboPais = new ListBox();
            lblPais = new Label();
            btnIngresar = new Button();
            gboDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudoEdad).BeginInit();
            gboGenero.SuspendLayout();
            gboCursos.SuspendLayout();
            SuspendLayout();
            // 
            // gboDetalles
            // 
            gboDetalles.Controls.Add(nudoEdad);
            gboDetalles.Controls.Add(txtDireccion);
            gboDetalles.Controls.Add(lblDireccion);
            gboDetalles.Controls.Add(txtNombre);
            gboDetalles.Controls.Add(lblEdad);
            gboDetalles.Controls.Add(lblNombre);
            gboDetalles.Location = new Point(12, 12);
            gboDetalles.Name = "gboDetalles";
            gboDetalles.Size = new Size(271, 129);
            gboDetalles.TabIndex = 0;
            gboDetalles.TabStop = false;
            gboDetalles.Text = "Detalles de usuario";
            // 
            // nudoEdad
            // 
            nudoEdad.Location = new Point(78, 91);
            nudoEdad.Name = "nudoEdad";
            nudoEdad.Size = new Size(187, 23);
            nudoEdad.TabIndex = 1;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(78, 55);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(187, 23);
            txtDireccion.TabIndex = 2;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(6, 58);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 2;
            lblDireccion.Text = "Direccion";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(78, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(187, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(6, 93);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(33, 15);
            lblEdad.TabIndex = 3;
            lblEdad.Text = "Edad";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(6, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // gboGenero
            // 
            gboGenero.Controls.Add(radNoBinario);
            gboGenero.Controls.Add(radFemenino);
            gboGenero.Controls.Add(radMasculino);
            gboGenero.Location = new Point(301, 20);
            gboGenero.Name = "gboGenero";
            gboGenero.Size = new Size(170, 100);
            gboGenero.TabIndex = 1;
            gboGenero.TabStop = false;
            gboGenero.Text = "Genero";
            // 
            // radNoBinario
            // 
            radNoBinario.AutoSize = true;
            radNoBinario.Location = new Point(6, 72);
            radNoBinario.Name = "radNoBinario";
            radNoBinario.Size = new Size(81, 19);
            radNoBinario.TabIndex = 2;
            radNoBinario.Text = "No binario";
            radNoBinario.UseVisualStyleBackColor = true;
            // 
            // radFemenino
            // 
            radFemenino.AutoSize = true;
            radFemenino.Location = new Point(6, 47);
            radFemenino.Name = "radFemenino";
            radFemenino.Size = new Size(78, 19);
            radFemenino.TabIndex = 1;
            radFemenino.Text = "Femenino";
            radFemenino.UseVisualStyleBackColor = true;
            // 
            // radMasculino
            // 
            radMasculino.AutoSize = true;
            radMasculino.Checked = true;
            radMasculino.Location = new Point(6, 22);
            radMasculino.Name = "radMasculino";
            radMasculino.Size = new Size(80, 19);
            radMasculino.TabIndex = 0;
            radMasculino.TabStop = true;
            radMasculino.Text = "Masculino";
            radMasculino.UseVisualStyleBackColor = true;
            // 
            // gboCursos
            // 
            gboCursos.Controls.Add(cboJavascript);
            gboCursos.Controls.Add(cboCplus);
            gboCursos.Controls.Add(cboCsharp);
            gboCursos.Location = new Point(301, 126);
            gboCursos.Name = "gboCursos";
            gboCursos.Size = new Size(170, 97);
            gboCursos.TabIndex = 2;
            gboCursos.TabStop = false;
            gboCursos.Text = "Cursos";
            // 
            // cboJavascript
            // 
            cboJavascript.AutoSize = true;
            cboJavascript.Location = new Point(6, 72);
            cboJavascript.Name = "cboJavascript";
            cboJavascript.Size = new Size(77, 19);
            cboJavascript.TabIndex = 2;
            cboJavascript.Text = "Javascript";
            cboJavascript.UseVisualStyleBackColor = true;
            // 
            // cboCplus
            // 
            cboCplus.AutoSize = true;
            cboCplus.Location = new Point(6, 47);
            cboCplus.Name = "cboCplus";
            cboCplus.Size = new Size(50, 19);
            cboCplus.TabIndex = 1;
            cboCplus.Text = "C++";
            cboCplus.UseVisualStyleBackColor = true;
            // 
            // cboCsharp
            // 
            cboCsharp.AutoSize = true;
            cboCsharp.Location = new Point(6, 22);
            cboCsharp.Name = "cboCsharp";
            cboCsharp.Size = new Size(41, 19);
            cboCsharp.TabIndex = 0;
            cboCsharp.Text = "C#";
            cboCsharp.UseVisualStyleBackColor = true;
            // 
            // lboPais
            // 
            lboPais.FormattingEnabled = true;
            lboPais.ItemHeight = 15;
            lboPais.Location = new Point(12, 173);
            lboPais.Name = "lboPais";
            lboPais.Size = new Size(271, 94);
            lboPais.TabIndex = 3;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Location = new Point(18, 155);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(28, 15);
            lblPais.TabIndex = 4;
            lblPais.Text = "Pais";
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(301, 240);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(170, 23);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 275);
            Controls.Add(btnIngresar);
            Controls.Add(lblPais);
            Controls.Add(lboPais);
            Controls.Add(gboCursos);
            Controls.Add(gboGenero);
            Controls.Add(gboDetalles);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro";
            Load += FormRegistro_Load;
            gboDetalles.ResumeLayout(false);
            gboDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudoEdad).EndInit();
            gboGenero.ResumeLayout(false);
            gboGenero.PerformLayout();
            gboCursos.ResumeLayout(false);
            gboCursos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gboDetalles;
        private NumericUpDown nudoEdad;
        private TextBox txtDireccion;
        private Label lblDireccion;
        private TextBox txtNombre;
        private Label lblEdad;
        private Label lblNombre;
        private GroupBox gboGenero;
        private RadioButton radNoBinario;
        private RadioButton radFemenino;
        private RadioButton radMasculino;
        private GroupBox gboCursos;
        private CheckBox cboJavascript;
        private CheckBox cboCplus;
        private CheckBox cboCsharp;
        private ListBox lboPais;
        private Label lblPais;
        private Button btnIngresar;
    }
}