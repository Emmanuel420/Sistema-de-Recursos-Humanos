using Proyecto_POE_Boceto;
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


        CandidatoPresenter objetoCN = new CandidatoPresenter();

        public FormAdmiCandidato()
        {
            InitializeComponent();

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
                string nombre = Convert.ToString(selectedRow.Cells["Nombres"].Value);
                string apellido = Convert.ToString(selectedRow.Cells["Apellidos"].Value);

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar al candidato {nombre} {apellido}?", "Eliminar Candidato", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del candidato seleccionado
                    int idCandidato = Convert.ToInt32(selectedRow.Cells["IDCandidato"].Value);

                    // Eliminar el candidato
                    objetoCN.EliminarCandidato(idCandidato);
                    // Mostrar mensaje de éxito
                    MessageBox.Show("Candidato eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarCandidato();
                }
            }
            else
            {
                // Si no hay fila seleccionada, mostrar un mensaje de advertencia
                MessageBox.Show("Seleccione el registro que desea eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVer1_Click(object sender, EventArgs e)
        {
            // Verifica si se seleccionó una fila en el dataGridViewCandidatos
            if (dataGridViewCandidatos.SelectedRows.Count > 0)
            {
                // Obtiene el ID del candidato seleccionado
                int idCandidato = Convert.ToInt32(dataGridViewCandidatos.SelectedRows[0].Cells["IDCandidato"].Value);

                // Crea una nueva instancia de FormCrearCandidato
                FormCrearCandidato formCrearCandidato = new FormCrearCandidato();

                // Llama al método para mostrar la información del candidato en formCrearCandidato
                objetoCN.MostrarInformacionCandidato(idCandidato, formCrearCandidato);

                // Establece el formulario principal (FormPrincipal) como el MDI padre de formCrearCandidato
                formCrearCandidato.MdiParent = this.MdiParent;

                // Muestra formCrearCandidato
                formCrearCandidato.Show();
            }
            else
            {
                // Muestra un mensaje indicando que no se seleccionó ningún candidato
                MessageBox.Show("Selecciona un candidato antes de ver los detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FormVerCandidato
            FormVerCandidato formVerCandidato = new FormVerCandidato();

            // Establecer el formulario principal (FormPrincipal) como el MDI padre de formVerCandidato
            formVerCandidato.MdiParent = this.MdiParent;

            // Muestra formVerCandidato
            formVerCandidato.Show();
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridViewCandidatos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCandidatos.SelectedRows[0];
                int idCandidato = Convert.ToInt32(selectedRow.Cells["IDCandidato"].Value);
                string estadoActual = Convert.ToString(selectedRow.Cells["Estado"].Value);

                // Cambiar el estado del candidato
                string nuevoEstado = (estadoActual == "Activo") ? "Inactivo" : "Activo";
                objetoCN.EditarEstadoCandidato(idCandidato, nuevoEstado);
                MostrarCandidato();
            }
            else
            {
                // Si no hay fila seleccionada, mostrar un mensaje de advertencia
                MessageBox.Show("Seleccione el candidato que desea editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MostrarCandidato();
            }
        }
    }
}
