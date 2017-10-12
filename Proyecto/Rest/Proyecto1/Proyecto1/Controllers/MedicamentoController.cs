using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto1.Services;
using Proyecto1.Classes;

namespace Proyecto1.Controllers
{
    [RoutePrefix("api/Medicamento")]
    public class MedicamentoController : ApiController
    {
        [HttpGet]
        [Route("GetAllMedicamentos")]
        public IHttpActionResult GetAllMedicamentos()
        {
            MedicamentoService con = new MedicamentoService();
            return Ok(con.GetAllMedicamentos());
        }
        
        [HttpPost]
        [Route("PostMedicamento")]
        public void PostMedicamento([FromBody] Medicamento medicamento )
        {
            MedicamentoService con = new MedicamentoService();
            con.PostMedicamento(medicamento);
        }




    }    
}
