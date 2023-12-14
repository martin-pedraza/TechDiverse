namespace Vista
{
    partial class FrmMonedas
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonedas));
            lblCotizacion = new Label();
            lblEuro = new Label();
            lblDolar = new Label();
            lblPeso = new Label();
            lblCotizacionEuro = new Label();
            lblCotizacionDolar = new Label();
            lblCotizacionPeso = new Label();
            txtCotizacionEuro = new TextBox();
            txtCotizacionDolar = new TextBox();
            txtCotizacionPeso = new TextBox();
            txtEuro = new TextBox();
            txtDolar = new TextBox();
            txtPeso = new TextBox();
            txtEuroAEuro = new TextBox();
            txtEuroADolar = new TextBox();
            txtEuroAPeso = new TextBox();
            txtDolarAEuro = new TextBox();
            txtDolarADolar = new TextBox();
            txtDolarAPeso = new TextBox();
            txtPesoAEuro = new TextBox();
            txtPesoADolar = new TextBox();
            txtPesoAPeso = new TextBox();
            btnLockCotizacion = new Button();
            btnEuroA = new Button();
            btnDolarA = new Button();
            btnPesoA = new Button();
            imageList1 = new ImageList(components);
            SuspendLayout();
            // 
            // lblCotizacion
            // 
            lblCotizacion.AutoSize = true;
            lblCotizacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCotizacion.Location = new Point(57, 9);
            lblCotizacion.Name = "lblCotizacion";
            lblCotizacion.Size = new Size(64, 15);
            lblCotizacion.TabIndex = 0;
            lblCotizacion.Text = "Cotizacion";
            // 
            // lblEuro
            // 
            lblEuro.AutoSize = true;
            lblEuro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblEuro.Location = new Point(12, 67);
            lblEuro.Name = "lblEuro";
            lblEuro.Size = new Size(32, 15);
            lblEuro.TabIndex = 1;
            lblEuro.Text = "Euro";
            // 
            // lblDolar
            // 
            lblDolar.AutoSize = true;
            lblDolar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDolar.Location = new Point(12, 102);
            lblDolar.Name = "lblDolar";
            lblDolar.Size = new Size(37, 15);
            lblDolar.TabIndex = 2;
            lblDolar.Text = "Dolar";
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPeso.Location = new Point(12, 135);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(33, 15);
            lblPeso.TabIndex = 3;
            lblPeso.Text = "Peso";
            // 
            // lblCotizacionEuro
            // 
            lblCotizacionEuro.AutoSize = true;
            lblCotizacionEuro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCotizacionEuro.Location = new Point(289, 46);
            lblCotizacionEuro.Name = "lblCotizacionEuro";
            lblCotizacionEuro.Size = new Size(32, 15);
            lblCotizacionEuro.TabIndex = 4;
            lblCotizacionEuro.Text = "Euro";
            // 
            // lblCotizacionDolar
            // 
            lblCotizacionDolar.AutoSize = true;
            lblCotizacionDolar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCotizacionDolar.Location = new Point(394, 46);
            lblCotizacionDolar.Name = "lblCotizacionDolar";
            lblCotizacionDolar.Size = new Size(37, 15);
            lblCotizacionDolar.TabIndex = 5;
            lblCotizacionDolar.Text = "Dolar";
            // 
            // lblCotizacionPeso
            // 
            lblCotizacionPeso.AutoSize = true;
            lblCotizacionPeso.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCotizacionPeso.Location = new Point(497, 46);
            lblCotizacionPeso.Name = "lblCotizacionPeso";
            lblCotizacionPeso.Size = new Size(33, 15);
            lblCotizacionPeso.TabIndex = 6;
            lblCotizacionPeso.Text = "Peso";
            // 
            // txtCotizacionEuro
            // 
            txtCotizacionEuro.Location = new Point(254, 6);
            txtCotizacionEuro.Name = "txtCotizacionEuro";
            txtCotizacionEuro.Size = new Size(100, 23);
            txtCotizacionEuro.TabIndex = 7;
            txtCotizacionEuro.Leave += txtCotizacionEuro_Leave;
            // 
            // txtCotizacionDolar
            // 
            txtCotizacionDolar.Location = new Point(360, 6);
            txtCotizacionDolar.Name = "txtCotizacionDolar";
            txtCotizacionDolar.Size = new Size(100, 23);
            txtCotizacionDolar.TabIndex = 8;
            txtCotizacionDolar.Leave += txtCotizacionDolar_Leave;
            // 
            // txtCotizacionPeso
            // 
            txtCotizacionPeso.Location = new Point(466, 6);
            txtCotizacionPeso.Name = "txtCotizacionPeso";
            txtCotizacionPeso.Size = new Size(100, 23);
            txtCotizacionPeso.TabIndex = 9;
            txtCotizacionPeso.Leave += txtCotizacionPeso_Leave;
            // 
            // txtEuro
            // 
            txtEuro.Location = new Point(57, 64);
            txtEuro.Name = "txtEuro";
            txtEuro.Size = new Size(100, 23);
            txtEuro.TabIndex = 10;
            // 
            // txtDolar
            // 
            txtDolar.Location = new Point(57, 99);
            txtDolar.Name = "txtDolar";
            txtDolar.Size = new Size(100, 23);
            txtDolar.TabIndex = 11;
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(57, 132);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(100, 23);
            txtPeso.TabIndex = 12;
            // 
            // txtEuroAEuro
            // 
            txtEuroAEuro.Enabled = false;
            txtEuroAEuro.Location = new Point(254, 64);
            txtEuroAEuro.Name = "txtEuroAEuro";
            txtEuroAEuro.Size = new Size(100, 23);
            txtEuroAEuro.TabIndex = 13;
            // 
            // txtEuroADolar
            // 
            txtEuroADolar.Enabled = false;
            txtEuroADolar.Location = new Point(360, 64);
            txtEuroADolar.Name = "txtEuroADolar";
            txtEuroADolar.Size = new Size(100, 23);
            txtEuroADolar.TabIndex = 14;
            // 
            // txtEuroAPeso
            // 
            txtEuroAPeso.Enabled = false;
            txtEuroAPeso.Location = new Point(466, 64);
            txtEuroAPeso.Name = "txtEuroAPeso";
            txtEuroAPeso.Size = new Size(100, 23);
            txtEuroAPeso.TabIndex = 15;
            // 
            // txtDolarAEuro
            // 
            txtDolarAEuro.Enabled = false;
            txtDolarAEuro.Location = new Point(254, 99);
            txtDolarAEuro.Name = "txtDolarAEuro";
            txtDolarAEuro.Size = new Size(100, 23);
            txtDolarAEuro.TabIndex = 16;
            // 
            // txtDolarADolar
            // 
            txtDolarADolar.Enabled = false;
            txtDolarADolar.Location = new Point(360, 99);
            txtDolarADolar.Name = "txtDolarADolar";
            txtDolarADolar.Size = new Size(100, 23);
            txtDolarADolar.TabIndex = 17;
            // 
            // txtDolarAPeso
            // 
            txtDolarAPeso.Enabled = false;
            txtDolarAPeso.Location = new Point(466, 99);
            txtDolarAPeso.Name = "txtDolarAPeso";
            txtDolarAPeso.Size = new Size(100, 23);
            txtDolarAPeso.TabIndex = 18;
            // 
            // txtPesoAEuro
            // 
            txtPesoAEuro.Enabled = false;
            txtPesoAEuro.Location = new Point(254, 132);
            txtPesoAEuro.Name = "txtPesoAEuro";
            txtPesoAEuro.Size = new Size(100, 23);
            txtPesoAEuro.TabIndex = 19;
            // 
            // txtPesoADolar
            // 
            txtPesoADolar.Enabled = false;
            txtPesoADolar.Location = new Point(360, 132);
            txtPesoADolar.Name = "txtPesoADolar";
            txtPesoADolar.Size = new Size(100, 23);
            txtPesoADolar.TabIndex = 20;
            // 
            // txtPesoAPeso
            // 
            txtPesoAPeso.Enabled = false;
            txtPesoAPeso.Location = new Point(466, 132);
            txtPesoAPeso.Name = "txtPesoAPeso";
            txtPesoAPeso.Size = new Size(100, 23);
            txtPesoAPeso.TabIndex = 21;
            // 
            // btnLockCotizacion
            // 
            btnLockCotizacion.ImageIndex = 0;
            btnLockCotizacion.ImageList = imageList1;
            btnLockCotizacion.Location = new Point(163, 5);
            btnLockCotizacion.Name = "btnLockCotizacion";
            btnLockCotizacion.Size = new Size(75, 52);
            btnLockCotizacion.TabIndex = 22;
            btnLockCotizacion.UseVisualStyleBackColor = true;
            btnLockCotizacion.Click += btnLockCotizacion_Click;
            // 
            // btnEuroA
            // 
            btnEuroA.Location = new Point(163, 63);
            btnEuroA.Name = "btnEuroA";
            btnEuroA.Size = new Size(75, 23);
            btnEuroA.TabIndex = 23;
            btnEuroA.Text = "->";
            btnEuroA.UseVisualStyleBackColor = true;
            btnEuroA.Click += btnEuroA_Click;
            // 
            // btnDolarA
            // 
            btnDolarA.Location = new Point(163, 98);
            btnDolarA.Name = "btnDolarA";
            btnDolarA.Size = new Size(75, 23);
            btnDolarA.TabIndex = 24;
            btnDolarA.Text = "->";
            btnDolarA.UseVisualStyleBackColor = true;
            btnDolarA.Click += btnDolarA_Click;
            // 
            // btnPesoA
            // 
            btnPesoA.Location = new Point(163, 131);
            btnPesoA.Name = "btnPesoA";
            btnPesoA.Size = new Size(75, 23);
            btnPesoA.TabIndex = 25;
            btnPesoA.Text = "->";
            btnPesoA.UseVisualStyleBackColor = true;
            btnPesoA.Click += btnPesoA_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "lock-padlock-symbol-for-protect_icon-icons.com_56926.ico");
            imageList1.Images.SetKeyName(1, "openpadlock_120633.ico");
            // 
            // FrmMonedas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 179);
            Controls.Add(btnPesoA);
            Controls.Add(btnDolarA);
            Controls.Add(btnEuroA);
            Controls.Add(btnLockCotizacion);
            Controls.Add(txtPesoAPeso);
            Controls.Add(txtPesoADolar);
            Controls.Add(txtPesoAEuro);
            Controls.Add(txtDolarAPeso);
            Controls.Add(txtDolarADolar);
            Controls.Add(txtDolarAEuro);
            Controls.Add(txtEuroAPeso);
            Controls.Add(txtEuroADolar);
            Controls.Add(txtEuroAEuro);
            Controls.Add(txtPeso);
            Controls.Add(txtDolar);
            Controls.Add(txtEuro);
            Controls.Add(txtCotizacionPeso);
            Controls.Add(txtCotizacionDolar);
            Controls.Add(txtCotizacionEuro);
            Controls.Add(lblCotizacionPeso);
            Controls.Add(lblCotizacionDolar);
            Controls.Add(lblCotizacionEuro);
            Controls.Add(lblPeso);
            Controls.Add(lblDolar);
            Controls.Add(lblEuro);
            Controls.Add(lblCotizacion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMonedas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conversor";
            Load += FrmMonedas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCotizacion;
        private Label lblEuro;
        private Label lblDolar;
        private Label lblPeso;
        private Label lblCotizacionEuro;
        private Label lblCotizacionDolar;
        private Label lblCotizacionPeso;
        private TextBox txtCotizacionEuro;
        private TextBox txtCotizacionDolar;
        private TextBox txtCotizacionPeso;
        private TextBox txtEuro;
        private TextBox txtDolar;
        private TextBox txtPeso;
        private TextBox txtEuroAEuro;
        private TextBox txtEuroADolar;
        private TextBox txtEuroAPeso;
        private TextBox txtDolarAEuro;
        private TextBox txtDolarADolar;
        private TextBox txtDolarAPeso;
        private TextBox txtPesoAEuro;
        private TextBox txtPesoADolar;
        private TextBox txtPesoAPeso;
        private Button btnLockCotizacion;
        private Button btnEuroA;
        private Button btnDolarA;
        private Button btnPesoA;
        private ImageList imageList1;
    }
}