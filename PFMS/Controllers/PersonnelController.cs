using PFMS.Models;
using PFMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFMS.Controllers
{
    public class PersonnelController : Controller
    {

        pfmsContext _entity = new pfmsContext();

        public ActionResult Index()
        {
            var personssites = (from prs in _entity.Personnels
                                join sit in _entity.Sites on prs.site equals sit.s_id
                                select new Psl
                                {
                                    p_id = prs.p_id,
                                    type = prs.type,
                                    s_id = (int)sit.s_id,
                                    s_name = sit.s_name
                                }).OrderBy(s => s.s_name).ToList();




            var ViewModel = new ViewList()
            {
                psls = personssites

            };


            return View(ViewModel);
        }
    }
}