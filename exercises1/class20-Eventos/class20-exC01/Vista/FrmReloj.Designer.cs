namespace Vista
{
    partial class FrmReloj
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
            lblHora = new Label();
            lblTiempo = new Label();
            btnIniciar = new Button();
            btnDetener = new Button();
            SuspendLayout();
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblHora.Location = new Point(12, 9);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(61, 30);
            lblHora.TabIndex = 1;
            lblHora.Text = "Hora";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTiempo.Location = new Point(12, 82);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(87, 30);
            lblTiempo.TabIndex = 2;
            lblTiempo.Text = "Tiempo";
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(286, 16);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(75, 23);
            btnIniciar.TabIndex = 3;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnDetener
            // 
            btnDetener.Location = new Point(286, 89);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(75, 23);
            btnDetener.TabIndex = 4;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = true;
            btnDetener.Click += btnDetener_Click;
            // 
            // FrmReloj
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 121);
            Controls.Add(btnDetener);
            Controls.Add(btnIniciar);
            Controls.Add(lblTiempo);
            Controls.Add(lblHora);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmReloj";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hora";
            FormClosing += FrmReloj_FormClosing;
            Load += FrmReloj_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHora;
        private Label lblTiempo;
        private Button btnIniciar;
        private Button btnDetener;
    }
}