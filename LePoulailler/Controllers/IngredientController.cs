using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LePoulailler.Controllers
{
    public class IngredientController : _BaseController
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edition()
        {
            return PartialView();
        }
    }
}