using Proyecto_POE_Boceto;
using SistemaRRHH.Cache;
using SistemaRRHH.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH.Presenters
{

    internal class CandidatoPresenter
    {
        private CandidatoModel objetoCD = new CandidatoModel();


        public int IdCandidatoActual { get; private set; }

        public DataTable MostrarCandidato()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.GetCandidatos();
            return tabla;
        }
        public void EliminarCandidato(int idcandidato)
        {
            objetoCD.EliminarCandidato(idcandidato);
        }


        public DataTable BusquedaSimpleCandidato(string habilidad)
        {
            DataTable tabla = new DataTable();
            if (string.IsNullOrWhiteSpace(habilidad))
            {
                tabla = objetoCD.GetCandidatos();
            }
            else
            {
                tabla = objetoCD.GetCandidatosPorHabilidad(habilidad);
            }
            return tabla;
        }

        public DataTable buscarRegistro(string campo, string valorCampo)
        {
            return objetoCD.buscar(campo, valorCampo);
        }
        public void MostrarInformacionCandidato(int idCandidato, FormCrearCandidato formCrearCandidato)
        {
            DataTable dataTable = objetoCD.GetCandidatoPorId(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                // Asignar la información a los controles en formCrearCandidato
                formCrearCandidato.SetInformacionCandidato(
                    row["PRIMER_NOMBRE"].ToString(),
                    row["SEGUNDO_NOMBRE"].ToString(),
                    row["PRIMER_APELLIDO"].ToString(),
                    row["SEGUNDO_APELLIDO"].ToString(),
                    row["OBJETIVO_CANDIDATO"].ToString(),
                    row["TELEFONO_CANDIDATO"].ToString(),
                    row["EMAIL_CANDIDATO"].ToString(),
                    row["SEXO_CANDIDATO"].ToString(),
                    row["ESTADO_CANDIDATO"].ToString(),
                    (int)row["EDAD_CANDIDATO"]
                );

                // Llenar lstBxHabilidades
                LlenarListBoxHabilidades(idCandidato, formCrearCandidato.lstBxHabilidades);

                // Llenar lstBxCompetencias
                LlenarListBoxCompetencias(idCandidato, formCrearCandidato.lstBxCompetencias);

                // Llenar lstBxExpLabo
                LlenarListBoxExpLabo(idCandidato, formCrearCandidato.lstBxExpLabo);

                // Llenar lstBxFormaAca
                LlenarListBoxFormaAca(idCandidato, formCrearCandidato.lstBxFormaAca);

                // Llenar lstBxRefeLabo
                LlenarListBoxRefeLabo(idCandidato, formCrearCandidato.lstBxRefeLabo);

                // Llenar lstBxRefePerso
                LlenarListBoxRefePerso(idCandidato, formCrearCandidato.lstBxRefePerso);

                // Obtener la imagen del candidato
                byte[] imagenCandidato = objetoCD.ObtenerImagenCandidato(idCandidato);

                // Establecer la imagen en el pictureBoxFoto
                formCrearCandidato.SetImagenCandidato(imagenCandidato);
            }
        }




        private void LlenarListBoxHabilidades(int idCandidato, ListBox lstBxHabilidades)
        {
            DataTable dataTable = objetoCD.GetHabilidadesPorCandidato(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Limpiar la lista antes de agregar nuevas habilidades
                lstBxHabilidades.Items.Clear();

                // Recorrer las habilidades y agregarlas al ListBox
                foreach (DataRow row in dataTable.Rows)
                {
                    lstBxHabilidades.Items.Add(row["NOMBRE_HABILIDAD"].ToString());
                }
            }
        }

        private void LlenarListBoxCompetencias(int idCandidato, ListBox lstBxCompetencias)
        {
            DataTable dataTable = objetoCD.GetCompetenciasPorCandidato(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Limpiar la lista antes de agregar nuevas competencias
                lstBxCompetencias.Items.Clear();

                // Recorrer las competencias y agregarlas al ListBox con su dominio
                foreach (DataRow row in dataTable.Rows)
                {
                    string competencia = row["NOMBRE_COMPETENCIA"].ToString();
                    string dominio = row["DOMINIO"].ToString();
                    lstBxCompetencias.Items.Add($"{competencia} - {dominio}");
                }
            }
        }

        private void LlenarListBoxExpLabo(int idCandidato, ListBox lstBxExpLabo)
        {
            DataTable dataTable = objetoCD.GetExpLaboPorCandidato(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Limpiar la lista antes de agregar nuevas experiencias laborales
                lstBxExpLabo.Items.Clear();

                // Recorrer las experiencias laborales y agregarlas al ListBox con el formato deseado
                foreach (DataRow row in dataTable.Rows)
                {
                    string cargo = row["CARGO"].ToString();
                    string institucion = row["INSTITUCION"].ToString();
                    string anioInicio = ((DateTime)row["ANIO_INICIO"]).Year.ToString();
                    string anioFin = ((DateTime)row["ANIO_FIN"]).Year.ToString();

                    string experiencia = $"{cargo}\n{institucion}\n{anioInicio} - {anioFin}\n";
                    lstBxExpLabo.Items.Add(experiencia);
                    lstBxExpLabo.Items.Add("\n"); // Doble salto de línea
                }
            }
        }

        private void LlenarListBoxFormaAca(int idCandidato, ListBox lstBxFormaAca)
        {
            DataTable dataTable = objetoCD.GetFormaAcaPorCandidato(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Limpiar la lista antes de agregar nuevas formaciones académicas
                lstBxFormaAca.Items.Clear();

                // Recorrer las formaciones académicas y agregarlas al ListBox con el formato deseado
                foreach (DataRow row in dataTable.Rows)
                {
                    string institucion = row["INSTITUCION"].ToString();
                    string titulo = row["TITULO"].ToString();
                    string anioInicio = ((DateTime)row["ANIO_INICIO"]).Year.ToString();
                    string anioFin = ((DateTime)row["ANIO_FIN"]).Year.ToString();

                    string formacionAca = $"{institucion}\n{titulo}\n{anioInicio} - {anioFin}\n";
                    lstBxFormaAca.Items.Add(formacionAca);
                    lstBxFormaAca.Items.Add("\n"); // Doble salto de línea
                }
            }
        }


        private void LlenarListBoxRefeLabo(int idCandidato, ListBox lstBxRefeLabo)
        {
            DataTable dataTable = objetoCD.GetRefeLaboPorCandidato(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Limpiar la lista antes de agregar nuevas referencias laborales
                lstBxRefeLabo.Items.Clear();

                // Recorrer las referencias laborales y agregarlas al ListBox con el formato deseado
                foreach (DataRow row in dataTable.Rows)
                {
                    string nombre = $"{row["NOMBRE"]} {row["APELLIDO"]}";
                    string cargo = row["CARGO"].ToString();
                    string telefono = row["TELEFONO"].ToString();

                    string referenciaLaboral = $"{nombre}\n{cargo}\n{telefono}\n";
                    lstBxRefeLabo.Items.Add(referenciaLaboral);
                    lstBxRefeLabo.Items.Add("\n"); // Doble salto de línea
                }
            }
        }

        private void LlenarListBoxRefePerso(int idCandidato, ListBox lstBxRefePerso)
        {
            DataTable dataTable = objetoCD.GetRefePersoPorCandidato(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Limpiar la lista antes de agregar nuevas referencias personales
                lstBxRefePerso.Items.Clear();

                // Recorrer las referencias personales y agregarlas al ListBox con el formato deseado
                foreach (DataRow row in dataTable.Rows)
                {
                    string nombre = $"{row["NOMBRE"]} {row["APELLIDO"]}";
                    string cargo = row["CARGO"].ToString();
                    string telefono = row["TELEFONO"].ToString();

                    string referenciaPersonal = $"{nombre}\n{cargo}\n{telefono}\n";
                    lstBxRefePerso.Items.Add(referenciaPersonal);
                    lstBxRefePerso.Items.Add("\n"); // Doble salto de línea
                }
            }
        }

        public void InsertarCandidato(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string objetivo, string telefono, string email, string genero, string estado, int edad, byte[] fotografia)
        {
            // Obtener el IdUsuario de la caché
            int idUsuario = UsuarioLoginCache.IdUsuario;

            // Llama al método InsertarCandidato del modelo y pasa el IdUsuario y la fotografía
            IdCandidatoActual = objetoCD.InsertarCandidato(primerNombre, segundoNombre, primerApellido, segundoApellido, objetivo, telefono, email, genero, idUsuario, estado, edad, fotografia);
            MessageBox.Show("Candidato agregado correctamente. ID del Candidato: " + IdCandidatoActual, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public DataTable ObtenerHabilidades()
        {
            return objetoCD.ObtenerHabilidades();
        }

        public void AgregarHabilidadACandidato(int idCandidato, int idHabilidad)
        {
            // Llama al método correspondiente en el modelo para agregar la habilidad al candidato
            objetoCD.AgregarHabilidadACandidato(idCandidato, idHabilidad);
        }

        public void MostrarHabilidadesCandidato(int idCandidato, ListBox lstBxHabilidades)
        {
            // Obtener las habilidades del candidato
            DataTable dataTable = objetoCD.GetHabilidadesPorCandidato(idCandidato);

            if (dataTable.Rows.Count > 0)
            {
                // Limpiar la lista antes de agregar nuevas habilidades
                lstBxHabilidades.Items.Clear();

                // Recorrer las habilidades y agregarlas al ListBox
                foreach (DataRow row in dataTable.Rows)
                {
                    lstBxHabilidades.Items.Add(row["NOMBRE_HABILIDAD"].ToString());
                }
            }
        }

        public int ObtenerIdHabilidadPorNombre(string nombreHabilidad)
        {
            // Llama al método correspondiente en el modelo para obtener el ID de la habilidad
            return objetoCD.ObtenerIdHabilidadPorNombre(nombreHabilidad);
        }


        public DataTable GetHabilidadesPorCandidato(int idCandidato)
        {
            return objetoCD.GetHabilidadesPorCandidato(idCandidato);
        }


        // Método para obtener todas las competencias
        public DataTable ObtenerCompetenciasConDominioAgrupadas()
        {
            return objetoCD.ObtenerCompetenciasConDominioAgrupadas();
        }

        // Método para agregar una competencia al candidato actual
        public void AgregarCompetenciaACandidato(int idCandidato, int idCompetencia)
        {
            objetoCD.AgregarCompetenciaACandidato(idCandidato, idCompetencia);
        }

        public DataTable ObtenerCompetenciasPorCandidato(int idCandidato)
        {
            return objetoCD.GetCompetenciasPorCandidato(idCandidato);
        }


        public DataTable ObtenerExperienciaLaboral(int idCandidato)
        {
            return objetoCD.ObtenerExperienciaLaboral(idCandidato);
        }

        public void InsertarExperienciaLaboral(int idCandidato, string cargo, string institucion, DateTime fechaInicio, DateTime fechaFin)
        {
            objetoCD.InsertarExperienciaLaboral(idCandidato, cargo, institucion, fechaInicio, fechaFin);
        }

        // Agrega el método al presentador
        public void AgregarFormacionAcademica(int idCandidato, string institucion, string titulo, string departamento, DateTime fechaInicio, DateTime fechaFin)
        {
            // Llamamos al método del modelo para insertar la Formación Académica
            objetoCD.InsertarFormacionAcademica(idCandidato, institucion, titulo, departamento, fechaInicio, fechaFin);

        }

        public DataTable ObtenerFormacionAcademica(int idCandidato)
        {
            return objetoCD.ObtenerFormacionAcademica(idCandidato);
        }

        public void AgregarReferenciaLaboral(int idCandidato, string nombre, string apellido, string cargo, int telefono)
        {
            objetoCD.AgregarReferenciaLaboral(idCandidato, nombre, apellido, cargo, telefono);
        }

        public DataTable ObtenerReferenciasLaborales(int idCandidato)
        {
            return objetoCD.ObtenerReferenciasLaborales(idCandidato);
        }

        public void AgregarReferenciaPersonal(int idCandidato, string nombre, string apellido, string cargo, int telefono)
        {
            objetoCD.AgregarReferenciaPersonal(idCandidato, nombre, apellido, cargo, telefono);
        }

        public DataTable ObtenerReferenciasPersonales(int idCandidato)
        {
            return objetoCD.ObtenerReferenciasPersonales(idCandidato);
        }

        public void EditarEstadoCandidato(int idCandidato, string nuevoEstado)
        {
            // Validar que el nuevo estado sea "Activo" o "Inactivo"
            if (nuevoEstado != "Activo" && nuevoEstado != "Inactivo")
            {
                MessageBox.Show("El estado proporcionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar al método en la clase Model para actualizar el estado
            objetoCD.ActualizarEstadoCandidato(idCandidato, nuevoEstado);

            // Mostrar mensaje de éxito
            MessageBox.Show($"El estado del candidato con ID {idCandidato} se ha actualizado a {nuevoEstado}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualizar la vista
            MostrarCandidato();
        }

    }

}
