using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SistemaRRHH.Repositories;
using SistemaRRHH.Cache;
using System.Data.SqlClient;
using System.Data;

namespace SistemaRRHH.Models
{
    internal class UsuarioModel
    {
        cConexion conexion = new cConexion();
        cUsuario cUsuario = new cUsuario();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public bool LoginUser(string user, string pass)
        {
            return cUsuario.Login(user, pass);
        }


        //Obtiene todos los registros de la tabla Direcciones y retorna un objeto DataTable
        public DataTable GetUsuarios()
        {
            //Creando un objeto que permita emular una tabla
            DataTable mydt = new DataTable();
            //Instancia de la clase de conexión
            cConexion conectar = new cConexion();
            //Asignando la configuración del servidor
            SqlConnection conn = conectar.ConexionServer();
            //Declaración de la consulta obtener los datos de la tabla
            string sql = "SELECT * FROM USUARIO;";
            SqlCommand cmd = new SqlCommand(sql, conn);

            //Para lectura de la tabla
            SqlDataReader mydr = null;
            try
            {
                //Abrir la conexión
                conn.Open();
                //Ejecución de la consulta y lectura de la tabla
                mydr = cmd.ExecuteReader();
                //Agregando la lectura hecha a mi tabla
                mydt.Load(mydr);
            }
            finally
            {
                //Libera el recurso
                cmd.Dispose();
                //cerrar la conexión
                conn.Close();
            }
            return mydt;
        }


    }
}
