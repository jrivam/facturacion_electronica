using Facel.Business.Entities;
using Facel.Business.Logics;
using Facel.Filter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Facel.WebApi.Controllers
{
    public class DocumentosVentaController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            DocumentosVenta_BE be = new DocumentosVenta_BE();
            be.Id = id;

            new DocumentosVenta_BL().Load(be);

            return Ok(be);
        }
    }
}
