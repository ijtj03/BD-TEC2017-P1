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
    [RoutePrefix("api/Persona")]
    public class PersonaController : ApiController
    {
        [HttpGet]
        [Route("GetAllPersonas")]
        public IHttpActionResult GetAllPersonas()
        {
            PersonaService con = new PersonaService();
            return Ok(con.GetAllPersonas());
        }

        [HttpGet]
        [Route("GetPersona")]
        public IHttpActionResult GetPersona(int id)
        {
            PersonaService con = new PersonaService();
            return Ok(con.GetPersona(id));
        }

        [HttpPost]
        [Route("PostPersona")]
        public void PostPersona([FromBody] Persona persona)
        {
            PersonaService con = new PersonaService();
            con.PostPersona(persona);
        }

        [HttpPut]
        [Route("PutLogicDelete")]
        public void DeletePersona([FromBody] int cedula)
        {
            PersonaService con = new PersonaService();
            con.DeletePersona(cedula);
        }


        [HttpGet]
        [Route("SignInVerification")]
        public IHttpActionResult SignInVerification(int id, string contraseña)
        {
            PersonaService con = new PersonaService();
            return Ok(con.SignInVerification(id,contraseña)); 
        }


    }
}
