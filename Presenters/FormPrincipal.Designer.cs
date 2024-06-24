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
            this.btnGestionSistema = new System.Windows.Forms.Button();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelBarraLateral.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBarraLateral
            // 
            this.panelBarraLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.panelBarraLateral.Controls.Add(this.btnGestionSistema);
            this.panelBarraLateral.Controls.Add(this.btnVerCandidatos);
            this.panelBarraLateral.Controls.Add(this.btnLogOut);
            this.panelBarraLateral.Controls.Add(this.panelUsuario);
            this.panelBarraLateral.Controls.Add(this.btnAdminUsers);
            this.panelBarraLateral.Controls.Add(this.btnGenerarReportes);
            this.panelBarraLateral.Controls.Add(this.btnAdminCandi);
            this.panelBarraLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBarraLateral.Location = new System.Drawing.Point(0, 0);
            this.panelBarraLateral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelBarraLateral.Name = "panelBarraLateral";
            this.panelBarraLateral.Size = new System.Drawing.Size(375, 1050);
            this.panelBarraLateral.TabIndex = 0;
            // 
            // btnGestionSistema
            // 
            this.btnGestionSistema.FlatAppearance.BorderSize = 0;
            this.btnGestionSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionSistema.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionSistema.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGestionSistema.Location = new System.Drawing.Point(0, 780);
            this.btnGestionSistema.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGestionSistema.Name = "btnGestionSistema";
            this.btnGestionSistema.Size = new System.Drawing.Size(375, 123);
            this.btnGestionSistema.TabIndex = 6;
            this.btnGestionSistema.Text = "Gestión del Sistema";
            this.btnGestionSistema.UseVisualStyleBackColor = true;
            this.btnGestionSistema.Visible = false;
            this.btnGestionSistema.Click += new System.EventHandler(this.btnGestionSistema_Click);
            // 
            // btnVerCandidatos
            // 
            this.btnVerCandidatos.FlatAppearance.BorderSize = 0;
            this.btnVerCandidatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerCandidatos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCandidatos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVerCandidatos.Location = new System.Drawing.Point(0, 251);
            this.btnVerCandidatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVerCandidatos.Name = "btnVerCandidatos";
            this.btnVerCandidatos.Size = new System.Drawing.Size(375, 123);
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
            this.btnLogOut.Location = new System.Drawing.Point(0, 987);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(375, 63);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Cerrar Sesión";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelUsuario.Controls.Add(this.pictureBox2);
            this.panelUsuario.Controls.Add(this.pictureBox1);
            this.panelUsuario.Controls.Add(this.lblEmail);
            this.panelUsuario.Controls.Add(this.lblPosition);
            this.panelUsuario.Controls.Add(this.lblNombreUsuario);
            this.panelUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUsuario.Location = new System.Drawing.Point(0, 0);
            this.panelUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(375, 231);
            this.panelUsuario.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(153, 158);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(153, 112);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(65, 20);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "Position";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(153, 62);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(87, 26);
            this.lblNombreUsuario.TabIndex = 0;
            this.lblNombreUsuario.Text = "Usuario";
            // 
            // btnAdminUsers
            // 
            this.btnAdminUsers.FlatAppearance.BorderSize = 0;
            this.btnAdminUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminUsers.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdminUsers.Location = new System.Drawing.Point(0, 648);
            this.btnAdminUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdminUsers.Name = "btnAdminUsers";
            this.btnAdminUsers.Size = new System.Drawing.Size(375, 123);
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
            this.btnGenerarReportes.Location = new System.Drawing.Point(0, 383);
            this.btnGenerarReportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerarReportes.Name = "btnGenerarReportes";
            this.btnGenerarReportes.Size = new System.Drawing.Size(375, 123);
            this.btnGenerarReportes.TabIndex = 1;
            this.btnGenerarReportes.Text = "Generar Reportes";
            this.btnGenerarReportes.UseVisualStyleBackColor = true;
            this.btnGenerarReportes.Click += new System.EventHandler(this.btnGenerarReportes_Click);
            // 
            // btnAdminCandi
            // 
            this.btnAdminCandi.FlatAppearance.BorderSize = 0;
            this.btnAdminCandi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminCandi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminCandi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdminCandi.Location = new System.Drawing.Point(0, 515);
            this.btnAdminCandi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdminCandi.Name = "btnAdminCandi";
            this.btnAdminCandi.Size = new System.Drawing.Size(375, 123);
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
            this.panelFormularios.Location = new System.Drawing.Point(375, 0);
            this.panelFormularios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(1549, 1050);
            this.panelFormularios.TabIndex = 1;
            this.panelFormularios.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFormularios_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaRRHH.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(32, 75);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SistemaRRHH.Properties.Resources.about;
            this.pictureBox2.Location = new System.Drawing.Point(309, 182);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.panelFormularios);
            this.Controls.Add(this.panelBarraLateral);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelBarraLateral.ResumeLayout(false);
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarraLateral;
        private System.Windows.Forms.Button btnAdminUsers;
        private System.Windows.Forms.Button btnGenerarReportes;
        private System.Windows.Forms.Button btnAdminCandi;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnVerCandidatos;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.Button btnGestionSistema;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}