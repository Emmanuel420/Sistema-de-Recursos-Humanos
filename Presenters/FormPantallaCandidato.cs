using Proyecto_POE_Boceto;
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
    public partial class formularioCandidato : Form
    {


        private string message;
        private bool isEdit;

        CandidatoPresenter objetoCN = new CandidatoPresenter();

		public formularioCandidato()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
            // Establece el texto del formulario
            SetPlaceholder(txtBusqueda, "Ingrese el valor a buscar");
            txtBusqueda.Size = new Size(500, 35);
        }
		private void FormPantallaCandidato_Load(object sender, EventArgs e)
        {
            MostrarCandidato();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Cierra todos los formularios hijos, incluido formCrearCandidato
            // Para evitar que se quede abierto el formulario formCrearCandidato
            foreach (Form mdiChild in this.MdiChildren)
            {
                mdiChild.Close();
            }
        }


        private void dataGridViewCandidatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void MostrarCandidato()
        {
            dataGridViewCandidatos.DataSource = objetoCN.MostrarCandidato();
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

        private void dataGridViewCandidatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridViewCandidatos.RowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            MostrarCandidato(txtBusqueda.Text);
        }


        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            // Establece el color gris para el texto del textBox
            textBox.ForeColor = SystemColors.GrayText;
            textBox.Text = placeholder;
            textBox.GotFocus += (s, e) =>
            {
                
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
            };
            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = SystemColors.GrayText;
                }
            };
        }



        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "" && comboBox1.Text != "")
            {
                string campo;
                //Validando opciones de búsqueda
                if(comboBox1.Text == "Primer nombre")
                {
                    campo = "PRIMER_NOMBRE";
                }
                else if(comboBox1.Text == "Segundo nombre")
                {
                    campo = "SEGUNDO NOMBRE";
                }
                else if (comboBox1.Text == "Primer apellido")
                {
                    campo = "PRIMER_APELLIDO";
                }
                else if (comboBox1.Text == "Segundo apellido")
                {
                    campo = "SEGUNDO_APELLIDO";
                }
                else if (comboBox1.Text == "Email")
                {
                    campo = "EMAIL_CANDIDATO";
                }
                else if (comboBox1.Text == "Teléfono de casa")
                {
                    campo = "TELEFONO_CANDIDATO";
                }
                else if (comboBox1.Text == "Objetivo del candidato")
                {
                    campo = "OBJETIVO_CANDIDATO";
                }
                else if (comboBox1.Text == "Sexo")
                {
                    campo = "SEXO_CANDIDATO";
                }
                else
                {
                    campo = "EDAD_CANDIDATO";
                }
                dataGridViewCandidatos.DataSource = objetoCN.buscarRegistro(campo, txtBusqueda.Text);
            }
            else if(txtBusqueda.Text != "" && comboBox1.Text == "Habilidad")
            {
                MostrarCandidato(txtBusqueda.Text);
            }
            else
            {
                string mensaje = "INGRESAR PARAMETROS DE BUSQUEDA";
                MessageBox.Show(mensaje, "INFORMACION!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void MostrarCandidato(string habilidad)
        {
            // Muestra los candidatos que coincidan con la habilidad
            dataGridViewCandidatos.DataSource = objetoCN.BusquedaSimpleCandidato(habilidad);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (txtBusqueda.Text != "" && comboBox1.Text != "")
            {
                string campo;
                //Validando opciones de búsqueda
                if (comboBox1.Text == "Primer nombre")
                {
                    campo = "PRIMER_NOMBRE";
                }
                else if (comboBox1.Text == "Segundo nombre")
                {
                    campo = "SEGUNDO NOMBRE";
                }
                else if (comboBox1.Text == "Primer apellido")
                {
                    campo = "PRIMER_APELLIDO";
                }
                else if (comboBox1.Text == "Segundo apellido")
                {
                    campo = "SEGUNDO_APELLIDO";
                }
                else if (comboBox1.Text == "Email")
                {
                    campo = "EMAIL_CANDIDATO";
                }
                else if (comboBox1.Text == "Teléfono de casa")
                {
                    campo = "TELEFONO_CANDIDATO";
                }
                else if (comboBox1.Text == "Objetivo del candidato")
                {
                    campo = "OBJETIVO_CANDIDATO";
                }
                else if (comboBox1.Text == "Sexo")
                {
                    campo = "SEXO_CANDIDATO";
                }
                else
                {
                    campo = "EDAD_CANDIDATO";
                }
                dataGridViewCandidatos.DataSource = objetoCN.buscarRegistro(campo, txtBusqueda.Text);
            }
            else if (txtBusqueda.Text != "" && comboBox1.Text == "")
            {
                MostrarCandidato(txtBusqueda.Text);
            }
            else
            {
                string mensaje = "INGRESAR PARAMETROS DE BUSQUEDA";
                MessageBox.Show(mensaje, "INFORMACION!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            MostrarCandidato();
            txtBusqueda.Text = "";
            comboBox1.Text = "";
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FormVerCandidato
            FormVerCandidato formVerCandidato = new FormVerCandidato();

            // Establecer el formulario principal (FormPrincipal) como el MDI padre de formVerCandidato
            // Esto permite que formVerCandidato se muestre dentro del formulario principal
            formVerCandidato.MdiParent = this.MdiParent;

            // Muestra formVerCandidato
            formVerCandidato.Show();
        }



    }
}

