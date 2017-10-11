using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class PedidoxMedicamento
    {
        public int IdPedido { get; set; }
        public int IdMedicamento { get; set; }
        public int Cantidad { get; set; }
        public string RecetaImg { get; set; }
        public bool LogicDelete { get; set; }
    }

}