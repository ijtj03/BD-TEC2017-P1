using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCedula { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }
        public bool LogicDelete { get; set; }
        public object FechaRecojo { get; set; }
    }
}