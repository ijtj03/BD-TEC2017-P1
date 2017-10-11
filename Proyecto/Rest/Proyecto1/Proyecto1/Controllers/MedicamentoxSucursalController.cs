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
    [RoutePrefix("api/MedicamentoxSucursal")]
    public class MedicamentoxSucursalController : ApiController
    {
        [HttpGet]
        [Route("GetAllMedicamentoxSucursal")]
        public IHttpActionResult GetAllMedicamentoxCasaFarmaceutica()
        {
            MedicamentoxSucursalService con = new MedicamentoxSucursalService();
            return Ok(con.GetAllMedicamentoxSucursal());
        }
        [HttpGet]
        [Route("GetMedicamentoxSucursal")]
        public IHttpActionResult GetMedicamentoxSucursal(int id)
        {
            MedicamentoxSucursalService con = new MedicamentoxSucursalService();
            return Ok(con.GetMedicamentoxSucursal(id));
        }
        [HttpPost]
        [Route("PostMedicamentoxSucursal")]
        public void PostMedicamento([FromBody] MedicamentoxSucursal mxs)
        {
            MedicamentoxSucursalService con = new MedicamentoxSucursalService();
            con.PostMedicamentoxSucursal(mxs);
        }
        [HttpPost]
        [Route("UpdateCantidad")]
        public void UpdateCantidad([FromBody] UpdateCantidad mxs)
        {
            MedicamentoxSucursalService con = new MedicamentoxSucursalService();
            con.UpdateCantidad(mxs);
        }
    }
}
