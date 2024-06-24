using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRRHH.Views
{
    public interface UsuarioView
    {

        //Properties - Fields
        string Id { get; set; }
        string Nombre { get; set; }
        string Nombre2 { get; set; }
        string Apellido { get; set; }
        string Apellido2 { get; set; }
        string Objetivo { get; set; }
        string Telefono { get; set; }
        string Email { get; set; }
        string Departamento { get; set; }
        string Habilidad { get; set; }
        string Competencia { get; set; }
       // string Experiencia { get; set; }
      //  string Formacion { get; set; }
      /*  string ReferenciaL { get; set; }
        string ReferenciaP { get; set; }*/


        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        //Methods
        void SetCandidatoListBindingSource(BindingSource candidatoList);
        void Show();
    }
}
