namespace Vista
{
    partial class FrmListaSuper
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
            components = new System.ComponentModel.Container();
            lstObjetos = new ListBox();
            btnAgregar = new Button();
            toolTip1 = new ToolTip(components);
            btnEliminar = new Button();
            btnModificar = new Button();
            SuspendLayout();
            // 
            // lstObjetos
            // 
            lstObjetos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstObjetos.FormattingEnabled = true;
            lstObjetos.ItemHeight = 15;
            lstObjetos.Location = new Point(12, 12);
            lstObjetos.Name = "lstObjetos";
            lstObjetos.Size = new Size(228, 274);
            lstObjetos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location = new Point(246, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(40, 40);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "+";
            toolTip1.SetToolTip(btnAgregar, "Agregar objeto");
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.Location = new Point(246, 58);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(40, 40);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "-";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificar.Location = new Point(246, 104);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(40, 40);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "M";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // FrmListaSuper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 294);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(lstObjetos);
            Name = "FrmListaSuper";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de supermercado";
            Load += FrmListaSuper_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstObjetos;
        private Button btnAgregar;
        private ToolTip toolTip1;
        private Button btnEliminar;
        private Button btnModificar;
    }
}