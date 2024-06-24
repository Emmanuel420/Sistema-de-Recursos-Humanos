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
    public partial class formAdminUsers : Form
    {

        UsuarioPresenter objetoCN = new UsuarioPresenter();
        private int? idUsuarioSeleccionado;

        public formAdminUsers()
        {
            InitializeComponent();
        }

        private void lblprueba_Click(object sender, EventArgs e)
        {

        }

        private void formularioUsers_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            LlenarComboBoxRoles();
            // Configurar la propiedad UseSystemPasswordChar para ocultar la contraseña
            txtPass.UseSystemPasswordChar = true;
        }


        private void MostrarUsuarios()
        {
            dataGridView1.DataSource = objetoCN.MostrarUsuarios();

            // Renombrar las columnas en el DataGridView
            dataGridView1.Columns["ID Usuario"].HeaderText = "ID Usuario";
            dataGridView1.Columns["Rol"].HeaderText = "Rol";
            dataGridView1.Columns["Nombre de Usuario"].HeaderText = "Nombre de Usuario";
            dataGridView1.Columns["Correo Electrónico"].HeaderText = "Correo Electrónico";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPass.Text; 
            int idRol = Convert.ToInt32(comboRol.SelectedValue);

            // Insertar o editar según si hay un usuario seleccionado o no
            try
            {
                if (idUsuarioSeleccionado.HasValue)
                {
                    if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || comboRol.SelectedValue == null)
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!IsValidEmail(txtEmail.Text))
                    {
                        MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Formato de Email Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Editar usuario
                    objetoCN.EditarUser(username, email, idRol, idUsuarioSeleccionado.Value);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPass.Text) || comboRol.SelectedValue == null)
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!IsValidEmail(txtEmail.Text))
                    {
                        MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Formato de Email Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insertar nuevo usuario
                    objetoCN.InsertarUsuario(idRol, username, password, email);
                }

                // Limpiar controles después de guardar
                LimpiarControles();

                // Actualizar el DataGridView
                MostrarUsuarios();

                // Mostrar mensaje de confirmación
                MessageBox.Show("Usuario guardado exitosamente.", "Guardar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Console.WriteLine("Método btnGuardar_Click completado");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string username = Convert.ToString(selectedRow.Cells["Nombre de Usuario"].Value);

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar a {username} del registro de Usuarios?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del usuario seleccionado
                    int idUsuario = Convert.ToInt32(selectedRow.Cells["ID Usuario"].Value);

                    // Eliminar el usuario
                    objetoCN.EliminarUsuario(idUsuario);

                    // Actualizar el DataGridView
                    MostrarUsuarios();
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener datos de la fila seleccionada
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int idUsuario = Convert.ToInt32(selectedRow.Cells["ID Usuario"].Value);
                string username = Convert.ToString(selectedRow.Cells["Nombre de Usuario"].Value);
                string email = Convert.ToString(selectedRow.Cells["Correo Electrónico"].Value);
                int idRol = GetIdRol(selectedRow.Cells["Rol"].Value.ToString());

                // Mostrar datos en los controles del formulario
                txtUsername.Text = username;
                txtEmail.Text = email;
                comboRol.SelectedValue = idRol;

                // Guardar el ID del usuario seleccionado (lo necesitaremos al editar)
                this.idUsuarioSeleccionado = idUsuario;
            }

        }

        private void LimpiarControles()
        {
            // Limpiar los controles del formulario
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            comboRol.SelectedIndex = -1;
            idUsuarioSeleccionado = null;
        }

        private int GetIdRol(string rolNombre)
        {
            Console.WriteLine($"Valor de rolNombre: {rolNombre}");
            switch (rolNombre)
            {
                case "Administrador":
                    return 1;
                case "Reclutador":
                    return 2;
                case "Gerente RRHH":
                    return 3;
                default:
                    return 3;
            }
        }


        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void LlenarComboBoxRoles()
        {
            comboRol.DataSource = objetoCN.ObtenerRoles();
            comboRol.DisplayMember = "NOMBRE_ROL";
            comboRol.ValueMember = "ID_ROL";
        }

        private bool IsValidEmail(string email)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
