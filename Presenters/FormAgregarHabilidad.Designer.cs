namespace SistemaRRHH.Presenters
{
    partial class FormAgregarHabilidad
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxNombreHabilidad = new System.Windows.Forms.TextBox();
            this.btnAgregarNuevaHabilidad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxNombreCompetencia = new System.Windows.Forms.TextBox();
            this.btnAgregarNuevaCompetencia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de habilidad";
            // 
            // txtBoxNombreHabilidad
            // 
            this.txtBoxNombreHabilidad.Location = new System.Drawing.Point(254, 69);
            this.txtBoxNombreHabilidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxNombreHabilidad.Name = "txtBoxNombreHabilidad";
            this.txtBoxNombreHabilidad.Size = new System.Drawing.Size(148, 20);
            this.txtBoxNombreHabilidad.TabIndex = 2;
            this.txtBoxNombreHabilidad.TextChanged += new System.EventHandler(this.txtBoxNombreHabilidad_TextChanged);
            // 
            // btnAgregarNuevaHabilidad
            // 
            this.btnAgregarNuevaHabilidad.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgregarNuevaHabilidad.FlatAppearance.BorderSize = 0;
            this.btnAgregarNuevaHabilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarNuevaHabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarNuevaHabilidad.ForeColor = System.Drawing.Color.White;
            this.btnAgregarNuevaHabilidad.Location = new System.Drawing.Point(298, 116);
            this.btnAgregarNuevaHabilidad.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarNuevaHabilidad.Name = "btnAgregarNuevaHabilidad";
            this.btnAgregarNuevaHabilidad.Size = new System.Drawing.Size(67, 30);
            this.btnAgregarNuevaHabilidad.TabIndex = 3;
            this.btnAgregarNuevaHabilidad.Text = "Agregar";
            this.btnAgregarNuevaHabilidad.UseVisualStyleBackColor = false;
            this.btnAgregarNuevaHabilidad.Click += new System.EventHandler(this.btnAgregarNuevaHabilidad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(159, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ingresar nueva habilidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(143, 199);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ingresar nueva competencia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre de Competencia";
            // 
            // txtBoxNombreCompetencia
            // 
            this.txtBoxNombreCompetencia.Location = new System.Drawing.Point(254, 247);
            this.txtBoxNombreCompetencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxNombreCompetencia.Name = "txtBoxNombreCompetencia";
            this.txtBoxNombreCompetencia.Size = new System.Drawing.Size(148, 20);
            this.txtBoxNombreCompetencia.TabIndex = 7;
            this.txtBoxNombreCompetencia.TextChanged += new System.EventHandler(this.txtBoxNombreCompetencia_TextChanged);
            // 
            // btnAgregarNuevaCompetencia
            // 
            this.btnAgregarNuevaCompetencia.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgregarNuevaCompetencia.FlatAppearance.BorderSize = 0;
            this.btnAgregarNuevaCompetencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarNuevaCompetencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarNuevaCompetencia.ForeColor = System.Drawing.Color.White;
            this.btnAgregarNuevaCompetencia.Location = new System.Drawing.Point(287, 302);
            this.btnAgregarNuevaCompetencia.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarNuevaCompetencia.Name = "btnAgregarNuevaCompetencia";
            this.btnAgregarNuevaCompetencia.Size = new System.Drawing.Size(67, 30);
            this.btnAgregarNuevaCompetencia.TabIndex = 8;
            this.btnAgregarNuevaCompetencia.Text = "Agregar";
            this.btnAgregarNuevaCompetencia.UseVisualStyleBackColor = false;
            this.btnAgregarNuevaCompetencia.Click += new System.EventHandler(this.btnAgregarNuevaCompetencia_Click);
            // 
            // FormAgregarHabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(964, 586);
            this.ControlBox = false;
            this.Controls.Add(this.btnAgregarNuevaCompetencia);
            this.Controls.Add(this.txtBoxNombreCompetencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregarNuevaHabilidad);
            this.Controls.Add(this.txtBoxNombreHabilidad);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAgregarHabilidad";
            this.Text = "FormAgregarHabilidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxNombreCompetencia;
        public System.Windows.Forms.Button btnAgregarNuevaHabilidad;
        public System.Windows.Forms.TextBox txtBoxNombreHabilidad;
        public System.Windows.Forms.Button btnAgregarNuevaCompetencia;
    }
}