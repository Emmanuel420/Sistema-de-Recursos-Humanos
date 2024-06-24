using SistemaRRHH.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SistemaRRHH.Models
{
    internal class CandidatoModel
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
        public DataTable GetCandidatos()
        {
            DataTable mydt = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT " +
                         "C.ID_CANDIDATO AS IDCandidato, " +
                         "CONCAT(C.PRIMER_NOMBRE, ' ', C.SEGUNDO_NOMBRE) AS Nombres, " +
                         "CONCAT(C.PRIMER_APELLIDO, ' ', C.SEGUNDO_APELLIDO) AS Apellidos, " +
                         "C.EDAD_CANDIDATO AS Edad, " +
                         "CASE " +
                         "    WHEN C.SEXO_CANDIDATO = 'M' THEN 'Masculino' " +
                         "    WHEN C.SEXO_CANDIDATO = 'F' THEN 'Femenino' " +
                         "    ELSE 'No especificado' " +
                         "END AS Sexo, " +
                         "( " +
                         "    SELECT TOP 1 STRING_AGG(H.NOMBRE_HABILIDAD, ', ') " +
                         "    FROM CANDIDATO_HABILIDAD CH " +
                         "    INNER JOIN HABILIDAD H ON CH.ID_HABILIDAD = H.ID_HABILIDAD " +
                         "    WHERE CH.ID_CANDIDATO = C.ID_CANDIDATO " +
                         ") AS Habilidades, " +
                         "( " +
                         "    SELECT TOP 1 STRING_AGG(COALESCE(CO.NOMBRE_COMPETENCIA, ''), ', ') " +
                         "    FROM CANDIDATO_COMPETENCIA CC " +
                         "    INNER JOIN COMPETENCIA CO ON CC.ID_COMPETENCIA = CO.ID_COMPETENCIA " +
                         "    WHERE CC.ID_CANDIDATO = C.ID_CANDIDATO " +
                         ") AS Competencias, " +
                         "( " +
                         "    SELECT TOP 1 FA.INSTITUCION " +
                         "    FROM FORMACION_ACADEMICA FA " +
                         "    WHERE FA.ID_CANDIDATO = C.ID_CANDIDATO " +
                         "    ORDER BY FA.ID_FORMACION DESC " +
                         ") AS FormacionAcademica, " +
                         "( " +
                         "    SELECT TOP 1 EP.CARGO " +
                         "    FROM EXPERIENCIA_PROFESIONAL EP " +
                         "    WHERE EP.ID_CANDIDATO = C.ID_CANDIDATO " +
                         "    ORDER BY EP.ID_EXPERIENCIA DESC " +
                         ") AS ExperienciaProfesional " +
                         "FROM CANDIDATO C;";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                mydt.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return mydt;
        }

        public void EliminarCandidato(int idCandidato)
        {
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            // Ejemplo de consulta para eliminar un candidato (deberás ajustar según tu lógica)
            string sql = "DELETE FROM CANDIDATO WHERE ID_CANDIDATO = @ID_CANDIDATO";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

    }
}
