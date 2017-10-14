using Proyecto1.Classes;
using Proyecto1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1.Controllers
{

    [RoutePrefix("api/MedicamentoxReceta")]
    public class MedicamentoxReceta : ApiController
    {
        
        [HttpPost]
        [Route("PostMedicamentoxReceta")]
        public void PostMedicamentoxReceta([FromBody] PedidoxMedicamento cFar)
        {
            MedicamentoxRecetaService con = new MedicamentoxRecetaService();
            con.PostMedicamentoxReceta(cFar);
        }
    }
}
