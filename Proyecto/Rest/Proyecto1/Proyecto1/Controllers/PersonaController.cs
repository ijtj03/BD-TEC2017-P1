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
        [Route("UpdatePersona")]
        public void UpdatePersona([FromBody]Persona persona)
        {
            PersonaService con = new PersonaService();
            con.UpdatePersona(persona);
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

        [HttpPost]
        [Route("DeletePersona")]
        public void DeletePersona([FromBody] Persona persona)
        {
            PersonaService con = new PersonaService();
            con.BorrarPersona(persona);
        }

        [HttpGet]
        [Route("SignInVerification")]
        public IHttpActionResult SignInVerification(int id, string contraseña)
        {
            PersonaService con = new PersonaService();
            return Ok(con.SignInVerification(id,contraseña)); 
        }

        [HttpGet]
        [Route("SignInSucursalVerification")]
        public IHttpActionResult SignInSucursalVerification(int id, string contraseña)
        {
            PersonaService con = new PersonaService();
            return Ok(con.SignInSucursalVerification(id, contraseña));
        }

        [HttpGet]
        [Route("SignInAdministradorVerification")]
        public IHttpActionResult SignInAdministradorVerification(int id, string contraseña)
        {
            PersonaService con = new PersonaService();
            return Ok(con.SignInAdministradorVerification(id, contraseña));
        }

        [HttpGet]
        [Route("GetSucursalPersona")]
        public IHttpActionResult GetSucursalPersona(int id)
        {
            PersonaService con = new PersonaService();
            return Ok(con.GetSucursalPersona(id));
        }


    }
}
