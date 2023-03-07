using PFMS.Models;
using PFMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.Controllers.Vehicles
{
    public class VehiclecompaniesController : Controller
    {

        pfmsContext _entity = new pfmsContext();

        public ActionResult Index()
        {
            var companies = (from cps in _entity.VehicleCompanies
                                select new vcs
                                {
                                    c_name = cps.c_name,
                                }).ToList();




            var ViewModel = new ViewList()
            {
                vcs = companies

            };



            return View(ViewModel);
        }


        [HttpPost]
        public ActionResult Add(VehicleCompany vc)
        {

            try
            {

                var existrecord = from cps in _entity.VehicleCompanies where vc.c_name == cps.c_name select cps;

                if (existrecord.Any()) { return Json(new { status = "Failed" }); }

                else
                {
                    _entity.VehicleCompanies.Add(vc);
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
