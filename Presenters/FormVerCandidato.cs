using SistemaRRHH.Presenters;
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
	public partial class FormVerCandidato : Form
	{
        CandidatoPresenter objetoCN = new CandidatoPresenter();

        // Variable para almacenar la imagen en bytes y así no usar una dirección de archivo
        byte[] imagenByte;

        public void SetInformacionCandidato(
         string primerNombre, string segundoNombre,
         string primerApellido, string segundoApellido,
         string objetivo, string telefono, string email, string sexo, string estado, int edad)
        {
            // Asigna la información a los controles de FormPantallaPerfil
            txtNombrePerfil.Text = $"{primerNombre} {segundoNombre}";
            txtApellidoPerfil.Text = $"{primerApellido} {segundoApellido}";
            txtObjetivo.Text = objetivo;
            txtTelefonoPerfil.Text = telefono;
            txtEmail.Text = email;
            txtBoxEdadCandidato.Text = edad.ToString();
            cmbGenero.Text = sexo;
            cmbBoxEstadoCandidato.Text = estado;
        }

        public static FormVerCandidato Instance { get; private set; }

        public FormVerCandidato()
		{
			InitializeComponent();
            LlenarComboBoxHabilidades();
            LlenarComboBoxCompetencias();
        }



        private void LlenarComboBoxCompetencias()
        {
            DataTable competencias = objetoCN.ObtenerCompetenciasConDominioAgrupadas();

            cmbCompetencia.DataSource = competencias;
            cmbCompetencia.DisplayMember = "NOMBRE_DOMINIO";
            cmbCompetencia.ValueMember = "ID_COMPETENCIA"; // Ajusta según la columna que contiene el ID de la competencia
        }






        private void LlenarComboBoxHabilidades()
        {
            // Obtener las habilidades de la base de datos
            DataTable habilidades = objetoCN.ObtenerHabilidades();

            // Asignar el origen de datos al ComboBox
            cmbHabilidad.DataSource = habilidades;
            cmbHabilidad.DisplayMember = "NOMBRE_HABILIDAD";
            cmbHabilidad.ValueMember = "ID_HABILIDAD";
        }

        private int ObtenerIdCandidatoActual()
        {
            return objetoCN.IdCandidatoActual;
        }



        private void btnAgregarHabilidad_Click(object sender, EventArgs e)
        {
            // Obtener el ID del candidato actualmente seleccionado
            int idCandidato = ObtenerIdCandidatoActual();

            // Validar que se haya seleccionado un candidato
            if (idCandidato == 0)
            {
                MessageBox.Show("Seleccione un candidato antes de agregar habilidades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el ID de la habilidad seleccionada en el ComboBox
            int idHabilidad = Convert.ToInt32(cmbHabilidad.SelectedValue);

            // Llamar al método del presenter para agregar la habilidad al candidato
            objetoCN.AgregarHabilidadACandidato(idCandidato, idHabilidad);

            // Mostrar las habilidades actualizadas en el ListBox
            MostrarHabilidadesCandidato(idCandidato);
        }

        private void MostrarHabilidadesCandidato(int idCandidato)
        {
            // Obtener las habilidades del candidato
            DataTable dataTable = objetoCN.GetHabilidadesPorCandidato(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Limpiar la lista antes de agregar nuevas habilidades
                lstBxHabilidades.Items.Clear();

                // Recorrer las habilidades y agregarlas al ListBox
                foreach (DataRow row in dataTable.Rows)
                {
                    lstBxHabilidades.Items.Add(row["NOMBRE_HABILIDAD"].ToString());
                }
            }
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
            MostrarExperienciaLaboral();
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

        private void tblLayoutInformacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Muestra un cuadro de diálogo de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Cierra el formulario si el usuario hace clic en "Sí"
                this.Close();
            }

           
        }

        private void btnAgregarCandidato_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que los datos a registrar son correctos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                // Obtiene el valor del txtNombrePerfil y lo divide en dos partes
                string[] nombres = txtNombrePerfil.Text.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

                // Obtiene el valor del txtApellidoPerfil y lo divide en dos partes
                string[] apellidos = txtApellidoPerfil.Text.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

                // Asegúrate de tener al menos el primer nombre y apellido
                string primerNombre = nombres.Length > 0 ? nombres[0] : "";
                string segundoNombre = nombres.Length > 1 ? nombres[1] : "";
                string primerApellido = apellidos.Length > 0 ? apellidos[0] : "";
                string segundoApellido = apellidos.Length > 1 ? apellidos[1] : "";

                // Obtiene el valor de txtObjetivo, txtTelefonoPerfil y txtEmail
                string objetivo = txtObjetivo.Text;
                string telefono = txtTelefonoPerfil.Text;
                string email = txtEmail.Text;
                string estado = cmbBoxEstadoCandidato.Text;
                int edad;


                // Obtiene el valor seleccionado del ComboBox
                string genero = cmbGenero.SelectedIndex == 0 ? "M" : "F";

                // Validar formato de teléfono (solo números)
                if (!EsNumero(telefono))
                {
                    MessageBox.Show("Ingrese un número de teléfono válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar formato de email
                if (!EsEmailValido(email))
                {
                    MessageBox.Show("Ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar formato de edad (solo números enteros)
                if (!int.TryParse(txtBoxEdadCandidato.Text, out edad))
                {
                    MessageBox.Show("Ingrese una edad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Llama al método InsertarCandidato del objetoCN
                objetoCN.InsertarCandidato(primerNombre, segundoNombre, primerApellido, segundoApellido, objetivo, telefono, email, genero, estado, edad, imagenByte);

            }

        }

        // Función para validar si una cadena es un número
        private bool EsNumero(string cadena)
        {
            return int.TryParse(cadena, out _);
        }

        // Función para validar si una cadena tiene un formato de email válido
        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void cmbGenero_Click(object sender, EventArgs e)
        {

        }

        private void cmbHabilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCompetencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarCompetencia_Click(object sender, EventArgs e)
        {
            // Obtener el ID del candidato actualmente seleccionado (ajusta según tu lógica)
            int idCandidato = ObtenerIdCandidatoActual();

            // Obtener el ID de la competencia seleccionada en el ComboBox
            int idCompetencia = Convert.ToInt32(cmbCompetencia.SelectedValue);

            // Llama al método en el Presenter para agregar la competencia al candidato
            objetoCN.AgregarCompetenciaACandidato(idCandidato, idCompetencia);

            // Actualiza la lista de competencias en el ListBox
            MostrarCompetenciasCandidato(idCandidato, lstBxCompetencias);
        }


        // Método para mostrar las competencias del candidato en el ListBox
        private void MostrarCompetenciasCandidato(int idCandidato, ListBox listBox)
        {
            // Obtener las competencias del candidato desde el presentador
            DataTable competencias = objetoCN.ObtenerCompetenciasPorCandidato(idCandidato);

            // Limpiar el ListBox antes de agregar las nuevas competencias
            listBox.Items.Clear();

            // Iterar a través de las competencias y agregarlas al ListBox
            foreach (DataRow competencia in competencias.Rows)
            {
                string nombreCompetencia = competencia["NOMBRE_COMPETENCIA"].ToString();
                string dominio = competencia["DOMINIO"].ToString();

                listBox.Items.Add($"{nombreCompetencia} - Dominio: {dominio}");
            }
        }



        private void cmbDominio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarExperienciaLaboral_Click(object sender, EventArgs e)
        {
            // Obtiene los valores de los controles del formulario
            string cargo = txtCargoExP.Text;
            string institucion = txtInstitucionExP.Text;
            DateTime fechaInicio = dateStartExp.Value;
            DateTime fechaFin = dateEndExp.Value;

            // Validación de fechas
            if (fechaFin < fechaInicio)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llama al método InsertarExperienciaLaboral del objetoCN
            objetoCN.InsertarExperienciaLaboral(ObtenerIdCandidatoActual(), cargo, institucion, fechaInicio, fechaFin);



            // Mostrar mensaje de confirmación
            MessageBox.Show("Experiencia laboral agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualiza la lista de experiencias laborales
            MostrarExperienciaLaboral();

            txtCargoExP.Text = "";
            txtInstitucionExP.Text = "";
        }


        private void MostrarExperienciaLaboral()
        {
            // Limpia la lista antes de mostrar las nuevas experiencias laborales
            lstBxExpLabo.Items.Clear();

            int idCandidato = ObtenerIdCandidatoActual();

            // Obtiene las experiencias laborales del candidato
            DataTable dataTable = objetoCN.ObtenerExperienciaLaboral(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Recorre las experiencias laborales y las agrega al ListBox con el formato deseado
                foreach (DataRow row in dataTable.Rows)
                {
                    string cargo = row["CARGO"].ToString();
                    string institucion = row["INSTITUCION"].ToString();
                    string anioInicio = ((DateTime)row["ANIO_INICIO"]).Year.ToString();
                    string anioFin = ((DateTime)row["ANIO_FIN"]).Year.ToString();

                    string experiencia = $"{cargo}\n{institucion}\n{anioInicio} - {anioFin}\n";
                    lstBxExpLabo.Items.Add(experiencia);
                    lstBxExpLabo.Items.Add("\n"); // Doble salto de línea
                }
            }
        }


        // En el formulario, en el método donde se maneja el evento del botón btnAgregarFormacion
        private void btnAgregarFormacion_Click(object sender, EventArgs e)
        {
            int idCandidato = ObtenerIdCandidatoActual();
            // Obtén los valores de los controles
            string institucion = cmbInstitucionAcademica.Text;
            string titulo = txtTitulo.Text;
            string departamento = cmbDepartamentoFA.Text;
            DateTime fechaInicio = dateStartForm.Value;
            DateTime fechaFin = dateEndForm.Value;

            // Llama al método en el presentador para agregar la Formación Académica
            objetoCN.AgregarFormacionAcademica(idCandidato, institucion, titulo, departamento, fechaInicio, fechaFin);
        }


        private void MostrarFormacionAcademica()
        {
            // Limpia la lista antes de mostrar las nuevas experiencias laborales
            lstBxFormaAca.Items.Clear();

            int idCandidato = ObtenerIdCandidatoActual();

            // Obtiene las experiencias laborales del candidato
            DataTable dataTable = objetoCN.ObtenerFormacionAcademica(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Recorre las experiencias laborales y las agrega al ListBox con el formato deseado
                foreach (DataRow row in dataTable.Rows)
                {
                    string institucion = row["INSTITUCION"].ToString();
                    string titulo = row["TITULO"].ToString();
                    string departamento = row["DEPARTAMENTO"].ToString();
                    string anioInicio = ((DateTime)row["ANIO_INICIO"]).Year.ToString();
                    string anioFin = ((DateTime)row["ANIO_FIN"]).Year.ToString();

                    string formacion = $"{institucion}\n{titulo}\n{departamento}\n{anioInicio} - {anioFin}\n";
                    lstBxFormaAca.Items.Add(formacion);
                    lstBxFormaAca.Items.Add("\n"); // Doble salto de línea
                }
            }
        }

        private void btnAgregarFormacion_Click_1(object sender, EventArgs e)
        {
            int idCandidato = ObtenerIdCandidatoActual();
            // Obtén los valores de los controles
            string institucion = cmbInstitucionAcademica.Text;
            string titulo = txtTitulo.Text;
            string departamento = cmbDepartamentoFA.Text;
            DateTime fechaInicio = dateStartForm.Value;
            DateTime fechaFin = dateEndForm.Value;

            // Llama al método en el presentador para agregar la Formación Académica
            objetoCN.AgregarFormacionAcademica(idCandidato, institucion, titulo, departamento, fechaInicio, fechaFin);

            // Mostrar mensaje de confirmación
            MessageBox.Show("Formación académica agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualiza la lista de experiencias laborales
            MostrarFormacionAcademica();

        }

        private void btnAgregarRefLabo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreRefLaboral.Text;
            string apellido = txtApellidoRefLaboral.Text;
            int telefono = Convert.ToInt32(txtTelefonoRefLaboral.Text);
            string cargo = txtCargoRefLaboral.Text;

            // Validar formato de teléfono (solo números)
            if (!EsNumero(telefono.ToString()))
            {
                MessageBox.Show("Ingrese un número de teléfono válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llama al método en el presentador para agregar la referencia laboral
            objetoCN.AgregarReferenciaLaboral(ObtenerIdCandidatoActual(), nombre, apellido, cargo, telefono);

            // Mostrar mensaje de confirmación
            MessageBox.Show("Referencia laboral agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualiza la lista de experiencias laborales
            MostrarReferenciasLaborales();
        }



        private void MostrarReferenciasLaborales()
        {
            // Limpia la lista antes de mostrar las nuevas experiencias laborales
            lstBxRefeLabo.Items.Clear();

            int idCandidato = ObtenerIdCandidatoActual();

            // Obtiene las experiencias laborales del candidato
            DataTable dataTable = objetoCN.ObtenerReferenciasLaborales(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Recorre las experiencias laborales y las agrega al ListBox con el formato deseado
                foreach (DataRow row in dataTable.Rows)
                {
                    string nombre = row["NOMBRE"].ToString();
                    string apellido = row["APELLIDO"].ToString();
                    string telefono = row["TELEFONO"].ToString();
                    string cargo = row["CARGO"].ToString();

                    string referencia = $"{nombre} {apellido}\n{cargo}\n{telefono}\n";
                    lstBxRefeLabo.Items.Add(referencia);
                    lstBxRefeLabo.Items.Add("\n"); // Doble salto de línea
                }
            }
        }

        private void btnAgregarRefPerso_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreRefPersonal.Text;
            string apellido = txtApellidoRefPersonal.Text;
            int telefono = Convert.ToInt32(txtTelefonoRefPersonal.Text);
            string parentesco = txtParentescoRefPersonal.Text;

            // Validar formato de teléfono (solo números)
            if (!EsNumero(telefono.ToString()))
            {
                MessageBox.Show("Ingrese un número de teléfono válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llama al método en el presentador para agregar la referencia laboral
            objetoCN.AgregarReferenciaPersonal(ObtenerIdCandidatoActual(), nombre, apellido, parentesco, telefono);

            // Mostrar mensaje de confirmación
            MessageBox.Show("Referencia personal agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualiza la lista de experiencias laborales
            MostrarReferenciasPersonales();
        }

        private void MostrarReferenciasPersonales()
        {
            // Limpia la lista antes de mostrar las nuevas experiencias laborales
            lstBxRefePerso.Items.Clear();

            int idCandidato = ObtenerIdCandidatoActual();

            // Obtiene las experiencias laborales del candidato
            DataTable dataTable = objetoCN.ObtenerReferenciasPersonales(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Recorre las experiencias laborales y las agrega al ListBox con el formato deseado
                foreach (DataRow row in dataTable.Rows)
                {
                    string nombre = row["NOMBRE"].ToString();
                    string apellido = row["APELLIDO"].ToString();
                    string telefono = row["TELEFONO"].ToString();
                    string parentesco = row["CARGO"].ToString();

                    string referencia = $"{nombre} {apellido}\n{parentesco}\n{telefono}\n";
                    lstBxRefePerso.Items.Add(referencia);
                    lstBxRefePerso.Items.Add("\n"); // Doble salto de línea
                }
            }
        }

        // Método para agregar la imagen al usuario
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorimagen = new OpenFileDialog();
            selectorimagen.Title = "Seleccione una imagen";
            selectorimagen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if(selectorimagen.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(selectorimagen.FileName);
                MemoryStream memoria = new MemoryStream();
                pictureBoxFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
                imagenByte = memoria.ToArray();
            }

        }
    }
}
