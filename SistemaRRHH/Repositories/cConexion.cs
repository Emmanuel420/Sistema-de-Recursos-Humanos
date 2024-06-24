using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bliblioteca necesaria para la conexión
using System.Data.SqlClient;

namespace SistemaRRHH.Repositories
{
    public class cConexion
    {
        //Hacemos el método para la conexión al servidor que devolverá el tipo de dato seleccionado SqlConnection
        public SqlConnection ConexionServer()
        {
            //Declaramos la variable conn de tipo de dato SqlConection
            SqlConnection conn;
            try
            {
                //Declaramos la variable de tipo String que contendrá toda la configuración de la cadena de conexión

                //string cadenaConexion = "Data Source=DESKTOP-PE3U1JE\\SQLEXPRESS; Initial Catalog=RecursosHumanos; Persist Security Info=True;User ID=sa; Password=root";
                string cadenaConexion = "Data Source=serverpoe.database.windows.net; Initial Catalog=RecursosHumanos; Persist Security Info=True;User ID=administrador; Password=adminPO3";


                conn = new SqlConnection(cadenaConexion);
            }
            catch (Exception ex)
            {
                //estructura try catch por algún error
                throw new ArgumentException("Error al conectar", ex);
            }
            return conn;
        }



        }
}
