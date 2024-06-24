using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRRHH.Cache
{
    public static class UsuarioLoginCache
    {
        public static int IdUsuario {  get; set; }
        public static int IdRol {  get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Email {  get; set; }
    }
}
