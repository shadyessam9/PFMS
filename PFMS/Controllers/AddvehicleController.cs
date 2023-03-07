using PFMS.Models;
using PFMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PFMS.Controllers.Vehicles
{
    public class AddvehicleController : Controller
    {

        pfmsContext _entity = new pfmsContext();




        string today = DateTime.Now.ToString("dd/MM/yyyy");

        public ActionResult Index()
        {

            var compns = (from cmps in _entity.VehicleCompanies select new vcs { c_id = cmps.c_id, c_name = cmps.c_name }).ToList();

            var ViewModel = new ViewList()
            {
                vcs = compns

            };

            return View(ViewModel);
        }


        [HttpPost]
        public ActionResult Add(Vehicle v)
        {

            Random rnd = new Random();

            string id = rnd.Next(10000000, 99999999).ToString();

            int iid = int.Parse(DateTime.Now.ToString("dMy") + id.Substring(0, 3));

            try
            {

                var existrecord = from vhs in _entity.Vehicles where vhs.v_l1 == v.v_l1 && vhs.v_l2 == v.v_l2 && vhs.v_l3 == v.v_l3 && vhs.v_number == v.v_number && vhs.r_date == today select vhs;

                if (existrecord.Any()) { return Json(new { status = "Failed" }); }

                else
                {
                    v.v_id = iid;
                    _entity.Vehicles.Add(v);
                    _entity.SaveChanges();
                    return Json(new { status = "success", id = iid, v = v.v_number + "-" + v.v_l3 + " " + v.v_l2 + " " + v.v_l1 });
                }
            }


            catch (Exception)
            {
                return Json(new { status = "error" });
            }


        }
    }
}
