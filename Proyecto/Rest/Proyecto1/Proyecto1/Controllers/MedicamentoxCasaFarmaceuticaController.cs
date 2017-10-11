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
    [RoutePrefix("api/MedicamentoxCasaFarmaceutica")]
    public class MedicamentoxCasaFarmaceuticaController : ApiController
    {

        [HttpGet]
        [Route("GetAllMedicamentoxCasaFarmaceutica")]
        public IHttpActionResult GetAllMedicamentoxCasaFarmaceutica()
        {
            MedicamentoxCasaFarmaceuticaService con = new MedicamentoxCasaFarmaceuticaService();
            return Ok(con.GetAllMedicamentoxCasaFarmaceutica());
        }

        [HttpPost]
        [Route("PostMedicamentoxCasaFarmaceutica")]
        public void PostMedicamento([FromBody] MedicamentoxCasaFarmaceutica mxcf)
        {
            MedicamentoxCasaFarmaceuticaService con = new MedicamentoxCasaFarmaceuticaService();
            con.PostMedicamentoxCasaFarmaceutica(mxcf);
        }
    }
}
