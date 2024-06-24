using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRRHH.Models;
using SistemaRRHH.Presenters;
using SistemaRRHH.Cache;

namespace WindowsFormsApp1
{
    public partial class TitleBar : Form
    {
        public TitleBar()
        {
            InitializeComponent();
            txtUser.AutoSize = false;
            txtUser.Size = new Size(350, 35);
            txtPass.AutoSize = false;
            txtPass.Size = new Size(350, 35);
            txtPass.UseSystemPasswordChar = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Manejar el evento KeyPress para ambos cuadros de texto
            txtUser.KeyPress += TxtUser_KeyPress;
            txtPass.KeyPress += TxtPass_KeyPress;
        }

        private void Username_Click(object sender, EventArgs e)
        {

        }

        private void TitleBar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validar que los TextBox no estén vacíos
            if(txtUser.Text != "")
            {
                if (txtPass.Text != "")
                {
                    UsuarioModel user = new UsuarioModel();
                    // Validar que el usuario y contraseña sean correctos
                    var validLogin = user.LoginUser(txtUser.Text, txtPass.Text);
                    if (validLogin == true)
                    {
                        FormPrincipal mainMenu = new FormPrincipal();
                        // Mensaje de bienvenida
                        MessageBox.Show("Bienvenido " + UsuarioLoginCache.Username);
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Nombre de usuario o contraseña incorrectos. \nIntente de Nuevo");
                        txtPass.Clear();
                        txtUser.Clear();
                        txtUser.Focus();
                    }
                }
                else msgError("Introduzca su contraseña");
            }
            else msgError("Introduzca su Usuario");
        }

        private void msgError(string msg)
        {
            lblError.Text = "" + msg;
            lblError.Visible = true;
        }


        // Método para cerrar sesión
        private void Logout(object sender, FormClosedEventArgs e)
        {
            // Limpiar los TextBox y mostrar el formulario de login
            txtPass.Clear();
            txtUser.Clear();
            lblError.Visible = false;
            this.Show();
            txtUser.Focus();
        }

        // Metodo para que al dar enter en el cuadro de texto de usuario o contraseña se ejecute el evento del botón
        private void TxtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al evento del botón
                button1_Click(sender, e);
            }
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al evento del botón
                button1_Click(sender, e);
            }
        }


    }
}
