using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LePoulailler.Controllers
{
    public class _BaseController : Controller
    {
        public MySqlConnection Connection { get; private set; }

        //private DOUser _CurrentUser;
        //public DOUser CurrentUser
        //{
        //    get
        //    {
        //        var serviceUser = new ServiceUser(Connection);
        //        var tmp = _CurrentUser ?? (_CurrentUser = serviceUser.GetDOUserById(Session != null && Session["userId"] != null ? (Int64)Session["userId"] : 2));//2 ==UserNobody
        //        Session["CurrentUser"] = tmp;
        //        return tmp;
        //    }

        //}

        public _BaseController()
        {
            string myConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionStringLocal"];

            Connection = new MySqlConnection(myConnectionString);
            Connection.Open();



            //Connection.Close();
        }

        //public bool HasPermController(string controlleur)
        //{
        //    switch (controlleur)
        //    {
        //        case "Core":
        //        case "Home":
        //        case "Calculateur":
        //        case "Stat":
        //            return CurrentUser.Rang == DOUser.enumRang.SuperAdmin || CurrentUser.Rang == DOUser.enumRang.Admin || CurrentUser.Rang == DOUser.enumRang.SimpleUser ? true : false;
        //        case "Item":
        //        case "Sort":
        //        case "Panoplie":
        //            return CurrentUser.Rang == DOUser.enumRang.SuperAdmin || CurrentUser.Rang == DOUser.enumRang.Admin ? true : false;
        //        case "User":
        //            return CurrentUser.Rang == DOUser.enumRang.SuperAdmin ? true : false;
        //        default:
        //            return false;
        //    }
        //}

        //public void ExecLogIn(long userId)
        //{
        //    Session["userId"] = userId;
        //    Session["CurrentUser"] = CurrentUser;
        //}

        //public void ExecLogOff()
        //{
        //    Session["userId"] = null;
        //    Session.RemoveAll();
        //}

    }
}