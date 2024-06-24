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
using SistemaRRHH.Cache;
using System.IO;

namespace SistemaRRHH.Models
{
    internal class CandidatoModel
    {
        cConexion conexion = new cConexion();
        cUsuario cUsuario = new cUsuario();

        //SqlDataReader leer;
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
                         "C.ESTADO_CANDIDATO AS Estado, " +
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
                         "FROM CANDIDATO C " +
                         "ORDER BY C.ID_CANDIDATO DESC;"; // Agrega la cláusula ORDER BY

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

        public DataTable GetCandidatosPorHabilidad(string habilidad)
        {
            DataTable mydt = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT " +
                         "C.ID_CANDIDATO AS IDCandidato, " +
                         "CONCAT(C.PRIMER_NOMBRE, ' ', C.SEGUNDO_NOMBRE) AS Nombres, " +
                         "CONCAT(C.PRIMER_APELLIDO, ' ', C.SEGUNDO_APELLIDO) AS Apellidos, " +
                         "C.EDAD_CANDIDATO AS Edad, " +
                         "C.ESTADO_CANDIDATO AS Estado, " +
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
                         "    SELECT TOP 1 STRING_AGG(CO.NOMBRE_COMPETENCIA, ', ') " +
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
                         "FROM CANDIDATO C " +
                         "WHERE EXISTS (SELECT 1 FROM CANDIDATO_HABILIDAD CH " +
                         "              INNER JOIN HABILIDAD H ON CH.ID_HABILIDAD = H.ID_HABILIDAD " +
                         "              WHERE CH.ID_CANDIDATO = C.ID_CANDIDATO AND H.NOMBRE_HABILIDAD LIKE @Habilidad)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Habilidad", "%" + habilidad + "%");

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

        public DataTable buscar(string campo, string valorCampo)
        {
            DataTable mydt = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT " +
                         "C.ID_CANDIDATO AS IDCandidato, " +
                         "CONCAT(C.PRIMER_NOMBRE, ' ', C.SEGUNDO_NOMBRE) AS Nombres, " +
                         "CONCAT(C.PRIMER_APELLIDO, ' ', C.SEGUNDO_APELLIDO) AS Apellidos, " +
                         "C.EDAD_CANDIDATO AS Edad, " +
                         "C.ESTADO_CANDIDATO AS Estado, " +
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
                         "FROM CANDIDATO C " +
                         "WHERE " + campo + " " +
                         (campo == "TELEFONO_CANDIDATO" || campo == "EDAD_CANDIDATO" ? "=" : "LIKE") +
                         (campo == "TELEFONO_CANDIDATO" || campo == "EDAD_CANDIDATO" ? valorCampo : " '%" + valorCampo + "%';");

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                mydt.Load(mydr);
            }
            catch (SqlException error)
            {
                MessageBox.Show("Error al buscar un registro: " + error.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return mydt;
        }



        public DataTable GetCandidatoPorId(int idCandidato)
        {
            DataTable mydt = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT C.PRIMER_NOMBRE, C.SEGUNDO_NOMBRE, C.PRIMER_APELLIDO, C.SEGUNDO_APELLIDO, " +
                         "C.OBJETIVO_CANDIDATO, C.TELEFONO_CANDIDATO, C.EMAIL_CANDIDATO, C.SEXO_CANDIDATO, C.ESTADO_CANDIDATO, C.EDAD_CANDIDATO " +
                         "FROM CANDIDATO C " +
                         "WHERE C.ID_CANDIDATO = @ID_CANDIDATO";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

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

        public byte[] ObtenerImagenCandidato(int idCandidato)
        {
            byte[] imagenCandidato = null;

            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT RUTA_IMAGEN_CANDIDATO FROM CANDIDATO WHERE ID_CANDIDATO = @ID_CANDIDATO";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        imagenCandidato = (byte[])result;
                    }
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }

            return imagenCandidato;
        }




        public DataTable GetHabilidadesPorCandidato(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT H.NOMBRE_HABILIDAD " +
                         "FROM CANDIDATO_HABILIDAD CH " +
                         "INNER JOIN HABILIDAD H ON CH.ID_HABILIDAD = H.ID_HABILIDAD " +
                         "WHERE CH.ID_CANDIDATO = @ID_CANDIDATO";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                dataTable.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return dataTable;
        }


        public DataTable GetCompetenciasPorCandidato(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT CO.NOMBRE_COMPETENCIA, CO.DOMINIO " +
                         "FROM CANDIDATO_COMPETENCIA CC " +
                         "INNER JOIN COMPETENCIA CO ON CC.ID_COMPETENCIA = CO.ID_COMPETENCIA " +
                         "WHERE CC.ID_CANDIDATO = @ID_CANDIDATO";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                dataTable.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return dataTable;
        }


        public DataTable GetExpLaboPorCandidato(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT CARGO, INSTITUCION, ANIO_INICIO, ANIO_FIN " +
                         "FROM EXPERIENCIA_PROFESIONAL " +
                         "WHERE ID_CANDIDATO = @ID_CANDIDATO " +
                         "ORDER BY ANIO_INICIO DESC";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                dataTable.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return dataTable;
        }


        public DataTable GetFormaAcaPorCandidato(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT INSTITUCION, TITULO, ANIO_INICIO, ANIO_FIN " +
                         "FROM FORMACION_ACADEMICA " +
                         "WHERE ID_CANDIDATO = @ID_CANDIDATO " +
                         "ORDER BY ANIO_INICIO DESC";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                dataTable.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return dataTable;
        }

        public DataTable GetRefeLaboPorCandidato(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT NOMBRE, APELLIDO, CARGO, TELEFONO " +
                         "FROM REFERENCIA_LABORAL " +
                         "WHERE ID_CANDIDATO = @ID_CANDIDATO";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                dataTable.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return dataTable;
        }


        public DataTable GetRefePersoPorCandidato(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT NOMBRE, APELLIDO, CARGO, TELEFONO " +
                         "FROM REFERENCIA_PERSONAL " +
                         "WHERE ID_CANDIDATO = @ID_CANDIDATO";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                dataTable.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return dataTable;
        }




        public int InsertarCandidato(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string objetivo, string telefono, string email, string genero, int idUsuario, string estado, int edad, byte[] fotografia)
        {
            int idCandidato = 0;

            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "INSERT INTO CANDIDATO (ID_USUARIO, PRIMER_NOMBRE, SEGUNDO_NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, SEXO_CANDIDATO, OBJETIVO_CANDIDATO, TELEFONO_CANDIDATO, EMAIL_CANDIDATO, ESTADO_CANDIDATO, EDAD_CANDIDATO, RUTA_IMAGEN_CANDIDATO) " +
                         "VALUES (@ID_USUARIO, @PRIMER_NOMBRE, @SEGUNDO_NOMBRE, @PRIMER_APELLIDO, @SEGUNDO_APELLIDO, @SEXO_CANDIDATO, @OBJETIVO_CANDIDATO, @TELEFONO_CANDIDATO, @EMAIL_CANDIDATO, @ESTADO_CANDIDATO, @EDAD_CANDIDATO, @RUTA_IMAGEN_CANDIDATO); " +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID_USUARIO", idUsuario);
                cmd.Parameters.AddWithValue("@PRIMER_NOMBRE", primerNombre);
                cmd.Parameters.AddWithValue("@SEGUNDO_NOMBRE", segundoNombre);
                cmd.Parameters.AddWithValue("@PRIMER_APELLIDO", primerApellido);
                cmd.Parameters.AddWithValue("@SEGUNDO_APELLIDO", segundoApellido);
                cmd.Parameters.AddWithValue("@SEXO_CANDIDATO", genero);
                cmd.Parameters.AddWithValue("@OBJETIVO_CANDIDATO", objetivo);
                cmd.Parameters.AddWithValue("@TELEFONO_CANDIDATO", telefono);
                cmd.Parameters.AddWithValue("@EMAIL_CANDIDATO", email);
                cmd.Parameters.AddWithValue("@ESTADO_CANDIDATO", estado);
                cmd.Parameters.AddWithValue("@EDAD_CANDIDATO", edad);
                cmd.Parameters.AddWithValue("@RUTA_IMAGEN_CANDIDATO", fotografia);

                try
                {
                    conn.Open();
                    // Obtener el ID del candidato recién insertado
                    idCandidato = Convert.ToInt32(cmd.ExecuteScalar());
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }

            return idCandidato;
        }




        public DataTable ObtenerHabilidades()
        {
            DataTable tabla = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT ID_HABILIDAD, NOMBRE_HABILIDAD FROM HABILIDAD";

            SqlCommand cmd = new SqlCommand(sql, conn);

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                try
                {
                    conn.Open();
                    adapter.Fill(tabla);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }

            return tabla;
        }

        public void AgregarHabilidadACandidato(int idCandidato, int idHabilidad)
        {
            cConexion conectar = new cConexion();
            using (SqlConnection conn = conectar.ConexionServer())
            {
                string sql = "INSERT INTO CANDIDATO_HABILIDAD (ID_CANDIDATO, ID_HABILIDAD) VALUES (@ID_CANDIDATO, @ID_HABILIDAD)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);
                cmd.Parameters.AddWithValue("@ID_HABILIDAD", idHabilidad);

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

        public int ObtenerIdHabilidadPorNombre(string nombreHabilidad)
        {
            int idHabilidad = 0; // Valor predeterminado en caso de no encontrar la habilidad

            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string sql = "SELECT ID_HABILIDAD FROM HABILIDAD WHERE NOMBRE_HABILIDAD = @NombreHabilidad";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@NombreHabilidad", nombreHabilidad);

                    // Ejecuta la consulta y obtén el resultado
                    var result = cmd.ExecuteScalar();

                    // Si el resultado no es nulo, conviértelo a entero (ID de habilidad)
                    if (result != null && int.TryParse(result.ToString(), out idHabilidad))
                    {
                        
                    }
                }
            }

            return idHabilidad;
        }


        public DataTable ObtenerCompetenciasConDominioAgrupadas()
        {
            DataTable competencias = new DataTable();

            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string query = "SELECT NOMBRE_COMPETENCIA + ' - ' + DOMINIO AS NOMBRE_DOMINIO, ID_COMPETENCIA FROM COMPETENCIA";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(competencias);
                    }
                }

                connection.Close();
            }

            // Crear una vista para agrupar y ordenar
            DataView view = new DataView(competencias);
            view.Sort = "NOMBRE_DOMINIO";

            // Crear un nuevo DataTable agrupado
            DataTable competenciasAgrupadas = view.ToTable(true, "NOMBRE_DOMINIO", "ID_COMPETENCIA");

            return competenciasAgrupadas;
        }




        // Método para agregar una competencia al candidato actual
        public void AgregarCompetenciaACandidato(int idCandidato, int idCompetencia)
        {
            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string query = "INSERT INTO CANDIDATO_COMPETENCIA (ID_CANDIDATO, ID_COMPETENCIA) VALUES (@ID_CANDIDATO, @ID_COMPETENCIA)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);
                    command.Parameters.AddWithValue("@ID_COMPETENCIA", idCompetencia);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public DataTable ObtenerExperienciaLaboral(int idCandidato)
        {
            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string query = "SELECT * FROM EXPERIENCIA_PROFESIONAL WHERE ID_CANDIDATO = @ID_CANDIDATO";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }


        public void InsertarExperienciaLaboral(int idCandidato, string cargo, string institucion, DateTime fechaInicio, DateTime fechaFin)
        {
            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string query = "INSERT INTO EXPERIENCIA_PROFESIONAL (ID_CANDIDATO, CARGO, INSTITUCION, ANIO_INICIO, ANIO_FIN) " +
                               "VALUES (@ID_CANDIDATO, @CARGO, @INSTITUCION, @ANIO_INICIO, @ANIO_FIN)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);
                    command.Parameters.AddWithValue("@CARGO", cargo);
                    command.Parameters.AddWithValue("@INSTITUCION", institucion);
                    command.Parameters.AddWithValue("@ANIO_INICIO", fechaInicio);
                    command.Parameters.AddWithValue("@ANIO_FIN", fechaFin);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Agrega el método a la clase CandidatoModel
        public void InsertarFormacionAcademica(int idCandidato, string institucion, string titulo, string departamento, DateTime fechaInicio, DateTime fechaFin)
        {
            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string query = "INSERT INTO FORMACION_ACADEMICA (ID_CANDIDATO, INSTITUCION, TITULO, DEPARTAMENTO, ANIO_INICIO, ANIO_FIN) " +
                               "VALUES (@ID_CANDIDATO, @INSTITUCION, @TITULO, @DEPARTAMENTO, @ANIO_INICIO, @ANIO_FIN)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);
                    command.Parameters.AddWithValue("@INSTITUCION", institucion);
                    command.Parameters.AddWithValue("@TITULO", titulo);
                    command.Parameters.AddWithValue("@DEPARTAMENTO", departamento);
                    command.Parameters.AddWithValue("@ANIO_INICIO", fechaInicio);
                    command.Parameters.AddWithValue("@ANIO_FIN", fechaFin);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Agrega el método a la clase CandidatoModel
        public DataTable ObtenerFormacionAcademica(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string query = "SELECT INSTITUCION, TITULO, DEPARTAMENTO, ANIO_INICIO, ANIO_FIN " +
                               "FROM FORMACION_ACADEMICA " +
                               "WHERE ID_CANDIDATO = @ID_CANDIDATO " +
                               "ORDER BY ANIO_INICIO DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }


        // Agrega estos métodos a tu clase CandidatoModel

        public void AgregarReferenciaLaboral(int idCandidato, string nombre, string apellido, string cargo, int telefono)
        {
            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string query = "INSERT INTO REFERENCIA_LABORAL (ID_CANDIDATO, NOMBRE, APELLIDO, CARGO, TELEFONO) " +
                               "VALUES (@ID_CANDIDATO, @NOMBRE, @APELLIDO, @CARGO, @TELEFONO)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);
                    command.Parameters.AddWithValue("@NOMBRE", nombre);
                    command.Parameters.AddWithValue("@APELLIDO", apellido);
                    command.Parameters.AddWithValue("@CARGO", cargo);
                    command.Parameters.AddWithValue("@TELEFONO", telefono);

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerReferenciasLaborales(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT NOMBRE, APELLIDO, CARGO, TELEFONO FROM REFERENCIA_LABORAL WHERE ID_CANDIDATO = @ID_CANDIDATO";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

                SqlDataReader mydr = null;
                try
                {
                    conn.Open();
                    mydr = cmd.ExecuteReader();
                    dataTable.Load(mydr);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            return dataTable;
        }

        public void AgregarReferenciaPersonal(int idCandidato, string nombre, string apellido, string cargo, int telefono)
        {
            cConexion conectar = new cConexion();
            using (SqlConnection connection = conectar.ConexionServer())
            {
                connection.Open();

                string query = "INSERT INTO REFERENCIA_PERSONAL (ID_CANDIDATO, NOMBRE, APELLIDO, CARGO, TELEFONO) " +
                               "VALUES (@ID_CANDIDATO, @NOMBRE, @APELLIDO, @CARGO, @TELEFONO)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);
                    command.Parameters.AddWithValue("@NOMBRE", nombre);
                    command.Parameters.AddWithValue("@APELLIDO", apellido);
                    command.Parameters.AddWithValue("@CARGO", cargo);
                    command.Parameters.AddWithValue("@TELEFONO", telefono);

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerReferenciasPersonales(int idCandidato)
        {
            DataTable dataTable = new DataTable();
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "SELECT NOMBRE, APELLIDO, CARGO, TELEFONO FROM REFERENCIA_PERSONAL WHERE ID_CANDIDATO = @ID_CANDIDATO";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID_CANDIDATO", idCandidato);

                SqlDataReader mydr = null;
                try
                {
                    conn.Open();
                    mydr = cmd.ExecuteReader();
                    dataTable.Load(mydr);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            return dataTable;
        }


        public void ActualizarEstadoCandidato(int idCandidato, string nuevoEstado)
        {
            cConexion conectar = new cConexion();
            SqlConnection conn = conectar.ConexionServer();

            string sql = "UPDATE CANDIDATO SET ESTADO_CANDIDATO = @NuevoEstado WHERE ID_CANDIDATO = @IDCandidato";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                cmd.Parameters.AddWithValue("@IDCandidato", idCandidato);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }


    }
}
