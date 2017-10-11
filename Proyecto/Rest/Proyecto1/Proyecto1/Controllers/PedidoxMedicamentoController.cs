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
    [RoutePrefix("api/PedidoxMedicamento")]
    public class PedidoxMedicamentoController : ApiController
    {
        [HttpGet]
        [Route("GetAllPedidosxMedicamentos")]
        public IHttpActionResult GetAllPedidosxMedicamentos()
        {
            PedidoxMedicamentoService con = new PedidoxMedicamentoService();
            return Ok(con.GetAllPedidosxMedicamentos());
        }
        [HttpGet]
        [Route("GetMedicamentosxPedido")]
        public IHttpActionResult GetMedicamentosxPedido(int id)
        {
            PedidoxMedicamentoService con = new PedidoxMedicamentoService();
            return Ok(con.GetMedicamentosxPedido(id));
        }
        [HttpGet]
        [Route("GetPrecioTotal")]
        public IHttpActionResult GetPrecioTotal(int id)
        {
            PedidoxMedicamentoService con = new PedidoxMedicamentoService();
            List<MedicamentosxPedido> l = con.GetMedicamentosxPedido(id);
            int total = 0;
            foreach (MedicamentosxPedido m in l) {
                total = total + m.Precio*m.Cantidad;
            }
            return Ok(total);
        }
        [HttpPost]
        [Route("PostPedidoxMedicamento")]
        public void PostMedicamento([FromBody] PedidoxMedicamento pedidoxMedicamento)
        {
            PedidoxMedicamentoService con = new PedidoxMedicamentoService();
            con.PostPedidoxMedicamento(pedidoxMedicamento);
        }
    }
}
