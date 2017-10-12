using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class Rol
    {
        public int IdRol { get; set; }
        public int IdCedula { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool LogicDelete { get; set; }
    }
}