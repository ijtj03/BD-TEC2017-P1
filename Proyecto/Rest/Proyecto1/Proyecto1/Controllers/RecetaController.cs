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

    [RoutePrefix("api/Receta")]
    public class RecetaController : ApiController
    {
        [HttpGet]
        [Route("GetRecetasId")]
        public IHttpActionResult GetRecetasId(int id)
        {
            RecetaService con = new RecetaService();
            return Ok(con.GetRecetasId(id));
        }
        [HttpGet]
        [Route("GetLastId")]
        public IHttpActionResult GetLastId()
        {
            RecetaService con = new RecetaService();
            return Ok(con.GetLastId());
        }
        
        [HttpPost]
        [Route("PostReceta")]
        public void PostReceta([FromBody] Receta cFar)
        {
            RecetaService con = new RecetaService();
            con.PostReceta(cFar);
        }
        [HttpPost]
        [Route("DeleteReceta")]
        public void DeleteReceta([FromBody] Receta cFar)
        {
            RecetaService con = new RecetaService();
            con.DeleteReceta(cFar);
        }
    }
}
