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

        [HttpGet]
        [Route("GetAllEnfermedadesN")]
        public IHttpActionResult GetAllEnfermedadesN()
        {
            EnfermedadService con = new EnfermedadService();
            return Ok(con.GetAllEnfermedadesN());
        }

        [HttpGet]
        [Route("GetIdEnfermedad")]
        public IHttpActionResult GetIdEnfermedad(string nombre)
        {
            EnfermedadService con = new EnfermedadService();
            return Ok(con.GetIdEnfermedad(nombre));
        }

        [HttpGet]
        [Route("GetAllEnfermedadadesxUsuario")]
        public IHttpActionResult GetAllEnfermedadesxUsuario(int id)
        {
            EnfermedadService con = new EnfermedadService();
            return Ok(con.GetAllEnfermedadesxUsuario(id));
        }

        [HttpGet]
        [Route("GetEnfermedadesxUsuarioId")]
        public IHttpActionResult GetEnfermedadesxUsuarioId(int cedula)
        {
            EnfermedadService con = new EnfermedadService();
            return Ok(con.GetEnfermedadesxUsuarioId(cedula));
        }

        [HttpPut]
        [Route("PutLogicDelete")]
        public void DeleteEnfermedad(int id, int cedula)
        {
            EnfermedadService con = new EnfermedadService();
            con.DeleteEnfermedad(id, cedula);
        }
    }
}
