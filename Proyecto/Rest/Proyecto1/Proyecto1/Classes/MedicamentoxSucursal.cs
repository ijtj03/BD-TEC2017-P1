using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class MedicamentoxSucursal
    {
        public int IdMedicamento { get; set; }
        public int IdSucursal { get; set; }
        public int Cantidad { get; set; }
        public int PrecioSucursal { get; set; }
        public bool Logicdelete { get; set; }
    }
}