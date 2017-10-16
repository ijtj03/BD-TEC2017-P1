using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class GestionMedicamento
    {
        public int IdCasaFarmaceutica { get; set; }
        public int IdSucursal { get; set; }
        public int IdMedicamento { get; set; }
        public string NombreCasaFarmaceutica { get; set; }
        public string Nombre { get; set; }
        public bool NecesitaReceta { get; set; }
        public int Cantidad { get; set; }
        public int PrecioSucursal { get; set; }
        public int PrecioProveedor { get; set; }
    }
}