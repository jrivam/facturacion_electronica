using Facel.Business.Entities;
using Facel.Business.Logics;
using Facel.Filter.Entities;
using Facel.Filter.Logics;
using Facel.Mvc.WebClient.Helpers;
using Marvin.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Facel.Mvc.Controllers
{
    public class SucursalController : Controller
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                var client = MvcHttpClient.GetClient();

                var response = await client.GetAsync("api/sucursal");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    var list = JsonConvert.DeserializeObject<IEnumerable<Sucursal_BE>>(content);

                    return View(list);
                }
                else
                {
                    return Content("An error occurred");
                }
            }
            catch (Exception ex)
            {
                return Content("An error occurred");
            }
        }

        public ActionResult Create(int IdEmpresa)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Sucursal_BE parambe)
        {
            try
            {
                var client = MvcHttpClient.GetClient();

                var serialized = JsonConvert.SerializeObject(parambe);

                var response = await client.PostAsync("api/Sucursal", new StringContent(serialized, System.Text.Encoding.Unicode, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Details", "Sucursal", new { id = parambe.Id });
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("An error occurred");
                }
            }
            catch (Exception ex)
            {
                return Content("An error occurred");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var client = MvcHttpClient.GetClient();

                HttpResponseMessage response = await client.GetAsync("api/Sucursal/" + id);

                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var model = JsonConvert.DeserializeObject<Sucursal_BE>(content);
                    return View(model);
                }

                return Content("An error occurred: " + content);
            }
            catch (Exception ex)
            {
                return Content("An error occurred");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Sucursal_BE parambe)
        {
            try
            {
                var client = MvcHttpClient.GetClient();

                var serialized = JsonConvert.SerializeObject(parambe);

                var response = await client.PutAsync("api/sucursal/" + id, new StringContent(serialized, System.Text.Encoding.Unicode, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Details", "Sucursal", new { id = parambe.Id });
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("An error occurred");
                }
            }
            catch (Exception ex)
            {
                return Content("An error occurred");
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var client = MvcHttpClient.GetClient();

                var response = await client.DeleteAsync("api/Sucursal/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("An error occurred");
                }
            }
            catch (Exception ex)
            {
                return Content("An error occurred");
            }
        }
    }
}