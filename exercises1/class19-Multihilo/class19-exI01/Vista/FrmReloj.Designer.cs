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
            SuspendLayout();
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblHora.Location = new Point(12, 9);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(71, 30);
            lblHora.TabIndex = 1;
            lblHora.Text = "label1";
            // 
            // FrmReloj
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 68);
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
    }
}