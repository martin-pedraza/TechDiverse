namespace Vista
{
    partial class FrmLlamador
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
            txtNroDestino = new TextBox();
            txtNroOrigen = new TextBox();
            btnNumeral = new Button();
            btn0 = new Button();
            btnAsterisco = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            cmbFranja = new ComboBox();
            btnLlamar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            gboPanel = new GroupBox();
            gboPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtNroDestino
            // 
            txtNroDestino.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            txtNroDestino.Location = new Point(12, 12);
            txtNroDestino.Name = "txtNroDestino";
            txtNroDestino.PlaceholderText = "Nro Destino";
            txtNroDestino.ReadOnly = true;
            txtNroDestino.Size = new Size(227, 36);
            txtNroDestino.TabIndex = 0;
            txtNroDestino.TextChanged += txtNroDestino_TextChanged;
            // 
            // txtNroOrigen
            // 
            txtNroOrigen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtNroOrigen.Location = new Point(139, 117);
            txtNroOrigen.Name = "txtNroOrigen";
            txtNroOrigen.PlaceholderText = "Nro Origen";
            txtNroOrigen.ReadOnly = true;
            txtNroOrigen.Size = new Size(100, 23);
            txtNroOrigen.TabIndex = 1;
            // 
            // btnNumeral
            // 
            btnNumeral.Location = new Point(78, 131);
            btnNumeral.Name = "btnNumeral";
            btnNumeral.Size = new Size(30, 30);
            btnNumeral.TabIndex = 17;
            btnNumeral.Text = "#";
            btnNumeral.UseVisualStyleBackColor = true;
            btnNumeral.Click += btnNumeral_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(42, 130);
            btn0.Name = "btn0";
            btn0.Size = new Size(30, 30);
            btn0.TabIndex = 16;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btn0_Click;
            // 
            // btnAsterisco
            // 
            btnAsterisco.Location = new Point(6, 130);
            btnAsterisco.Name = "btnAsterisco";
            btnAsterisco.Size = new Size(30, 30);
            btnAsterisco.TabIndex = 15;
            btnAsterisco.Text = "*";
            btnAsterisco.UseVisualStyleBackColor = true;
            btnAsterisco.Click += btnAsterisco_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(78, 95);
            btn9.Name = "btn9";
            btn9.Size = new Size(30, 30);
            btn9.TabIndex = 14;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(42, 94);
            btn8.Name = "btn8";
            btn8.Size = new Size(30, 30);
            btn8.TabIndex = 13;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(6, 94);
            btn7.Name = "btn7";
            btn7.Size = new Size(30, 30);
            btn7.TabIndex = 12;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(78, 58);
            btn6.Name = "btn6";
            btn6.Size = new Size(30, 30);
            btn6.TabIndex = 11;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(42, 58);
            btn5.Name = "btn5";
            btn5.Size = new Size(30, 30);
            btn5.TabIndex = 10;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(6, 58);
            btn4.Name = "btn4";
            btn4.Size = new Size(30, 30);
            btn4.TabIndex = 9;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(78, 22);
            btn3.Name = "btn3";
            btn3.Size = new Size(30, 30);
            btn3.TabIndex = 8;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(42, 22);
            btn2.Name = "btn2";
            btn2.Size = new Size(30, 30);
            btn2.TabIndex = 7;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(6, 22);
            btn1.Name = "btn1";
            btn1.Size = new Size(30, 30);
            btn1.TabIndex = 6;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // cmbFranja
            // 
            cmbFranja.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFranja.FormattingEnabled = true;
            cmbFranja.Location = new Point(12, 240);
            cmbFranja.Name = "cmbFranja";
            cmbFranja.Size = new Size(227, 23);
            cmbFranja.TabIndex = 0;
            // 
            // btnLlamar
            // 
            btnLlamar.Location = new Point(139, 76);
            btnLlamar.Name = "btnLlamar";
            btnLlamar.Size = new Size(100, 23);
            btnLlamar.TabIndex = 3;
            btnLlamar.Text = "Llamar";
            btnLlamar.UseVisualStyleBackColor = true;
            btnLlamar.Click += btnLlamar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(139, 153);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 23);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(139, 189);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(100, 23);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // gboPanel
            // 
            gboPanel.Controls.Add(btn1);
            gboPanel.Controls.Add(btnNumeral);
            gboPanel.Controls.Add(btn5);
            gboPanel.Controls.Add(btn3);
            gboPanel.Controls.Add(btn0);
            gboPanel.Controls.Add(btn4);
            gboPanel.Controls.Add(btn2);
            gboPanel.Controls.Add(btnAsterisco);
            gboPanel.Controls.Add(btn6);
            gboPanel.Controls.Add(btn7);
            gboPanel.Controls.Add(btn9);
            gboPanel.Controls.Add(btn8);
            gboPanel.Location = new Point(12, 54);
            gboPanel.Name = "gboPanel";
            gboPanel.Size = new Size(121, 180);
            gboPanel.TabIndex = 18;
            gboPanel.TabStop = false;
            gboPanel.Text = "Panel";
            // 
            // FrmLlamador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 281);
            Controls.Add(gboPanel);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnLlamar);
            Controls.Add(cmbFranja);
            Controls.Add(txtNroOrigen);
            Controls.Add(txtNroDestino);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLlamador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Llamador";
            Load += FrmLlamador_Load;
            gboPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNroDestino;
        private TextBox txtNroOrigen;
        private Button btnNumeral;
        private Button btn0;
        private Button btnAsterisco;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btn3;
        private Button btn2;
        private Button btn1;
        private ComboBox cmbFranja;
        private Button btnLlamar;
        private Button btnLimpiar;
        private Button btnSalir;
        private GroupBox gboPanel;
    }
}