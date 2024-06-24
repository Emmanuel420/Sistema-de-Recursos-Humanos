namespace SistemaRRHH.Presenters
{
    partial class FormPrincipal
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
            this.panelBarraLateral = new System.Windows.Forms.Panel();
            this.btnVerCandidatos = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.btnAdminUsers = new System.Windows.Forms.Button();
            this.btnGenerarReportes = new System.Windows.Forms.Button();
            this.btnAdminCandi = new System.Windows.Forms.Button();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.panelBarraLateral.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBarraLateral
            // 
            this.panelBarraLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.panelBarraLateral.Controls.Add(this.btnVerCandidatos);
            this.panelBarraLateral.Controls.Add(this.btnLogOut);
            this.panelBarraLateral.Controls.Add(this.panelUsuario);
            this.panelBarraLateral.Controls.Add(this.btnAdminUsers);
            this.panelBarraLateral.Controls.Add(this.btnGenerarReportes);
            this.panelBarraLateral.Controls.Add(this.btnAdminCandi);
            this.panelBarraLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBarraLateral.Location = new System.Drawing.Point(0, 0);
            this.panelBarraLateral.Name = "panelBarraLateral";
            this.panelBarraLateral.Size = new System.Drawing.Size(250, 659);
            this.panelBarraLateral.TabIndex = 0;
            // 
            // btnVerCandidatos
            // 
            this.btnVerCandidatos.FlatAppearance.BorderSize = 0;
            this.btnVerCandidatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerCandidatos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCandidatos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVerCandidatos.Location = new System.Drawing.Point(0, 216);
            this.btnVerCandidatos.Name = "btnVerCandidatos";
            this.btnVerCandidatos.Size = new System.Drawing.Size(250, 80);
            this.btnVerCandidatos.TabIndex = 5;
            this.btnVerCandidatos.Text = "Ver Candidatos";
            this.btnVerCandidatos.UseVisualStyleBackColor = true;
            this.btnVerCandidatos.Click += new System.EventHandler(this.btnVerCandidatos_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(0, 618);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(250, 41);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Cerrar Sesión";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelUsuario.Controls.Add(this.lblEmail);
            this.panelUsuario.Controls.Add(this.lblPosition);
            this.panelUsuario.Controls.Add(this.lblNombreUsuario);
            this.panelUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUsuario.Location = new System.Drawing.Point(0, 0);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(250, 150);
            this.panelUsuario.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(78, 102);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(78, 69);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(65, 20);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "Position";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(78, 36);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(64, 20);
            this.lblNombreUsuario.TabIndex = 0;
            this.lblNombreUsuario.Text = "Usuario";
            // 
            // btnAdminUsers
            // 
            this.btnAdminUsers.FlatAppearance.BorderSize = 0;
            this.btnAdminUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminUsers.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdminUsers.Location = new System.Drawing.Point(0, 474);
            this.btnAdminUsers.Name = "btnAdminUsers";
            this.btnAdminUsers.Size = new System.Drawing.Size(250, 80);
            this.btnAdminUsers.TabIndex = 2;
            this.btnAdminUsers.Text = "Administrar Usuarios";
            this.btnAdminUsers.UseVisualStyleBackColor = true;
            this.btnAdminUsers.Visible = false;
            this.btnAdminUsers.Click += new System.EventHandler(this.btnAdminUsers_Click);
            // 
            // btnGenerarReportes
            // 
            this.btnGenerarReportes.FlatAppearance.BorderSize = 0;
            this.btnGenerarReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReportes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGenerarReportes.Location = new System.Drawing.Point(0, 302);
            this.btnGenerarReportes.Name = "btnGenerarReportes";
            this.btnGenerarReportes.Size = new System.Drawing.Size(250, 80);
            this.btnGenerarReportes.TabIndex = 1;
            this.btnGenerarReportes.Text = "Generar Reportes";
            this.btnGenerarReportes.UseVisualStyleBackColor = true;
            // 
            // btnAdminCandi
            // 
            this.btnAdminCandi.FlatAppearance.BorderSize = 0;
            this.btnAdminCandi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminCandi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminCandi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdminCandi.Location = new System.Drawing.Point(0, 388);
            this.btnAdminCandi.Name = "btnAdminCandi";
            this.btnAdminCandi.Size = new System.Drawing.Size(250, 80);
            this.btnAdminCandi.TabIndex = 0;
            this.btnAdminCandi.Text = "Administrar Candidatos";
            this.btnAdminCandi.UseVisualStyleBackColor = true;
            this.btnAdminCandi.Visible = false;
            this.btnAdminCandi.Click += new System.EventHandler(this.btnAdminCandi_Click);
            // 
            // panelFormularios
            // 
            this.panelFormularios.BackColor = System.Drawing.SystemColors.Control;
            this.panelFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFormularios.Location = new System.Drawing.Point(250, 0);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(990, 659);
            this.panelFormularios.TabIndex = 1;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1240, 659);
            this.Controls.Add(this.panelFormularios);
            this.Controls.Add(this.panelBarraLateral);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelBarraLateral.ResumeLayout(false);
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarraLateral;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.Button btnAdminUsers;
        private System.Windows.Forms.Button btnGenerarReportes;
        private System.Windows.Forms.Button btnAdminCandi;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnVerCandidatos;
    }
}