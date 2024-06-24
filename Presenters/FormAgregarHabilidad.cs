using SistemaRRHH.Models;
using SistemaRRHH.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH.Presenters
{
    public partial class FormAgregarHabilidad : Form
    {
        public FormAgregarHabilidad()
        {
            InitializeComponent();
        }

        private void txtBoxNombreHabilidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarNuevaHabilidad_Click(object sender, EventArgs e)
        {
            string nombreHabilidad = txtBoxNombreHabilidad.Text;

            //Manera de hacerlo no apropieda, sin embargo por motivos de tiempo se hizo de esta manera
            //Como programador reconocemos que se debe encapsular el acceso a la base de datos
            //y no hacerlo de esta manera

            if (!string.IsNullOrEmpty(nombreHabilidad))
            {
               
                try
                {
                    using (SqlConnection conn = new cConexion().ConexionServer())
                    {
                        conn.Open();

                        // Consulta para insertar una nueva habilidad
                        string query = "INSERT INTO HABILIDAD (NOMBRE_HABILIDAD) VALUES (@NombreHabilidad)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NombreHabilidad", nombreHabilidad);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Habilidad agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar el TextBox después de agregar la habilidad
                        txtBoxNombreHabilidad.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar habilidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de habilidad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxNombreCompetencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarNuevaCompetencia_Click(object sender, EventArgs e)
        {
            string nombreCompetencia = txtBoxNombreCompetencia.Text;

            // Validar que el nombre de la competencia no esté vacío
            if (!string.IsNullOrEmpty(nombreCompetencia))
            {
                // Crear una instancia de HabilidadModel
                HabilidadModel model = new HabilidadModel();

                // Intentar agregar la competencia a la base de datos
                if (model.AgregarCompetencia(nombreCompetencia))
                {
                    MessageBox.Show("Competencias agregadas con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar el TextBox después de agregar la competencia
                    txtBoxNombreCompetencia.Clear();
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de competencia válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
