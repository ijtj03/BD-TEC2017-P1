using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class MedicamentoxCasaFarmaceutica
    {
        public int IdMedicamento { get; set; }
        public int IdCasaFarmaceutica { get; set; }
        public int PrecioProveedor { get; set; }
        public bool LogicDelete { get; set; }
    }
}