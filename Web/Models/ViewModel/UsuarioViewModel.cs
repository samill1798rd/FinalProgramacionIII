using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Iglesias = new List<Iglesia>();
        }

        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public virtual ICollection<Iglesia> Iglesias { get; set; }
    }
}