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
    [RoutePrefix("api/Enfermedad")]
    public class EnfermedadController : ApiController
    {
        [HttpGet]
        [Route("GetAllEnfermedades")]
        public IHttpActionResult GetAllEnfermedad()
        {
            EnfermedadService con = new EnfermedadService();
            return Ok(con.GetAllEnfermedades());
        }
        [HttpGet]
        [Route("GetLastId")]
        public IHttpActionResult GetLastId()
        {
            EnfermedadService con = new EnfermedadService();
            return Ok(con.GetLastId());
        }
        [HttpPost]
        [Route("PostEnfermedad")]
        public void PostPersona([FromBody] Enfermedad enfermedad)
        {
            EnfermedadService con = new EnfermedadService();
            con.PostEnfermedad(enfermedad);
        }
    }
}
