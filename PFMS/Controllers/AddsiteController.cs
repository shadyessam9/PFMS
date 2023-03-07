using PFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.Controllers
{
    public class AddsiteController : Controller
    {


        pfmsContext _entity = new pfmsContext();


        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Add(Site s)
        {

            try
            {

                var existrecord = from sts in _entity.Sites where sts.s_name == s.s_name select sts;

                if (existrecord.Any()) { return Json(new { status = "Failed" }); }

                else
                {
                    _entity.Sites.Add(s);
                    _entity.SaveChanges();
                    return Json(new { status = "success" });
                }
            }


            catch (Exception)
            {
                return Json(new { status = "error" });
            }

        }
    }
}