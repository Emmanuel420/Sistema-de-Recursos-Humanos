using SistemaRRHH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH.Presenters
{
    internal class AgregarHabilidadPresenter
    {
        private FormAgregarHabilidad view;
        private HabilidadModel model;

        public AgregarHabilidadPresenter(FormAgregarHabilidad view)
        {
            this.view = view;
            this.model = new HabilidadModel();

            // Asociar el evento del botón con el método correspondiente
            this.view.btnAgregarNuevaHabilidad.Click += BtnAgregarNuevaHabilidad_Click;
        }

        private void BtnAgregarNuevaHabilidad_Click(object sender, EventArgs e)
        {
            // Obtener la habilidad desde el TextBox
            string nombreHabilidad = view.txtBoxNombreHabilidad.Text;

            // Validar que el nombre de la habilidad no esté vacío
            if (!string.IsNullOrEmpty(nombreHabilidad))
            {
                // Intentar agregar la habilidad a la base de datos
                if (model.AgregarHabilidad(nombreHabilidad))
                {
                    MessageBox.Show("Habilidad agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar el TextBox después de agregar la habilidad
                    view.txtBoxNombreHabilidad.Clear();
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de habilidad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
