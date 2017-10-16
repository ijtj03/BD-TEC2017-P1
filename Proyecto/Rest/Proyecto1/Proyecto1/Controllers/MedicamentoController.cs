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
    [RoutePrefix("api/Medicamento")]
    public class MedicamentoController : ApiController
    {
        [HttpGet]
        [Route("GetAllMedicamentos")]
        public IHttpActionResult GetAllMedicamentos()
        {
            MedicamentoService con = new MedicamentoService();
            return Ok(con.GetAllMedicamentos());
        }

        [HttpPost]
        [Route("PostMedicamento")]
        public void PostMedicamento([FromBody] Medicamento medicamento)
        {
            MedicamentoService con = new MedicamentoService();
            con.PostMedicamento(medicamento);
        }

        [HttpGet]
        [Route("GetAllMedicamentosxRelacion")]
        public IHttpActionResult GetAllMedicamentosxRelacion(int id)
        {
            MedicamentoService con = new MedicamentoService();
            return Ok(con.GetAllMedicamentosxRelacion(id));
        }

        [HttpGet]
        [Route("GetMedicamentosxRelacion")]
        public IHttpActionResult GetMedicamentosxRelacion(int idm, int ids, int idc)
        {
            MedicamentoService con = new MedicamentoService();
            return Ok(con.GetMedicamentosxRelacion(idm,ids,idc));
        }

        /**[HttpGet]
        [Route("GetMedicamentoID")]
        public IHttpActionResult GetMedicamentoID(string nombre)
        {
            MedicamentoService con = new MedicamentoService();
            return Ok(con.GetMedicamentoID(nombre));
        }*/

        [HttpGet]
        [Route("GetLastMedicamentoId")]
        public IHttpActionResult GetLastMedicamentoId()
        {
            MedicamentoService con = new MedicamentoService();
            return Ok(con.GetLastMedicamentoId());
        }

        [HttpPut]
        [Route("PutLogicDelete")]
        public void DeleteMedicamento([FromBody] int id)
        {
            MedicamentoService con = new MedicamentoService();
            con.DeleteMedicamento(id);
        }


    }
}
