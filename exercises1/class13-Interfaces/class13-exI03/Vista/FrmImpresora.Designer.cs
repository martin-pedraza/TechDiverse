namespace Vista
{
    partial class FrmImpresora
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
            rboImpresion = new RichTextBox();
            btnAgregar = new Button();
            btnImprimir = new Button();
            cboDocumento = new ComboBox();
            SuspendLayout();
            // 
            // rboImpresion
            // 
            rboImpresion.Enabled = false;
            rboImpresion.Location = new Point(12, 80);
            rboImpresion.Name = "rboImpresion";
            rboImpresion.Size = new Size(231, 265);
            rboImpresion.TabIndex = 0;
            rboImpresion.Text = "";
            // 
            // btnAgregar
            // 
            btnAgregar.AutoSize = true;
            btnAgregar.Location = new Point(12, 49);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 25);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar fila de impresion";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(168, 51);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 2;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // cboDocumento
            // 
            cboDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDocumento.FormattingEnabled = true;
            cboDocumento.Location = new Point(12, 12);
            cboDocumento.Name = "cboDocumento";
            cboDocumento.Size = new Size(231, 23);
            cboDocumento.TabIndex = 3;
            // 
            // FrmImpresora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 357);
            Controls.Add(cboDocumento);
            Controls.Add(btnImprimir);
            Controls.Add(btnAgregar);
            Controls.Add(rboImpresion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmImpresora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Impresora";
            Load += FrmImpresora_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rboImpresion;
        private Button btnAgregar;
        private Button btnImprimir;
        private ComboBox cboDocumento;
    }
}