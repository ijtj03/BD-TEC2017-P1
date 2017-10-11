using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class MedicamentoId
    {
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string Nombre { get; set; }
        public int IdMedicamento { get; internal set; }
    }
}