namespace SistemaRRHH.Presenters
{
    partial class formularioUsers
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
            this.dataGridViewCandidatos = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.labelPagina = new System.Windows.Forms.Label();
            this.cmbPagina = new System.Windows.Forms.ComboBox();
            this.labelTotalPagina = new System.Windows.Forms.Label();
            this.txtTotalPagina = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCandidatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCandidatos
            // 
            this.dataGridViewCandidatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCandidatos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCandidatos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCandidatos.Location = new System.Drawing.Point(60, 112);
            this.dataGridViewCandidatos.Name = "dataGridViewCandidatos";
            this.dataGridViewCandidatos.Size = new System.Drawing.Size(524, 208);
            this.dataGridViewCandidatos.TabIndex = 0;
            this.dataGridViewCandidatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCandidatos_CellContentClick);
            this.dataGridViewCandidatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewCandidatos_DataBindingComplete);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(60, 60);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(282, 20);
            this.txtBusqueda.TabIndex = 37;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(401, 58);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(125, 23);
            this.btnBusqueda.TabIndex = 38;
            this.btnBusqueda.Text = "Busqueda Avanzada";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            // 
            // labelPagina
            // 
            this.labelPagina.AutoSize = true;
            this.labelPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPagina.ForeColor = System.Drawing.Color.White;
            this.labelPagina.Location = new System.Drawing.Point(124, 356);
            this.labelPagina.Name = "labelPagina";
            this.labelPagina.Size = new System.Drawing.Size(53, 18);
            this.labelPagina.TabIndex = 39;
            this.labelPagina.Text = "Pagina";
            // 
            // cmbPagina
            // 
            this.cmbPagina.FormattingEnabled = true;
            this.cmbPagina.Location = new System.Drawing.Point(183, 356);
            this.cmbPagina.Name = "cmbPagina";
            this.cmbPagina.Size = new System.Drawing.Size(93, 21);
            this.cmbPagina.TabIndex = 40;
            // 
            // labelTotalPagina
            // 
            this.labelTotalPagina.AutoSize = true;
            this.labelTotalPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPagina.ForeColor = System.Drawing.Color.White;
            this.labelTotalPagina.Location = new System.Drawing.Point(295, 359);
            this.labelTotalPagina.Name = "labelTotalPagina";
            this.labelTotalPagina.Size = new System.Drawing.Size(24, 18);
            this.labelTotalPagina.TabIndex = 41;
            this.labelTotalPagina.Text = "de";
            // 
            // txtTotalPagina
            // 
            this.txtTotalPagina.Location = new System.Drawing.Point(325, 356);
            this.txtTotalPagina.Name = "txtTotalPagina";
            this.txtTotalPagina.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPagina.TabIndex = 42;
            // 
            // formularioUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1017, 619);
            this.Controls.Add(this.txtTotalPagina);
            this.Controls.Add(this.labelTotalPagina);
            this.Controls.Add(this.cmbPagina);
            this.Controls.Add(this.labelPagina);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.dataGridViewCandidatos);
            this.Name = "formularioUsers";
            this.Text = "FormAdminUsers";
            this.Load += new System.EventHandler(this.formularioUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCandidatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCandidatos;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Label labelPagina;
        private System.Windows.Forms.ComboBox cmbPagina;
        private System.Windows.Forms.Label labelTotalPagina;
        private System.Windows.Forms.TextBox txtTotalPagina;
	}
}