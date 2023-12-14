namespace class05_exI01
{
    partial class FormSaludo
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
            lblTitulo = new Label();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblTitulo.Location = new Point(180, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(219, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "¡Hola, Windows Forms!";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMensaje.Location = new Point(54, 87);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 21);
            lblMensaje.TabIndex = 1;
            // 
            // FormSaludo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 157);
            Controls.Add(lblMensaje);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSaludo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Saludo";
            Load += FormSaludo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMensaje;
    }
}