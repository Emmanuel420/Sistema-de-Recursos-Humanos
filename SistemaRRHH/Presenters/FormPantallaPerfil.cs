using SistemaRRHH.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemaRRHH.Presenters
{
    public partial class FormPantallaPerfil : Form, UsuarioView
    {
        public FormPantallaPerfil()
        {
            InitializeComponent();
        }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Nombre
        {
            get { return lblNombre.Text; }
            set { lblApellido.Text = value; }
        }
        public string Nombre2
        {
            get { return lblNombre2.Text; }
            set { lblApellido2.Text = value; }
        }
        public string Apellido
        {
            get { return lblApellido.Text; }
            set { lblApellido.Text = value; }
        }
        public string Apellido2
        {
            get { return lblApellido2.Text; }
            set { lblApellido2.Text = value; }
        }
        public string Objetivo
        {
            get { return txtObjetivo.Text; }
            set { txtObjetivo.Text = value; }
        }
        public string Telefono
        {
            get { return txtTelefono.Text; }
            set { txtTelefono.Text = value; }
        }
        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }
        public string Departamento
        {
            get { return txtDepartamento.Text; }
            set { txtDepartamento.Text = value; }
        }
        public string Habilidad
        {
            get { return txtHabilidad.Text; }
            set { txtHabilidad.Text = value; }
        }
        public string Competencia
        {
            get { return txtCompetencia.Text; }
            set { txtCompetencia.Text = value; }
        }
       /* public string Experiencia
        {
            get { return txtExperiencia.Text; }
            set { txtExperiencia.Text = value; }
        }*/
       /* public string Formacion
        {
            get { return txtFormacion.Text; }
            set { txtFormacion.Text = value; }
        }*/
       /*
        public string ReferenciaL
        {
            get { return txtRL.Text; }
            set { txtRL.Text = value; }
        }
        public string ReferenciaP
        {
            get { return txtRP.Text; }
            set { txtRP.Text = value; }
        }*/

        public string SearchValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsEdit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsSuccessful { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        private void FormPantallaPerfil_Load(object sender, EventArgs e)
        {

        }
        public void SetCandidatoListBindingSource(BindingSource candidatoList)
        {

        }
        public void SetCandidatoInfo(string id, string nombre, string nombre2, string apellido, string apellido2, string objetivo, string telefono, string email, string departamento, string habilidad, string competencia  /* , string formacion, string experiencia ,string referenciaP Agrega el resto de las propiedades */)
        {
            // Establece la información directamente en los controles del formulario
            lblNombre.Text = nombre;
            lblNombre2.Text = nombre2;
            lblApellido.Text = apellido;
            lblApellido2.Text = apellido2;
            txtObjetivo.Text = objetivo;
            txtTelefono.Text = telefono;
            txtEmail.Text = email;
            txtDepartamento.Text = departamento;
            txtHabilidad.Text = habilidad;
            txtCompetencia.Text = competencia;
           // txtExperiencia.Text = experiencia;
           //txtFormacion.Text = formacion;
           // txtRL.Text = referenciaL;
            /* txtRP.Text = referenciaP;*/
            // Configura el resto de las propiedades según sea necesario
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
