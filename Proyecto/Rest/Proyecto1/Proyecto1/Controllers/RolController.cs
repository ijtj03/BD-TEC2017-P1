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
    [RoutePrefix("api/Rol")]
    public class RolController : ApiController
    {

        [HttpGet]
        [Route("GetAllRol")]
        public IHttpActionResult GetAllRoles()
        {
            RolService con = new RolService();
            return Ok(con.GetAllRoles());
        }

        [HttpPost]
        [Route("PostRol")]
        public void PostMedicamento([FromBody] Rol rol)
        {
            RolService con = new RolService();
            con.PostRol(rol);
        }

    }
}
