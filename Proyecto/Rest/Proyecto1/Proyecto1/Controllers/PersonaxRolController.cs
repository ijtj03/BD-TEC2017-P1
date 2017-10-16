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
    [RoutePrefix("api/PersonaxRol")]
    public class PersonaxRolController : ApiController
    {
        [HttpGet]
        [Route("GetAllPersonasxRoles")]
        public IHttpActionResult GetAllPersonas()
        {
            PersonaxRolService con = new PersonaxRolService();
            return Ok(con.GetAllPersonasxRol());
        }

        [HttpPost]
        [Route("PostPersonaxRol")]
        public void PostPersona([FromBody] PersonaxRol persona)
        {
            PersonaxRolService con = new PersonaxRolService();
            con.PostPersonaxRol(persona);
        }

        [HttpPost]
        [Route("UpdatePersonaxRol")]
        public void UpdatePersonaxRol([FromBody]PersonaxRol pxr)
        {
            PersonaxRolService con = new PersonaxRolService();
            con.UpdatePersonaxRol(pxr);
        }

        [HttpGet]
        [Route("GetPersonaxRol")]
        public IHttpActionResult GetPersonaxRol(int id)
        {
            PersonaxRolService con = new PersonaxRolService();
            return Ok(con.GetPersonaxRol(id));
        }

        [HttpGet]
        [Route("GetPersonaxRolId")]
        public IHttpActionResult GetPersonaxRolId(int cedula)
        {
            PersonaxRolService con = new PersonaxRolService();
            return Ok(con.GetPersonaxRolId(cedula));
        }

        [HttpPut]
        [Route("PutLogicDelete")]
        public void DeletePersonaxRol([FromBody] int cedula)
        {
            PersonaxRolService con = new PersonaxRolService();
            con.DeletePersonaxRol(cedula);
        }
    }
}
