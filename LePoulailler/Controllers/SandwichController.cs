using DALSandwich;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LePoulailler.Controllers
{
    public class SandwichController : _BaseController
    {
        // GET: Sandwich
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edition()
        {
            return View();
        }

        public ActionResult GetInfoGrid() {
            var erroMessageList = new List<string>();

            var SandwichsList = new List<DOSandwich>();

            try
            {
                var serviceSandwich = new ServiceSandwich(Connection);

                SandwichsList = serviceSandwich.GetAllSandwich().Values.ToList();
            }
            catch (Exception e) {
                erroMessageList.Add(e.Message);
            }


            return Json(new { erroMessageList, SandwichsList });
        }
    }
}