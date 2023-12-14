namespace Vista
{
    partial class FrmTorre
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
            cboVolador = new ComboBox();
            btnAgregar = new Button();
            btnVer = new Button();
            rboControl = new RichTextBox();
            SuspendLayout();
            // 
            // cboVolador
            // 
            cboVolador.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVolador.FormattingEnabled = true;
            cboVolador.Location = new Point(12, 12);
            cboVolador.Name = "cboVolador";
            cboVolador.Size = new Size(156, 23);
            cboVolador.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 41);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnVer
            // 
            btnVer.Location = new Point(93, 41);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(75, 23);
            btnVer.TabIndex = 2;
            btnVer.Text = "Ver";
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += btnVer_Click;
            // 
            // rboControl
            // 
            rboControl.Enabled = false;
            rboControl.Location = new Point(12, 70);
            rboControl.Name = "rboControl";
            rboControl.Size = new Size(156, 120);
            rboControl.TabIndex = 3;
            rboControl.Text = "";
            // 
            // FrmTorre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(189, 202);
            Controls.Add(rboControl);
            Controls.Add(btnVer);
            Controls.Add(btnAgregar);
            Controls.Add(cboVolador);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmTorre";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Torre de Control";
            Load += FrmTorre_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboVolador;
        private Button btnAgregar;
        private Button btnVer;
        private RichTextBox rboControl;
    }
}