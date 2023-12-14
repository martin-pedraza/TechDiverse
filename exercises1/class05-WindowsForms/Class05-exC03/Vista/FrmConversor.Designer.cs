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
            lblBinario = new Label();
            lblDecimal = new Label();
            txtBinario = new TextBox();
            txtDecimal = new TextBox();
            txtBinarioADecimal = new TextBox();
            txtDecimalABinario = new TextBox();
            btnBinarioA = new Button();
            btnDecimalA = new Button();
            SuspendLayout();
            // 
            // lblBinario
            // 
            lblBinario.AutoSize = true;
            lblBinario.Location = new Point(12, 15);
            lblBinario.Name = "lblBinario";
            lblBinario.Size = new Size(98, 15);
            lblBinario.TabIndex = 0;
            lblBinario.Text = "Binario a decimal";
            // 
            // lblDecimal
            // 
            lblDecimal.AutoSize = true;
            lblDecimal.Location = new Point(12, 62);
            lblDecimal.Name = "lblDecimal";
            lblDecimal.Size = new Size(99, 15);
            lblDecimal.TabIndex = 1;
            lblDecimal.Text = "Decimal a binario";
            // 
            // txtBinario
            // 
            txtBinario.Location = new Point(129, 12);
            txtBinario.Name = "txtBinario";
            txtBinario.Size = new Size(141, 23);
            txtBinario.TabIndex = 2;
            txtBinario.TabStop = false;
            txtBinario.Leave += txtBinario_Leave;
            // 
            // txtDecimal
            // 
            txtDecimal.Location = new Point(129, 59);
            txtDecimal.Name = "txtDecimal";
            txtDecimal.Size = new Size(141, 23);
            txtDecimal.TabIndex = 3;
            txtDecimal.TabStop = false;
            txtDecimal.Leave += txtDecimal_Leave;
            // 
            // txtBinarioADecimal
            // 
            txtBinarioADecimal.Enabled = false;
            txtBinarioADecimal.Location = new Point(357, 12);
            txtBinarioADecimal.Name = "txtBinarioADecimal";
            txtBinarioADecimal.Size = new Size(141, 23);
            txtBinarioADecimal.TabIndex = 4;
            // 
            // txtDecimalABinario
            // 
            txtDecimalABinario.Enabled = false;
            txtDecimalABinario.Location = new Point(357, 59);
            txtDecimalABinario.Name = "txtDecimalABinario";
            txtDecimalABinario.Size = new Size(141, 23);
            txtDecimalABinario.TabIndex = 5;
            // 
            // btnBinarioA
            // 
            btnBinarioA.Location = new Point(276, 11);
            btnBinarioA.Name = "btnBinarioA";
            btnBinarioA.Size = new Size(75, 23);
            btnBinarioA.TabIndex = 6;
            btnBinarioA.Text = "->";
            btnBinarioA.UseVisualStyleBackColor = true;
            btnBinarioA.Click += btnBinarioA_Click;
            // 
            // btnDecimalA
            // 
            btnDecimalA.Location = new Point(276, 58);
            btnDecimalA.Name = "btnDecimalA";
            btnDecimalA.Size = new Size(75, 23);
            btnDecimalA.TabIndex = 7;
            btnDecimalA.Text = "->";
            btnDecimalA.UseVisualStyleBackColor = true;
            btnDecimalA.Click += btnDecimalA_Click;
            // 
            // FrmConversor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 110);
            Controls.Add(btnDecimalA);
            Controls.Add(btnBinarioA);
            Controls.Add(txtDecimalABinario);
            Controls.Add(txtBinarioADecimal);
            Controls.Add(txtDecimal);
            Controls.Add(txtBinario);
            Controls.Add(lblDecimal);
            Controls.Add(lblBinario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmConversor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conversor numerico";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBinario;
        private Label lblDecimal;
        private TextBox txtBinario;
        private TextBox txtDecimal;
        private TextBox txtBinarioADecimal;
        private TextBox txtDecimalABinario;
        private Button btnBinarioA;
        private Button btnDecimalA;
    }
}