namespace Vista
{
    partial class FrmCalculador
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
            lblKilometros = new Label();
            lblLitros = new Label();
            txtLitros = new TextBox();
            txtKilometros = new TextBox();
            btnCalcular = new Button();
            rboResultado = new RichTextBox();
            SuspendLayout();
            // 
            // lblKilometros
            // 
            lblKilometros.AutoSize = true;
            lblKilometros.Location = new Point(12, 9);
            lblKilometros.Name = "lblKilometros";
            lblKilometros.Size = new Size(64, 15);
            lblKilometros.TabIndex = 0;
            lblKilometros.Text = "Kilometros";
            // 
            // lblLitros
            // 
            lblLitros.AutoSize = true;
            lblLitros.Location = new Point(12, 93);
            lblLitros.Name = "lblLitros";
            lblLitros.Size = new Size(36, 15);
            lblLitros.TabIndex = 1;
            lblLitros.Text = "Litros";
            // 
            // txtLitros
            // 
            txtLitros.Location = new Point(12, 111);
            txtLitros.Name = "txtLitros";
            txtLitros.Size = new Size(100, 23);
            txtLitros.TabIndex = 2;
            // 
            // txtKilometros
            // 
            txtKilometros.Location = new Point(12, 27);
            txtKilometros.Name = "txtKilometros";
            txtKilometros.Size = new Size(100, 23);
            txtKilometros.TabIndex = 3;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(12, 181);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(75, 23);
            btnCalcular.TabIndex = 4;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // rboResultado
            // 
            rboResultado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rboResultado.Enabled = false;
            rboResultado.Location = new Point(144, 12);
            rboResultado.Name = "rboResultado";
            rboResultado.Size = new Size(113, 122);
            rboResultado.TabIndex = 5;
            rboResultado.Text = "";
            // 
            // FrmCalculador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 219);
            Controls.Add(rboResultado);
            Controls.Add(btnCalcular);
            Controls.Add(txtKilometros);
            Controls.Add(txtLitros);
            Controls.Add(lblLitros);
            Controls.Add(lblKilometros);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCalculador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKilometros;
        private Label lblLitros;
        private TextBox txtLitros;
        private TextBox txtKilometros;
        private Button btnCalcular;
        private RichTextBox rboResultado;
    }
}