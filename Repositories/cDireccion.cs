using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRRHH.Repositories
{
    internal class cDireccion
    {
        //Atributos privados de la clase
        //private long ID_CANDIDATO;
        private string ID_CANDIDATO;
        private string PRIMER_NOMBRE;
        private string SEGUNDO_NOMBRE;
        private string PRIMER_APELLIDO;
        private string SEGUNDO_APELLIDO;
        private string EMAIL_CANDIDATO;
        //private long TELEFONO_CANDIDATO;
        private string TELEFONO_CANDIDATO;
        private string OBJETIVO_CANDIDATO;
        private string SEXO_CANDIDATO;
        //private long EDAD_CANDIDATO;
        private string EDAD_CANDIDATO;

        /// <summary>
        /// Método constructor de la clase por defecto
        /// </summary>
        public cDireccion() { }
    

        /// <summary>
        /// Método que acepta parámetros
        /// </summary>
        
        public cDireccion(string ID_CANDIDATO, string PRIMER_NOMBRE, string SEGUNDO_NOMBRE, string PRIMER_APELLIDO, string SEGUNDO_APELLIDO, string EMAIL_CANDIDATO, string TELEFONO_CANDIDATO, string OBJETIVO_CANDIDATO, string SEXO_CANDIDATO, string EDAD_CANDIDATO)
        {
            this.ID_CANDIDATO = ID_CANDIDATO;
            this.PRIMER_NOMBRE = PRIMER_NOMBRE;
            this.SEGUNDO_NOMBRE = SEGUNDO_NOMBRE;
            this.PRIMER_APELLIDO = PRIMER_APELLIDO;
            this.SEGUNDO_APELLIDO = SEGUNDO_APELLIDO;
            this.EMAIL_CANDIDATO = EMAIL_CANDIDATO;
            this.TELEFONO_CANDIDATO = TELEFONO_CANDIDATO;
            this.OBJETIVO_CANDIDATO = OBJETIVO_CANDIDATO;
            this.SEXO_CANDIDATO = SEXO_CANDIDATO;
            this.EDAD_CANDIDATO = EDAD_CANDIDATO;
        }


        // Propiedades públicas para cada atributo
        public string IdCandidato { get => ID_CANDIDATO; set => ID_CANDIDATO = value; }
        public string PrimerNombre { get => PRIMER_NOMBRE; set => PRIMER_NOMBRE = value; }
        public string SegundoNombre { get => SEGUNDO_NOMBRE; set => SEGUNDO_NOMBRE = value; }
        public string PrimerApellido { get => PRIMER_APELLIDO; set => PRIMER_APELLIDO = value; }
        public string SegundoApellido { get => SEGUNDO_APELLIDO; set => SEGUNDO_APELLIDO = value; }
        public string Email { get => EMAIL_CANDIDATO; set => EMAIL_CANDIDATO = value; }
        public string Telefono { get => TELEFONO_CANDIDATO; set => TELEFONO_CANDIDATO = value; }
        public string Objetivo { get => OBJETIVO_CANDIDATO; set => OBJETIVO_CANDIDATO = value; }
        public string Sexo { get => SEXO_CANDIDATO; set => SEXO_CANDIDATO = value; }
        public string Edad { get => EDAD_CANDIDATO; set => EDAD_CANDIDATO = value; }


        /// <summary>
        /// Obtiene todos los registros de la tabla candidatos
        /// </summary>
        /// <returns></returns>
        public DataTable GetCandidatos()
        {
            // Creando un objeto que permite emular una tabla
            DataTable mydt = new DataTable();

            //Instancia de la clase de conexión
            cConexion conecar = new cConexion();

            //Asignando la configuración del servidor
            SqlConnection conn = conecar.ConexionServer();

            //Declaración de la consulta obtener los datos de la tabla
            string sql = "SELECT [ID_CANDIDATO]\r\n      ,[ID_USUARIO]\r\n      ,[PRIMER_NOMBRE]\r\n      ,[SEGUNDO_NOMBRE]\r\n      ,[PRIMER_APELLIDO]\r\n      ,[SEGUNDO_APELLIDO]\r\n      ,[EMAIL_CANDIDATO]\r\n      ,[TELEFONO_CANDIDATO]\r\n      ,[OBJETIVO_CANDIDATO]\r\n      ,[SEXO_CANDIDATO]\r\n      ,[EDAD_CANDIDATO]\r\n      ,[ESTADO_CANDIDATO]\r\n      ,[RUTA_IMAGEN_CANDIDATO]\r\n  FROM [dbo].[CANDIDATO]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            
            //Para lectura de la tabla
            SqlDataReader mydr = null;

            try
            {
                // Abrir la conexión
                conn.Open();
                mydr = cmd.ExecuteReader();

                // Agregando la lectura hecha a mi tabla
                mydt.Load(mydr);
            }
            finally
            {
                // Libera el recurso
                cmd.Dispose();

                // Cerrar la conexión
                conn.Close();
            }
            return mydt;
        }



    }
}
