using PFMS.Models;
using PFMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace PFMS.Controllers.Sites
{
    public class SitelistController : Controller
    {

        pfmsContext _entity = new pfmsContext();


        public ActionResult Index()
        {
             var sites = (from sit in _entity.Sites select new site { s_id = sit.s_id, s_name = sit.s_name, avg_a_time = sit.avg_a_time, type = sit.type}).ToList();


            var ViewModel = new ViewList()
            {
               sits=sites,

            };


            return View(ViewModel);
        }



        [HttpPost]
        public ActionResult delete(int id)
        {

            try
            {
                _entity.Entry(_entity.Sites.Single(a => a.s_id == id)).State = EntityState.Deleted;
                _entity.SaveChanges();
                return Json(new { status = "success" });
            }
            catch(Exception)
            {
                return Json(new { status = "error" });
            }

        }


    }
}
