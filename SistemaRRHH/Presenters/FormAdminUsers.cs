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
    public partial class formularioUsers : Form
    {

        UsuarioPresenter objetoCN = new UsuarioPresenter();

        public formularioUsers()
        {
            InitializeComponent();
        }

        private void lblprueba_Click(object sender, EventArgs e)
        {

        }

        private void formularioUsers_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }


        private void MostrarUsuarios()
        {
            dataGridViewCandidatos.DataSource = objetoCN.MostrarUsuarios();
        }

        private void dataGridViewCandidatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewCandidatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridViewCandidatos.RowsDefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
