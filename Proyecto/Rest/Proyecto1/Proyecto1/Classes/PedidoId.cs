using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class PedidosId
    {
        public int IdPedido { get; set; }
        public string NombreSucursal { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string FechaRecojo { get; set; }
    }
}