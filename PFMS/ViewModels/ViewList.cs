using PFMS.Models;
using System;
using System.Collections.Generic;

namespace PFMS.ViewModels

{
    public class ViewList 
    {

        public List<dashboard1> scans { get; set; }


        public List<site> sits { get; set; }


        public List<vcs> vcs { get; set; }


        public List<Psl> psls { get; set; }

    }
}
