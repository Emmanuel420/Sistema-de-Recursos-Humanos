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
            DataTable tabla = new DataTable();
            tabla = objetoCD.GetUsuarios();
            return tabla;
        }
    }
}
