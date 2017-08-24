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
    public class SucursalController : ApiController
    {
        public IHttpActionResult Get(string search = "")
        {
            try
            {
                Sucursal_FE be = new Sucursal_FE();

                if (search != "")
                    be.Nombre = new Filter<string>(search, false, Operator.Like);

                var list = new Sucursal_FL().LoadConvert(be);

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
                Sucursal_BE be = new Sucursal_BE();
                be.Id = id;

                if (new Sucursal_BL().Load(be) == 1)
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
        public IHttpActionResult Post([FromBody]Sucursal_BE parambe)
        {
            try
            {
                if (parambe == null)
                {
                    return BadRequest();
                }

                if (new Sucursal_BL().Save(parambe, Library.Framework.Layers.SaveStatus.Complete) == 1)
                {
                    return Created<Sucursal_BE>(Request.RequestUri + "/" + parambe.Id.ToString(), parambe);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]Sucursal_BE parambe)
        {
            try
            {
                if (parambe == null)
                    return BadRequest();

                if (new Sucursal_BL().Save(parambe, Library.Framework.Layers.SaveStatus.Complete) == 1)
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
                Sucursal_BE be = new Sucursal_BE();
                be.Id = id;

                if (new Sucursal_BL().Load(be) == 1)
                {
                    new Sucursal_BL().Erase(be);

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
