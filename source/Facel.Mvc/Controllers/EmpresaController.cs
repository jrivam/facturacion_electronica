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
    public class EmpresaController : Controller
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                var client = MvcHttpClient.GetClient();

                var response = await client.GetAsync("api/empresa");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    var list = JsonConvert.DeserializeObject<IEnumerable<Empresa_BE>>(content);

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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Empresa_BE parambe)
        {
            try
            {
                var client = MvcHttpClient.GetClient();

                var serialized = JsonConvert.SerializeObject(parambe);

                var response = await client.PostAsync("api/empresa", new StringContent(serialized, System.Text.Encoding.Unicode, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Details", "Empresa", new { id = parambe.Id });
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

                HttpResponseMessage response = await client.GetAsync("api/empresa/" + id);

                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var model = JsonConvert.DeserializeObject<Empresa_BE>(content);
                    model.Sucursales_Load();

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
        public async Task<ActionResult> Edit(int id, Empresa_BE parambe)
        {
            try
            {
                var client = MvcHttpClient.GetClient();

                var serialized = JsonConvert.SerializeObject(parambe);

                var response = await client.PutAsync("api/empresa/" + id, new StringContent(serialized, System.Text.Encoding.Unicode, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Details", "Empresa", new { id = parambe.Id });
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

                var response = await client.DeleteAsync("api/empresa/" + id);

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