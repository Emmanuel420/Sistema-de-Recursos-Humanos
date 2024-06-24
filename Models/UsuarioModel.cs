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

       // SqlDataReader leer;
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
            string sql = "SELECT U.ID_USUARIO, R.NOMBRE_ROL AS NOMBRE_ROL, U.USERNAME, U.EMAIL FROM USUARIO U INNER JOIN ROL R ON U.ID_ROL = R.ID_ROL;";

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

                // Renombrar las columnas en el DataTable
                mydt.Columns["ID_USUARIO"].ColumnName = "ID Usuario";
                mydt.Columns["NOMBRE_ROL"].ColumnName = "Rol";
                mydt.Columns["USERNAME"].ColumnName = "Nombre de Usuario";
                mydt.Columns["EMAIL"].ColumnName = "Correo Electrónico";
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

        public void InsertarNuevoUsuario(int idRol, string username, string password, string email)
        {
            Console.WriteLine($"Valor de idRol: {idRol}");
            try
            {
                using (SqlConnection conn = conexion.ConexionServer())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO USUARIO (ID_ROL, USERNAME, PASSWORD, EMAIL) VALUES (@IdRol, @Username, @Password, @Email)", conn))
                    {
                        cmd.Parameters.AddWithValue("@IdRol", idRol);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Email", email);
                        Console.WriteLine($"Valor de idRol: {idRol}");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al insertar nuevo usuario: {ex.Message}");
                throw;
            }
        }

        public bool EditarUsuario(int idUsuario, string username, string email, int idRol)
        {
            try
            {
                using (SqlConnection conn = conexion.ConexionServer())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET USERNAME = @Username, EMAIL = @Email, ID_ROL = @IdRol WHERE ID_USUARIO = @IdUsuario", conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@IdRol", idRol);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar usuario: {ex.Message}");
                return false;
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                using (SqlConnection conn = conexion.ConexionServer())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM USUARIO WHERE ID_USUARIO = @IdUsuario", conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                return false;
            }
        }

        public DataTable ObtenerRoles()
        {
            try
            {
                using (SqlConnection conn = conexion.ConexionServer())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ID_ROL, NOMBRE_ROL FROM ROL", conn))
                    {
                        DataTable roles = new DataTable();
                        roles.Load(cmd.ExecuteReader());
                        return roles;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener roles: {ex.Message}");
                throw;
            }
        }

        


    }
}
