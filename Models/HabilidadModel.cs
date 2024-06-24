using SistemaRRHH.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH.Models
{
    internal class HabilidadModel
    {
        public bool AgregarHabilidad(string nombreHabilidad)
        {
            try
            {
                using (SqlConnection conn = new cConexion().ConexionServer())
                {
                    conn.Open();

                    // Consulta para insertar una nueva habilidad
                    string query = "INSERT INTO HABILIDAD (NOMBRE_HABILIDAD) VALUES (@NombreHabilidad)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreHabilidad", nombreHabilidad);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error al agregar habilidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public bool AgregarCompetencia(string nombreCompetencia)
        {
            try
            {
                using (SqlConnection conn = new cConexion().ConexionServer())
                {
                    conn.Open();

                    // Consulta para insertar una nueva competencia con dominio "Básico"
                    string query = "INSERT INTO COMPETENCIA (NOMBRE_COMPETENCIA, DOMINIO) VALUES (@NombreCompetencia, 'Básico')";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreCompetencia", nombreCompetencia);
                        cmd.ExecuteNonQuery();
                    }

                    // Consulta para insertar una nueva competencia con dominio "Intermedio"
                    query = "INSERT INTO COMPETENCIA (NOMBRE_COMPETENCIA, DOMINIO) VALUES (@NombreCompetencia, 'Intermedio')";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreCompetencia", nombreCompetencia);
                        cmd.ExecuteNonQuery();
                    }

                    // Consulta para insertar una nueva competencia con dominio "Avanzado"
                    query = "INSERT INTO COMPETENCIA (NOMBRE_COMPETENCIA, DOMINIO) VALUES (@NombreCompetencia, 'Avanzado')";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreCompetencia", nombreCompetencia);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error al agregar competencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }
}
