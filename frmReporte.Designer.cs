namespace SistemaRRHH
{
    partial class frmReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.recursosHumanosDataSet = new SistemaRRHH.RecursosHumanosDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.recursosHumanosDataSet2 = new SistemaRRHH.RecursosHumanosDataSet2();
            this.cANDIDATOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cANDIDATOTableAdapter = new SistemaRRHH.RecursosHumanosDataSet2TableAdapters.CANDIDATOTableAdapter();
            this.recursosHumanosDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recursosHumanosDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recursosHumanosDataSet1 = new SistemaRRHH.RecursosHumanosDataSet1();
            this.recursosHumanosDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cANDIDATOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // recursosHumanosDataSet
            // 
            this.recursosHumanosDataSet.DataSetName = "RecursosHumanosDataSet";
            this.recursosHumanosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.cANDIDATOBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.recursosHumanosDataSet1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaRRHH.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // recursosHumanosDataSet2
            // 
            this.recursosHumanosDataSet2.DataSetName = "RecursosHumanosDataSet2";
            this.recursosHumanosDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cANDIDATOBindingSource
            // 
            this.cANDIDATOBindingSource.DataMember = "CANDIDATO";
            this.cANDIDATOBindingSource.DataSource = this.recursosHumanosDataSet2;
            // 
            // cANDIDATOTableAdapter
            // 
            this.cANDIDATOTableAdapter.ClearBeforeFill = true;
            // 
            // recursosHumanosDataSet2BindingSource
            // 
            this.recursosHumanosDataSet2BindingSource.DataSource = this.recursosHumanosDataSet2;
            this.recursosHumanosDataSet2BindingSource.Position = 0;
            // 
            // recursosHumanosDataSetBindingSource
            // 
            this.recursosHumanosDataSetBindingSource.DataSource = this.recursosHumanosDataSet;
            this.recursosHumanosDataSetBindingSource.Position = 0;
            // 
            // recursosHumanosDataSet1
            // 
            this.recursosHumanosDataSet1.DataSetName = "RecursosHumanosDataSet1";
            this.recursosHumanosDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recursosHumanosDataSet1BindingSource
            // 
            this.recursosHumanosDataSet1BindingSource.DataSource = this.recursosHumanosDataSet1;
            this.recursosHumanosDataSet1BindingSource.Position = 0;
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporte";
            this.Text = "frmReporte";
            this.Load += new System.EventHandler(this.frmReporte_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cANDIDATOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private RecursosHumanosDataSet recursosHumanosDataSet;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private RecursosHumanosDataSet2 recursosHumanosDataSet2;
        private System.Windows.Forms.BindingSource cANDIDATOBindingSource;
        private RecursosHumanosDataSet2TableAdapters.CANDIDATOTableAdapter cANDIDATOTableAdapter;
        private System.Windows.Forms.BindingSource recursosHumanosDataSet2BindingSource;
        private System.Windows.Forms.BindingSource recursosHumanosDataSetBindingSource;
        private System.Windows.Forms.BindingSource recursosHumanosDataSet1BindingSource;
        private RecursosHumanosDataSet1 recursosHumanosDataSet1;
    }
}