using SistemaRRHH.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRRHH.Presenters
{
    internal class CandidatoPresenter
    {
        private CandidatoModel objetoCD = new CandidatoModel();
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
    }
}
