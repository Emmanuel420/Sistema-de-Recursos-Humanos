using Microsoft.Reporting.WinForms;
using SistemaRRHH.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRRHH;

namespace SistemaRRHH
{
    public partial class frmReporte : Form
    {

        public List<UsuarioView> Datos = new List<UsuarioView>();
        public frmReporte()
        {
            InitializeComponent();
        }
        private void frmReporte_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("cANDIDATOBindingSource", dt);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
        }

        private void frmReporte_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'recursosHumanosDataSet2.CANDIDATO' Puede moverla o quitarla según sea necesario.
            //cANDIDATOTableAdapter.Fill(this.recursosHumanosDataSet1.CANDIDATO);
            // TODO: esta línea de código carga datos en la tabla 'recursosHumanosDataSet2.CANDIDATO' Puede moverla o quitarla según sea necesario.
            //this.RecursosHumanosDataSet2.CANDIDATO.Fill(this.recursosHumanosDataSet2);

            reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSouce("Dataset1", Datos);
            reportViewer1.RefreshReport();
            
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
