using Microsoft.Reporting.WinForms;
using SistemaRRHH.Models;
using SistemaRRHH.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class frmVisorReporte : Form
    {
        private string buscar;

        private readonly cDireccion direccion = new cDireccion();
        public frmVisorReporte()
        {
            InitializeComponent();
        }

        public string Buscar1 { get => buscar; set => buscar = value; }

        
        private void frmVisorReporte_Load(object sender, EventArgs e)
        {

            CargarReporte();
        }

        private void CargarReporte()
        {
            //Coleccion de Direcciones
            List<cDireccion> registros = new List<cDireccion>();

            //Recorremos la coleccion y enviamso el parametro buscar
            foreach(DataRow dtRow in direccion.GetCandidatos().Rows)
            {
                // Agregando la data encontrada
                registros.Add(new cDireccion
                {
                    IdCandidato = dtRow["ID_CANDIDATO"].ToString(),
                    //Convert.ToInt64(dtRow["ID_CANDIDATO"].ToString()),
                    PrimerNombre = dtRow["PRIMER_NOMBRE"].ToString(),
                    SegundoNombre = dtRow["SEGUNDO_NOMBRE"].ToString(),
                    PrimerApellido = dtRow["PRIMER_APELLIDO"].ToString(),
                    SegundoApellido = dtRow["SEGUNDO_APELLIDO"].ToString(),
                    Edad = dtRow["EDAD_CANDIDATO"].ToString(),
                    //Edad = Convert.ToInt64(dtRow["EDAD_CANDIDATO"].ToString()),
                    Email = dtRow["EMAIL_CANDIDATO"].ToString(),
                    Sexo = dtRow["SEXO_CANDIDATO"].ToString(),
                    Telefono = dtRow["TELEFONO_CANDIDATO"].ToString(),
                    //Telefono = Convert.ToInt64(dtRow["TELEFONO_CANDIDATO"].ToString()),
                    Objetivo = dtRow["OBJETIVO_CANDIDATO"].ToString(),
                });
            }

            //Mostrar datos en el reporte
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaRRHH.ReportDirecciones.rdlc";
            ReportDataSource rsd1 = new ReportDataSource("Direcciones", registros);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rsd1);
            this.reportViewer1.RefreshReport();
        }
    }
}
