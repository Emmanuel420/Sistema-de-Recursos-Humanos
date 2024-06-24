using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SistemaRRHH.Cache;

namespace SistemaRRHH.Repositories
{
    public class cUsuario:cConexion
    {
        public bool Login(string user, string pass)
        {
            using (var connection = ConexionServer())
            {
                connection.Open();
                using (var command = new SqlCommand()) { 
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM USUARIO WHERE USERNAME=@user and PASSWORD=@pass";
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UsuarioLoginCache.IdUsuario = reader.GetInt32(0);
                            UsuarioLoginCache.IdRol = reader.GetInt32(1);
                            UsuarioLoginCache.Username = reader.GetString(2);
                            UsuarioLoginCache.Password = reader.GetString(3);
                            UsuarioLoginCache.Email = reader.GetString(4);
                        }
                        return true;
                    }
                    else { return false; }

                }
            }
        }








    }
}
