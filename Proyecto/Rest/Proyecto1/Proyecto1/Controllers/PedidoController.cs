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
    [RoutePrefix("api/Pedido")]
    public class PedidoController : ApiController
    {
        [HttpGet]
        [Route("GetAllPedidos")]
        public IHttpActionResult GetAllPedidos()
        {
            PedidoService con = new PedidoService();
            return Ok(con.GetAllPedidos());
        }
        [HttpGet]
        [Route("GetLastPedidoId")]
        public IHttpActionResult GetLastPedidoId()
        {
            PedidoService con = new PedidoService();
            return Ok(con.GetLastPedidoId());
        }

        [HttpPost]
        [Route("PostPedido")]
        public void PostMedicamento([FromBody] Pedido pedido)
        {
            PedidoService con = new PedidoService();
            con.PostPedido(pedido);
        }
        [HttpGet]
        [Route("GetPedidos")]
        public IHttpActionResult GetPedidos(int id)
        {
            PedidoService con = new PedidoService();
            return Ok(con.GetPedidos(id));
        }
    }
}