namespace Vista
{
    partial class FrmConversor
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
            lblFahrenheit = new Label();
            lblCelsius = new Label();
            lblKelvin = new Label();
            lblFahrenheitA = new Label();
            lblCelsiusA = new Label();
            lblKelvinA = new Label();
            btnFahrenheit = new Button();
            btnCelsius = new Button();
            btnKelvin = new Button();
            txtKelvin = new TextBox();
            txtFahrenheit = new TextBox();
            txtCelsius = new TextBox();
            txtFahrenheitAFahrenheit = new TextBox();
            txtFahrenheitACelsius = new TextBox();
            txtFahrenheitAKelvin = new TextBox();
            txtCelsiusAFahrenheit = new TextBox();
            txtCelsiusACelsius = new TextBox();
            txtCelsiusAKelvin = new TextBox();
            txtKelvinAFahrenheit = new TextBox();
            txtKelvinACelsius = new TextBox();
            txtKelvinAKelvin = new TextBox();
            SuspendLayout();
            // 
            // lblFahrenheit
            // 
            lblFahrenheit.AutoSize = true;
            lblFahrenheit.Location = new Point(12, 57);
            lblFahrenheit.Name = "lblFahrenheit";
            lblFahrenheit.Size = new Size(63, 15);
            lblFahrenheit.TabIndex = 0;
            lblFahrenheit.Text = "Fahrenheit";
            // 
            // lblCelsius
            // 
            lblCelsius.AutoSize = true;
            lblCelsius.Location = new Point(12, 93);
            lblCelsius.Name = "lblCelsius";
            lblCelsius.Size = new Size(44, 15);
            lblCelsius.TabIndex = 1;
            lblCelsius.Text = "Celsius";
            // 
            // lblKelvin
            // 
            lblKelvin.AutoSize = true;
            lblKelvin.Location = new Point(12, 131);
            lblKelvin.Name = "lblKelvin";
            lblKelvin.Size = new Size(39, 15);
            lblKelvin.TabIndex = 2;
            lblKelvin.Text = "Kelvin";
            // 
            // lblFahrenheitA
            // 
            lblFahrenheitA.AutoSize = true;
            lblFahrenheitA.Location = new Point(298, 36);
            lblFahrenheitA.Name = "lblFahrenheitA";
            lblFahrenheitA.Size = new Size(63, 15);
            lblFahrenheitA.TabIndex = 3;
            lblFahrenheitA.Text = "Fahrenheit";
            // 
            // lblCelsiusA
            // 
            lblCelsiusA.AutoSize = true;
            lblCelsiusA.Location = new Point(406, 36);
            lblCelsiusA.Name = "lblCelsiusA";
            lblCelsiusA.Size = new Size(44, 15);
            lblCelsiusA.TabIndex = 4;
            lblCelsiusA.Text = "Celsius";
            // 
            // lblKelvinA
            // 
            lblKelvinA.AutoSize = true;
            lblKelvinA.Location = new Point(520, 36);
            lblKelvinA.Name = "lblKelvinA";
            lblKelvinA.Size = new Size(39, 15);
            lblKelvinA.TabIndex = 5;
            lblKelvinA.Text = "Kelvin";
            // 
            // btnFahrenheit
            // 
            btnFahrenheit.Location = new Point(199, 53);
            btnFahrenheit.Name = "btnFahrenheit";
            btnFahrenheit.Size = new Size(75, 23);
            btnFahrenheit.TabIndex = 6;
            btnFahrenheit.Text = "->";
            btnFahrenheit.UseVisualStyleBackColor = true;
            btnFahrenheit.Click += btnFahrenheit_Click;
            // 
            // btnCelsius
            // 
            btnCelsius.Location = new Point(199, 89);
            btnCelsius.Name = "btnCelsius";
            btnCelsius.Size = new Size(75, 23);
            btnCelsius.TabIndex = 7;
            btnCelsius.Text = "->";
            btnCelsius.UseVisualStyleBackColor = true;
            btnCelsius.Click += btnCelsius_Click;
            // 
            // btnKelvin
            // 
            btnKelvin.Location = new Point(199, 127);
            btnKelvin.Name = "btnKelvin";
            btnKelvin.Size = new Size(75, 23);
            btnKelvin.TabIndex = 8;
            btnKelvin.Text = "->";
            btnKelvin.UseVisualStyleBackColor = true;
            btnKelvin.Click += btnKelvin_Click;
            // 
            // txtKelvin
            // 
            txtKelvin.Location = new Point(93, 128);
            txtKelvin.Name = "txtKelvin";
            txtKelvin.Size = new Size(100, 23);
            txtKelvin.TabIndex = 9;
            txtKelvin.Leave += txtKelvin_Leave;
            // 
            // txtFahrenheit
            // 
            txtFahrenheit.Location = new Point(93, 54);
            txtFahrenheit.Name = "txtFahrenheit";
            txtFahrenheit.Size = new Size(100, 23);
            txtFahrenheit.TabIndex = 10;
            txtFahrenheit.Leave += txtFahrenheit_Leave;
            // 
            // txtCelsius
            // 
            txtCelsius.Location = new Point(93, 90);
            txtCelsius.Name = "txtCelsius";
            txtCelsius.Size = new Size(100, 23);
            txtCelsius.TabIndex = 11;
            txtCelsius.Leave += txtCelsius_Leave;
            // 
            // txtFahrenheitAFahrenheit
            // 
            txtFahrenheitAFahrenheit.Enabled = false;
            txtFahrenheitAFahrenheit.Location = new Point(280, 54);
            txtFahrenheitAFahrenheit.Name = "txtFahrenheitAFahrenheit";
            txtFahrenheitAFahrenheit.Size = new Size(100, 23);
            txtFahrenheitAFahrenheit.TabIndex = 12;
            // 
            // txtFahrenheitACelsius
            // 
            txtFahrenheitACelsius.Enabled = false;
            txtFahrenheitACelsius.Location = new Point(386, 54);
            txtFahrenheitACelsius.Name = "txtFahrenheitACelsius";
            txtFahrenheitACelsius.Size = new Size(100, 23);
            txtFahrenheitACelsius.TabIndex = 13;
            // 
            // txtFahrenheitAKelvin
            // 
            txtFahrenheitAKelvin.Enabled = false;
            txtFahrenheitAKelvin.Location = new Point(492, 54);
            txtFahrenheitAKelvin.Name = "txtFahrenheitAKelvin";
            txtFahrenheitAKelvin.Size = new Size(100, 23);
            txtFahrenheitAKelvin.TabIndex = 14;
            // 
            // txtCelsiusAFahrenheit
            // 
            txtCelsiusAFahrenheit.Enabled = false;
            txtCelsiusAFahrenheit.Location = new Point(280, 90);
            txtCelsiusAFahrenheit.Name = "txtCelsiusAFahrenheit";
            txtCelsiusAFahrenheit.Size = new Size(100, 23);
            txtCelsiusAFahrenheit.TabIndex = 15;
            // 
            // txtCelsiusACelsius
            // 
            txtCelsiusACelsius.Enabled = false;
            txtCelsiusACelsius.Location = new Point(386, 90);
            txtCelsiusACelsius.Name = "txtCelsiusACelsius";
            txtCelsiusACelsius.Size = new Size(100, 23);
            txtCelsiusACelsius.TabIndex = 16;
            // 
            // txtCelsiusAKelvin
            // 
            txtCelsiusAKelvin.Enabled = false;
            txtCelsiusAKelvin.Location = new Point(492, 90);
            txtCelsiusAKelvin.Name = "txtCelsiusAKelvin";
            txtCelsiusAKelvin.Size = new Size(100, 23);
            txtCelsiusAKelvin.TabIndex = 17;
            // 
            // txtKelvinAFahrenheit
            // 
            txtKelvinAFahrenheit.Enabled = false;
            txtKelvinAFahrenheit.Location = new Point(280, 128);
            txtKelvinAFahrenheit.Name = "txtKelvinAFahrenheit";
            txtKelvinAFahrenheit.Size = new Size(100, 23);
            txtKelvinAFahrenheit.TabIndex = 18;
            // 
            // txtKelvinACelsius
            // 
            txtKelvinACelsius.Enabled = false;
            txtKelvinACelsius.Location = new Point(386, 128);
            txtKelvinACelsius.Name = "txtKelvinACelsius";
            txtKelvinACelsius.Size = new Size(100, 23);
            txtKelvinACelsius.TabIndex = 19;
            // 
            // txtKelvinAKelvin
            // 
            txtKelvinAKelvin.Enabled = false;
            txtKelvinAKelvin.Location = new Point(492, 128);
            txtKelvinAKelvin.Name = "txtKelvinAKelvin";
            txtKelvinAKelvin.Size = new Size(100, 23);
            txtKelvinAKelvin.TabIndex = 20;
            // 
            // FrmConversor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 182);
            Controls.Add(txtKelvinAKelvin);
            Controls.Add(txtKelvinACelsius);
            Controls.Add(txtKelvinAFahrenheit);
            Controls.Add(txtCelsiusAKelvin);
            Controls.Add(txtCelsiusACelsius);
            Controls.Add(txtCelsiusAFahrenheit);
            Controls.Add(txtFahrenheitAKelvin);
            Controls.Add(txtFahrenheitACelsius);
            Controls.Add(txtFahrenheitAFahrenheit);
            Controls.Add(txtCelsius);
            Controls.Add(txtFahrenheit);
            Controls.Add(txtKelvin);
            Controls.Add(btnKelvin);
            Controls.Add(btnCelsius);
            Controls.Add(btnFahrenheit);
            Controls.Add(lblKelvinA);
            Controls.Add(lblCelsiusA);
            Controls.Add(lblFahrenheitA);
            Controls.Add(lblKelvin);
            Controls.Add(lblCelsius);
            Controls.Add(lblFahrenheit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmConversor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conversor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFahrenheit;
        private Label lblCelsius;
        private Label lblKelvin;
        private Label lblFahrenheitA;
        private Label lblCelsiusA;
        private Label lblKelvinA;
        private Button btnFahrenheit;
        private Button btnCelsius;
        private Button btnKelvin;
        private TextBox txtKelvin;
        private TextBox txtFahrenheit;
        private TextBox txtCelsius;
        private TextBox txtFahrenheitAFahrenheit;
        private TextBox txtFahrenheitACelsius;
        private TextBox txtFahrenheitAKelvin;
        private TextBox txtCelsiusAFahrenheit;
        private TextBox txtCelsiusACelsius;
        private TextBox txtCelsiusAKelvin;
        private TextBox txtKelvinAFahrenheit;
        private TextBox txtKelvinACelsius;
        private TextBox txtKelvinAKelvin;
    }
}