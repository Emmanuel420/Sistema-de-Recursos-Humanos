using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRRHH.Cache;


namespace SistemaRRHH.Presenters
{
    public partial class FormPrincipal : Form
    {


        public FormPrincipal()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.ControlBox = false;
            this.IsMdiContainer = true; // Establecer como contenedor MDI
            AbrirFormulario<formularioCandidato>();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Cierra todos los formularios hijos, incluido formularioCandidato
            foreach (Form mdiChild in this.MdiChildren)
            {
                mdiChild.Close();
            }
        }



        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();

            // Así se controla los roles de los usuarios
            if (UsuarioLoginCache.IdRol == 3)
            {
                btnAdminCandi.Visible = true;
            }

            if (UsuarioLoginCache.IdRol == 1)
            {
                btnAdminCandi.Visible = true;
                btnAdminUsers.Visible = true;
                btnGestionSistema.Visible = true;
            }
        }

        //Metodo para cargar los datos del Usuario
        private void LoadUserData()
        {
            lblNombreUsuario.Text = UsuarioLoginCache.Username;
            switch (UsuarioLoginCache.IdRol)
            {
                case 1:
                    lblPosition.Text = "Administrador";
                    break;

                case 2:
                    lblPosition.Text = "Reclutador";
                    break;

                case 3:
                    lblPosition.Text = "Gerente RRHH";
                    break;

                default:
                    lblPosition.Text = "Otro rol";
                    break;
            }
            lblEmail.Text = UsuarioLoginCache.Email;

        }


        //Metodo para abrir formularios dentro del panel
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault(); //Busca en la colección el formulario

            // Si el formulario no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                formulario.MdiParent = this; // Establecer el formulario contenedor
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            // Si el formulario/instancia Existe
            else
            {
                formulario.BringToFront();
            }
        }



        private void btnAdminCandi_Click(object sender, EventArgs e)
        {
            //Aquí ponemos el nombre del formulario
            AbrirFormulario<FormAdmiCandidato>();
            btnAdminCandi.BackColor = Color.FromArgb(12, 61, 92);
        }


        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            //Dentro de las comillas debe ir el nombnre del formulario
            if (Application.OpenForms["form1"] == null)
            {
                btnAdminCandi.BackColor = Color.FromArgb(4, 41, 68);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Usted está a punto de cerrar sesión ¿Está de acuerdo?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void btnAdminUsers_Click(object sender, EventArgs e)
        {

            AbrirFormulario<formAdminUsers>();
        }

        private void btnVerCandidatos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<formularioCandidato>();
        }

        private void panelFormularios_Paint(object sender, PaintEventArgs e)
        {

        }

        public void AbrirFormularioEnPanel(Form formulario)
        {
            panelFormularios.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formulario);
            panelFormularios.Tag = formulario;
            formulario.Show();
            formulario.BringToFront();
            formulario.FormClosed += new FormClosedEventHandler(CloseForms);
        }

        private void btnGenerarReportes_Click(object sender, EventArgs e)
        {
            // Instanciando
            frmVisorReporte reporte = new frmVisorReporte();

            // Mostrar la forma
            reporte.ShowDialog();

        }

        private void btnGestionSistema_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<FormGestionSistema>();
            AbrirFormulario<FormAgregarHabilidad>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormAcercaDe>();
        }
    }
}
