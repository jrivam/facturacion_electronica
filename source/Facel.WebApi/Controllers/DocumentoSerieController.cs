using Facel.Business.Entities;
using Facel.Business.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Facel.WebApi.Controllers
{
    public class DocumentoSerieController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            DocumentoSerie_BE be = new DocumentoSerie_BE();
            be.Id = id;

            new DocumentoSerie_BL().Load(be);

            return Ok(be);
        }
    }
}
