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
    [RoutePrefix("api/Sucursal")]
    public class SucursalController : ApiController
    {
        [HttpGet]
        [Route("GetAllSucursales")]
        public IHttpActionResult GetAllSucursales()
        {
            SucursalService con = new SucursalService();
            return Ok(con.GetAllSucursales());
        }

        [HttpGet]
        [Route("GetSucursal")]
        public IHttpActionResult GetSucursal(int IdSucursal)
        {
            SucursalService con = new SucursalService();
            return Ok(con.GetSucursal(IdSucursal));
        }

        [HttpGet]
        [Route("GetLastSucursalId")]
        public IHttpActionResult GetLastSucursalId()
        {
            SucursalService con = new SucursalService();
            return Ok(con.GetLastSucursalId());
        }

        [HttpGet]
        [Route("GetAllNombreSucursales")]
        public IHttpActionResult GetAllNombreSucursales(int id)
        {
            SucursalService con = new SucursalService();
            return Ok(con.GetAllNombreSucursales(id));
        }

        [HttpGet]
        [Route("GetIdSucursal")]
        public IHttpActionResult GetIdSucursal(String nombre)
        {
            SucursalService con = new SucursalService();
            return Ok(con.GetIdSucursal(nombre));
        }
         
        [HttpPost]
        [Route("PostSucursal")]
        public void PostSucursal([FromBody] Sucursal sucursal)
        {
            SucursalService con = new SucursalService();
            con.PostSucursal(sucursal);
        }

        [HttpPost]
        [Route("UpdateSucursal")]
        public void UpdateSucursal([FromBody] Sucursal sucursal)
        {
            SucursalService con = new SucursalService();
            con.UpdateSucursal(sucursal);
        }

        [HttpPut]
        [Route("PutLogicDelete")]
        public void DeleteSucursal([FromBody] int IdSucursal)
        {
            SucursalService con = new SucursalService();
            con.DeleteSucursal(IdSucursal);
        }
    }
}
