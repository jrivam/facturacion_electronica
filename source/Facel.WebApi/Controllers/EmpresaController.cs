using Facel.Business.Entities;
using Facel.Business.Logics;
using Facel.Filter.Entities;
using Facel.Filter.Logics;
using Library.Framework.Data;
using System;
using System.Net;
using System.Web.Http;

namespace Facel.WebApi.Controllers
{
    public class EmpresaController : ApiController
    {
        public IHttpActionResult Get(string search = "")
        {
            try
            {
                Empresa_FE be = new Empresa_FE();

                if (search != "")
                    be.RazonSocial = new Filter<string>(search, false, Operator.Like);

                var list = new Empresa_FL().LoadConvert(be);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Empresa_BE be = new Empresa_BE();
                be.Id = id;

                if (new Empresa_BL().Load(be) == 1)
                {
                    return Ok(be);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Empresa_BE parambe)
        {
            try
            {
                if (parambe == null)
                {
                    return BadRequest();
                }

                if (new Empresa_BL().Save(parambe, Library.Framework.Layers.SaveStatus.Complete) == 1)
                {
                    return Created<Empresa_BE>(Request.RequestUri + "/" + parambe.Id.ToString(), parambe);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]Empresa_BE parambe)
        {
            try
            {
                if (parambe == null)
                    return BadRequest();

                if (new Empresa_BL().Save(parambe, Library.Framework.Layers.SaveStatus.Complete) == 1)
                {
                    return Ok(parambe);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Empresa_BE be = new Empresa_BE();
                be.Id = id;

                if (new Empresa_BL().Load(be) == 1)
                {
                    new Empresa_BL().Erase(be);

                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

    }
}
