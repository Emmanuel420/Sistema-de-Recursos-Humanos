namespace SistemaRRHH.Presenters
{
    partial class formularioCandidato
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
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.dataGridViewCandidatos = new System.Windows.Forms.DataGridView();
            this.txtTotalPagina = new System.Windows.Forms.TextBox();
            this.labelTotalPagina = new System.Windows.Forms.Label();
            this.cmbPagina = new System.Windows.Forms.ComboBox();
            this.labelPagina = new System.Windows.Forms.Label();
            this.btnVer1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCandidatos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(51, 71);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(234, 20);
            this.txtBusqueda.TabIndex = 38;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(313, 71);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(64, 23);
            this.btnBusqueda.TabIndex = 39;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCandidatos
            // 
            this.dataGridViewCandidatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCandidatos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCandidatos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCandidatos.Location = new System.Drawing.Point(51, 118);
            this.dataGridViewCandidatos.Name = "dataGridViewCandidatos";
            this.dataGridViewCandidatos.Size = new System.Drawing.Size(566, 208);
            this.dataGridViewCandidatos.TabIndex = 40;
            this.dataGridViewCandidatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCandidatos_CellContentClick);
            this.dataGridViewCandidatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewCandidatos_DataBindingComplete);
            // 
            // txtTotalPagina
            // 
            this.txtTotalPagina.Location = new System.Drawing.Point(373, 357);
            this.txtTotalPagina.Name = "txtTotalPagina";
            this.txtTotalPagina.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPagina.TabIndex = 46;
            // 
            // labelTotalPagina
            // 
            this.labelTotalPagina.AutoSize = true;
            this.labelTotalPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPagina.ForeColor = System.Drawing.Color.White;
            this.labelTotalPagina.Location = new System.Drawing.Point(343, 360);
            this.labelTotalPagina.Name = "labelTotalPagina";
            this.labelTotalPagina.Size = new System.Drawing.Size(24, 18);
            this.labelTotalPagina.TabIndex = 45;
            this.labelTotalPagina.Text = "de";
            // 
            // cmbPagina
            // 
            this.cmbPagina.FormattingEnabled = true;
            this.cmbPagina.Location = new System.Drawing.Point(231, 357);
            this.cmbPagina.Name = "cmbPagina";
            this.cmbPagina.Size = new System.Drawing.Size(93, 21);
            this.cmbPagina.TabIndex = 44;
            // 
            // labelPagina
            // 
            this.labelPagina.AutoSize = true;
            this.labelPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPagina.ForeColor = System.Drawing.Color.White;
            this.labelPagina.Location = new System.Drawing.Point(172, 357);
            this.labelPagina.Name = "labelPagina";
            this.labelPagina.Size = new System.Drawing.Size(53, 18);
            this.labelPagina.TabIndex = 43;
            this.labelPagina.Text = "Pagina";
            // 
            // btnVer1
            // 
            this.btnVer1.Location = new System.Drawing.Point(464, 71);
            this.btnVer1.Name = "btnVer1";
            this.btnVer1.Size = new System.Drawing.Size(75, 23);
            this.btnVer1.TabIndex = 47;
            this.btnVer1.Text = "Ver";
            this.btnVer1.UseVisualStyleBackColor = true;
            this.btnVer1.Click += new System.EventHandler(this.btnVer1_Click);
            // 
            // formularioCandidato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1017, 619);
            this.Controls.Add(this.btnVer1);
            this.Controls.Add(this.txtTotalPagina);
            this.Controls.Add(this.labelTotalPagina);
            this.Controls.Add(this.cmbPagina);
            this.Controls.Add(this.labelPagina);
            this.Controls.Add(this.dataGridViewCandidatos);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.txtBusqueda);
            this.Name = "formularioCandidato";
            this.Text = "FormPantallaCandidato";
            this.Load += new System.EventHandler(this.FormPantallaCandidato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCandidatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.DataGridView dataGridViewCandidatos;
        private System.Windows.Forms.TextBox txtTotalPagina;
        private System.Windows.Forms.Label labelTotalPagina;
        private System.Windows.Forms.ComboBox cmbPagina;
        private System.Windows.Forms.Label labelPagina;
        private System.Windows.Forms.Button btnVer1;
	}
}