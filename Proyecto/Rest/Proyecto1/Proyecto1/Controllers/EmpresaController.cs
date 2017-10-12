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
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : ApiController
    {
        [HttpGet]
        [Route("GetAllEmpresas")]
        public IHttpActionResult GetAllSucursales()
        {
            EmpresaService con = new EmpresaService();
            return Ok(con.GetAllEmpresas());
        }
        [HttpPost]
        [Route("PostEmpresa")]
        public void PostSucursal([FromBody] Empresa empresa)
        {
            EmpresaService con = new EmpresaService();
            con.PostEmpresa(empresa);
        }
    }
}
