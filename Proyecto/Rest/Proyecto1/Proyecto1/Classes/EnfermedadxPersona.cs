using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class EnfermedadxPersona
    {
        public int IdCedula { get; set; }
        public string FechaEnfermedad { get; set; }
        public int IdEnfermedad { get; set; }
        public bool LogicDelete { get; set; }

    }
}