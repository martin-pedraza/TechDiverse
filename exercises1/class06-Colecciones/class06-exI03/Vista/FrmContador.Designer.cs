namespace Vista
{
    partial class FrmContador
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
            rboTexto = new RichTextBox();
            btnCalcular = new Button();
            SuspendLayout();
            // 
            // rboTexto
            // 
            rboTexto.Location = new Point(0, 0);
            rboTexto.Name = "rboTexto";
            rboTexto.Size = new Size(491, 409);
            rboTexto.TabIndex = 0;
            rboTexto.Text = "";
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(404, 415);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(75, 23);
            btnCalcular.TabIndex = 1;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // FrmContador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 450);
            Controls.Add(btnCalcular);
            Controls.Add(rboTexto);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmContador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contador de Palabras";
            Load += FrmContador_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rboTexto;
        private Button btnCalcular;
    }
}