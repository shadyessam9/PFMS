using PFMS.Models;
using PFMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.Controllers.Sites
{
    public class EditsiteController : Controller
    {

        pfmsContext _entity = new pfmsContext();







        public ActionResult Index(int id)
        {

            TempData["id"]=id;

            ViewItem vi = new ViewItem()
            {
                site = _entity.Sites.FirstOrDefault(a => a.s_id == id)
            };

            return View(vi);
        }


        [HttpPost]
        public ActionResult Edit(Site s)
        {
              
            try
            {
                var id = TempData["id"];
                Site site = _entity.Sites.Single(a => a.s_id == (int?)id);
                site.avg_a_time = s.avg_a_time;
                _entity.SaveChanges();

                return Json(new { status = "success" });
            }


            catch (Exception)
            {
                return Json(new { status = "error" });
            }

        }


    }
}
