using FormsClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FormsClient.Controllers
{
    public class HomeController : Controller
    {
        private FormService service = new FormService();

        public async Task<ActionResult> Index()
        {

            return View("index",
                await service.GetFormAsync()
            );
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}