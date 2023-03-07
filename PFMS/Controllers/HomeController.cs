using PFMS.Models;
using PFMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.Controllers
{
    public class HomeController : Controller
    {

        pfmsContext _entity = new pfmsContext();


        string today = DateTime.Now.ToString("dd/MM/yyyy");


        int shft;
        string ship;


        public ActionResult dashboard()
        {
            ViewBag.today = today;
            return View();
        }

        public ActionResult meta()
        {

            shft = (from shf in _entity.Shifts select shf.c_shift).First();
            ship = (from shp in _entity.Ships select shp.name).First();
            return Json(new { shift = shft, ship = ship });
        }

        [HttpPost]
        public ActionResult updateship(string shp)
        {

            try
            {
                var shps = _entity.Ships.Single(a => a.id == 1);
                shps.name = shp;
                _entity.SaveChanges();
                return Json(new { status = "success" });
            }


            catch (Exception)
            {
                return Json(new { status = "error" });
            }
        }


        public ActionResult getScans()
        {


            var scans = (from scn in _entity.Scans
                         join veh in _entity.Vehicles on scn.vehicle equals veh.v_id
                         join sit in _entity.Sites on scn.site equals sit.s_id
                        // where scn.sc_date == today
                         select new dashboard1
                         {
                             v_id = veh.v_id,
                             V = veh.v_l1 + " " + veh.v_l2 + " " + veh.v_l3 + " - " + veh.v_number.ToString(),
                             driver = veh.driver,
                             site = sit.s_name,
                             state = scn.state,
                             time = (scn.time).ToString(),
                             trip_time = (scn.trip_time).ToString(),
                             type = scn.type,
                             delay = (scn.delay).ToString()
                         }).ToList().OrderByDescending(s => s.time);


            return Json(scans);
        }


        public ActionResult getViolations()
        {


            var vios = (from vio in _entity.Violations
                        join veh in _entity.Vehicles on vio.vehicle equals veh.v_id
                        join sit in _entity.Sites on vio.site equals sit.s_id
                      //  where vio.date == today
                      //  where vio.resolved == 0

                        select new dashboard2
                        {
                            vi_id = vio.vi_id,
                            V = veh.v_l1 + " " + veh.v_l2 + " " + veh.v_l3 + " - " + veh.v_number.ToString(),
                            time = (vio.time).ToString(),
                            site = sit.s_name,
                            cause = (vio.cause == "1" ? "تاخر" : "تخطي نقطه")
                        }).ToList().OrderByDescending(s => s.time);


            return Json(vios);
        }



        [HttpPost]
        public ActionResult viodata(int id)
        {


            var dat = from vio in _entity.Violations
                      join veh in _entity.Vehicles on vio.vehicle equals veh.v_id
                      join scn in _entity.Scans on vio.sc_id equals scn.sc_id
                      join sit in _entity.Sites on vio.site equals sit.s_id
                      where vio.vi_id == id
                     // where scn.sc_date == today

                      select new dashboard2
                      {
                          vi_id = vio.vi_id,
                          vh_id = veh.v_id,
                          V = veh.v_l1 + " " + veh.v_l2 + " " + veh.v_l3 + " - " + veh.v_number.ToString(),
                          site = sit.s_name,
                          cause = vio.cause,
                          trip_time = (scn.time).ToString(),
                          delay = (scn.delay).ToString()
                      };


            return Json(dat);
        }




        [HttpPost]
        public ActionResult reactivate(int vid, int vhid)
        {

            try
            {
                Violation vio = _entity.Violations.Single(a => a.vi_id == (int?)vid);
                vio.resolved = 1;
                Vehicle veh = _entity.Vehicles.Single(a => a.v_id == (int?)vhid);
                veh.state = 0;
                _entity.SaveChanges();

                return Json(new { status = "success" });
            }


            catch (Exception)
            {
                return Json(new { status = "error" });
            }
        }


        public ActionResult getVehicles()
        {


            var vehs = (from veh in _entity.Vehicles
                        where veh.r_date == today
                        select new dashboard3
                        {
                            v_id = veh.v_id,
                            V = veh.v_l1 + " " + veh.v_l2 + " " + veh.v_l3 + " - " + veh.v_number.ToString(),
                            driver = veh.driver,
                            state = veh.state
                        }).ToList();


            return Json(vehs);
        }


    }
}