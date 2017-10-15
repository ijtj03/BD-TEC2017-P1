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
        
        [HttpPost]
        [Route("DeletePedido")]
        public void DeletePedido([FromBody] Pedido pedido)
        {
            PedidoService con = new PedidoService();
            con.DeletePedido(pedido);
        }

        [HttpGet]
        [Route("GetPedidosSucursal")]
        public IHttpActionResult GetPedidosSucursal(int id)
        {
            PedidoService con = new PedidoService();
            return Ok(con.GetPedidosSucursal(id));

        }

        [HttpGet]
        [Route("GetPedidosSucursalPreparado")]
        public IHttpActionResult GetPedidoSucursalPreparado(int id)
        {
            PedidoService con = new PedidoService();
            return Ok(con.GetPedidosSucursalPreparado(id));

        }

        [HttpGet]
        [Route("GetPedidosSucursalRecogido")]
        public IHttpActionResult GetPedidosSucursalRecogido(int id)
        {
            PedidoService con = new PedidoService();
            return Ok(con.GetPedidosSucursalRecogido(id));

        }

        [HttpPost]
        [Route("PrepararPedido")]
        public void PrepararPedido(int id)
        {
            PedidoService con = new PedidoService();
            con.PrepararPedido(id);
        }

        [HttpPost]
        [Route("NoPrepararPedido")]
        public void NoPrepararPedido(int id)
        {
            PedidoService con = new PedidoService();
            con.NoPrepararPedido(id);
        }

        [HttpPost]
        [Route("RecogerPedido")]
        public void RecogerPedido(int id)
        {
            PedidoService con = new PedidoService();
            con.RecogerPedido(id);
        }

        [HttpPost]
        [Route("PostPedidoImage")]
        public void PostPedidoImage([FromBody] PedidoImage pedido)
        {
            PedidoService con = new PedidoService();
            con.PostPedidoImage(pedido);
        }

        [HttpGet]
        [Route("GetImagePedido")]
        public IHttpActionResult GetImagePedido()
        {
            PedidoService con = new PedidoService();
            return Ok(con.GetImagePedido());

        }
    }
}