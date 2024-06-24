using SistemaRRHH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH.Presenters
{
    public partial class FormAdmiCandidato : Form
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        CandidatoPresenter objetoCN = new CandidatoPresenter();
        FormPantallaPerfil perfil = new FormPantallaPerfil();
        public FormAdmiCandidato()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }
        private void AssociateAndRaiseViewEvents()
        {
            /*btnVer1.Click += delegate
            {
                FormPantallaPerfil perfil = new FormPantallaPerfil();
                perfil.Show(this);
            };*/
            btnVer1.Click += delegate
            {
                FormPantallaPerfil perfil = new FormPantallaPerfil();
                // Obtén el índice de la fila seleccionada
                if (dataGridViewCandidatos.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridViewCandidatos.SelectedRows[0].Index;
                    // Obtén la información directamente de las celdas de la fila seleccionada
                    string id = dataGridViewCandidatos.Rows[rowIndex].Cells["ID_USUARIO"].Value.ToString();
                    string nombre1 = dataGridViewCandidatos.Rows[rowIndex].Cells["PRIMER_NOMBRE"].Value.ToString();
                    string nombre2 = dataGridViewCandidatos.Rows[rowIndex].Cells["SEGUNDO_NOMBRE"].Value.ToString();
                    string apellido1 = dataGridViewCandidatos.Rows[rowIndex].Cells["PRIMER_APELLIDO"].Value.ToString();
                    string apellido2 = dataGridViewCandidatos.Rows[rowIndex].Cells["SEGUNDO_APELLIDO"].Value.ToString();
                    string objetivo = dataGridViewCandidatos.Rows[rowIndex].Cells["OBJETIVO_CANDIDATO"].Value.ToString();
                    string telefono = dataGridViewCandidatos.Rows[rowIndex].Cells["TELEFONO_CANDIDATO"].Value.ToString();
                    string email = dataGridViewCandidatos.Rows[rowIndex].Cells["EMAIL_CANDIDATO"].Value.ToString();
                    string sexo = dataGridViewCandidatos.Rows[rowIndex].Cells["SEXO_CANDIDATO"].Value.ToString();
                    string edad = dataGridViewCandidatos.Rows[rowIndex].Cells["EDAD_CANDIDATO"].Value.ToString();
                    string estado = dataGridViewCandidatos.Rows[rowIndex].Cells["ESTADO_CANDIDATO"].Value.ToString();
                    // string formacion = dataGridViewCandidatos.Rows[rowIndex].Cells["FORMACION_ACADEMICA"].Value.ToString();

                    // Agrega el resto de las propiedades según sea necesario
                    /*string referenciaP = dataGridViewCandidatos.Rows[rowIndex].Cells["ReferenciaP"].Value.ToString();*/


                    // Pasa la información al formulario FormPantallaPerfil
                    perfil.SetCandidatoInfo(id, nombre1, nombre2, apellido1, apellido2, objetivo, telefono, email, sexo, edad, estado /*referenciaP Agrega el resto de las propiedades */);

                    // Muestra el formulario FormPantallaPerfil
                    perfil.Show(this);
                };
            };

        }
        private void FormAdmiCandidato_Load(object sender, EventArgs e)
        {
            MostrarCandidato();
        }
        private void MostrarCandidato()
        {
            dataGridViewCandidatos.DataSource = objetoCN.MostrarCandidato();
        }

        private void dataGridViewCandidatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridViewCandidatos.RowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridViewCandidatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridViewCandidatos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCandidatos.SelectedRows[0];
                string candidato = Convert.ToString(selectedRow.Cells["IDCandidato"].Value);

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar del registro de Candidatos?", "Eliminar Candidato", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del usuario seleccionado
                    int idCandidato = Convert.ToInt32(selectedRow.Cells["IDCandidato"].Value);

                    // Eliminar el usuario
                    objetoCN.EliminarCandidato(idCandidato);
                    MostrarCandidato();

                }
            }
        }
    }
}
