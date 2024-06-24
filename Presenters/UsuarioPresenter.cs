using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRRHH.Models;

namespace SistemaRRHH.Presenters
{
    internal class UsuarioPresenter
    {
        private UsuarioModel objetoCD = new UsuarioModel();
        public DataTable MostrarUsuarios()
        {
            // Obtiene los datos de la tabla usuarios
            DataTable tabla = new DataTable();
            tabla = objetoCD.GetUsuarios();
            return tabla;
        }

        public void InsertarUsuario(int idRol, string username, string password, string email)
        {
            objetoCD.InsertarNuevoUsuario(idRol, username, password, email);
        }

        public void EditarUser(string username, string email, int idRol, int idUsuario)
        {
            objetoCD.EditarUsuario(idUsuario, username, email, idRol);
        }

        public void EliminarUsuario(int idUsuario)
        {
            objetoCD.EliminarUsuario(idUsuario);
        }

        public DataTable ObtenerRoles()
        {
            return objetoCD.ObtenerRoles();
        }

    }
}
