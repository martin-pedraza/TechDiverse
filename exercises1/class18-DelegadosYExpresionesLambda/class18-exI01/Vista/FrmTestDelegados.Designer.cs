namespace Vista
{
    partial class FrmTestDelegados
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
            btnActualizar = new Button();
            txtNombre = new TextBox();
            SuspendLayout();
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(12, 41);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(261, 23);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(261, 23);
            txtNombre.TabIndex = 1;
            // 
            // FrmTestDelegados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 78);
            Controls.Add(txtNombre);
            Controls.Add(btnActualizar);
            Name = "FrmTestDelegados";
            Text = "Test Delegados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnActualizar;
        private TextBox txtNombre;
    }
}