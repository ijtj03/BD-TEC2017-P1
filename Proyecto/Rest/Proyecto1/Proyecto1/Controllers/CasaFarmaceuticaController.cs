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
    [RoutePrefix("api/CasaFarmaceutica")]
    public class CasaFarmaceuticaController : ApiController
    {
        [HttpGet]
        [Route("GetAllCasasFarmaceuticas")]
        public IHttpActionResult GetAllCasasFarmaceuticas()
        {
            CasaFarmaceuticaService con = new CasaFarmaceuticaService();
            return Ok(con.GetAllCasasFarmaceuticas());
        }

        [HttpGet]
        [Route("GetAllNombresCasasFarmaceuticas")]
        public IHttpActionResult GetAllNombresCasasFarmaceuticas()
        {
            CasaFarmaceuticaService con = new CasaFarmaceuticaService();
            return Ok(con.GetAllNombresCasasFarmaceuticas());
        }

        [HttpGet]
        [Route("GetAllNombresCasasFarmaceuticasxMedicamento")]
        public IHttpActionResult GetAllNombresCasasFarmaceuticasxMedicamento(String nombre)
        {
            CasaFarmaceuticaService con = new CasaFarmaceuticaService();
            return Ok(con.GetAllNombresCasasFarmaceuticasxMedicamento(nombre));
        }
        

        [HttpGet]
        [Route("GetIdCasaFarmaceutica")]
        public IHttpActionResult GetIdCasaFarmaceutica(String nombre)
        {
            CasaFarmaceuticaService con = new CasaFarmaceuticaService();
            return Ok(con.GetIdCasaFarmaceutica(nombre));
        }

        [HttpPost]
        [Route("PostCasaFarmaceutica")]
        public void PostCasaFarmaceutica([FromBody] CasaFarmaceutica cFar)
        {
            CasaFarmaceuticaService con = new CasaFarmaceuticaService();
            con.PostCasaFarmaceutica(cFar);
        }
    }
}
