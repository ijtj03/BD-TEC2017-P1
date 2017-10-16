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
    [RoutePrefix("api/PersonaxSucursal")]
    public class PersonaxSucursalController : ApiController
    {

        [HttpGet]
        [Route("GetAllPersonaxSucursal")]
        public IHttpActionResult GetAllPersonaxSucursal()
        {
            PersonaxSucursalService con = new PersonaxSucursalService();
            return Ok(con.GetAllPersonasxSucursal());
        }

        [HttpPost]
        [Route("PostPersonaxSucursal")]
        public void PostMedicamento([FromBody] PersonaxSucursal pxs)
        {
            PersonaxSucursalService con = new PersonaxSucursalService();
            con.PostPersonaxSucursal(pxs);
        }

        [HttpPost]
        [Route("UpdatePersonaxSucursal")]
        public void UpdatePersonaxSucursal([FromBody]PersonaxSucursal pxs)
        {
            PersonaxSucursalService con = new PersonaxSucursalService();
            con.UpdatePersonaxSucursal(pxs);
        }

        [HttpGet]
        [Route("GetPersonaxSucursal")]
        public IHttpActionResult GetPersonaxSucursal(int id)
        {
            PersonaxSucursalService con = new PersonaxSucursalService();
            return Ok(con.GetPersonaxSucursal(id));
        }

        [HttpPut]
        [Route("PutLogicDelete")]
        public void DeletePersonaxSucursal([FromBody] int cedula)
        {
            PersonaxSucursalService con = new PersonaxSucursalService();
            con.DeletePersonaxSucursal(cedula);
        }
    }
}
