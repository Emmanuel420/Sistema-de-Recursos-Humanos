using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_POE_Boceto
{
	public partial class FormCrearCandidato : Form
	{
        public void SetInformacionCandidato(
         string primerNombre, string segundoNombre,
         string primerApellido, string segundoApellido,
         string objetivo, string telefono, string email, string sexo , string estado, int edad)
        {
            // Asigna la información a los controles de FormPantallaPerfil
            txtNombrePerfil.Text = $"{primerNombre} {segundoNombre}";
            txtApellidoPerfil.Text = $"{primerApellido} {segundoApellido}";
            txtObjetivo.Text = objetivo;
            txtTelefonoPerfil.Text = telefono;
            txtEmail.Text = email;
            txtBoxEdad.Text = edad.ToString();
            txtBoxGenero.Text = sexo;
            txtBoxEstado.Text = estado;
        }

        public static FormCrearCandidato Instance { get; private set; }

        public FormCrearCandidato()
		{
			InitializeComponent();

        }

		private void btnAgregarHabilidad_Click(object sender, EventArgs e)
		{

		}

        private void txtNombrePerfil_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidoPerfil_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblApellido_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelTelefono_Click(object sender, EventArgs e)
        {

        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }

        private void labelDepartamento_Click(object sender, EventArgs e)
        {

        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormCrearCandidato_Load(object sender, EventArgs e)
        {

        }

        private void txtObjetivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefonoPerfil_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstBxHabilidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBxCompetencias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBxExpLabo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBxFormaAca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBxRefeLabo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBxRefePerso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblPantallaCrearCandidato_Click(object sender, EventArgs e)
        {

        }

        private void labelHabilidades_Click(object sender, EventArgs e)
        {

        }

        private void labelCompetencias_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxEdad_TextChanged(object sender, EventArgs e)
        {

        }

        public void SetImagenCandidato(byte[] imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imagen))
                {
                    pictureBoxFoto.Image = Image.FromStream(ms);
                }
            }
            else
            {
                // Puedes establecer una imagen predeterminada o dejar el pictureBoxFoto vacío
                // pictureBoxFoto.Image = Image.FromFile("ruta de la imagen predeterminada");
                pictureBoxFoto.Image = null;
            }
        }
    }
}
