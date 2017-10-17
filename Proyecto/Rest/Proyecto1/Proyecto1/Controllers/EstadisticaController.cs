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
    [RoutePrefix("api/Estadistica")]
    public class EstadisticaController : ApiController
    {
        [HttpGet]
        [Route("GetAllProductosVendidos")]
        public IHttpActionResult GetAllProductosVendidos()
        {
            EstadisticaService con = new EstadisticaService();
            return Ok(con.GetAllProductosVendidos());
        }
        [HttpGet]
        [Route("GetAllProductosVendidosxCompania")]
        public IHttpActionResult GetAllProductosVendidosxCompania(int id)
        {
            EstadisticaService con = new EstadisticaService();
            return Ok(con.GetAllProductosVendidosxCompania(id));
        }

        [HttpGet]
        [Route("GetAllEmpresasxVentas")]
        public IHttpActionResult GetAllEmpresasxVentas()
        {
            EstadisticaService con = new EstadisticaService();
            return Ok(con.GetAllEmpresasxVentas());
        }
    }
}
