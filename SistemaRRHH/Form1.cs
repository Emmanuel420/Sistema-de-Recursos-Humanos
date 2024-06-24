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
                    var validLogin = user.LoginUser(txtUser.Text, txtPass.Text);
                    if (validLogin == true)
                    {
                        FormPrincipal mainMenu = new FormPrincipal();
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


        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtPass.Clear();
            txtUser.Clear();
            lblError.Visible = false;
            this.Show();
            txtUser.Focus();
        }

    }
}
