﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class tblSystemUsers
    {
        public string metod { get; set; } = null!;
        public string operation { get; set; } = null!;
        public string message { get; set; } = null!;
        public List<tblSystemUsersData> tblSystemUsersData { get; set; } = new List<tblSystemUsersData>();
    }

    public class tblSystemUsersData 
    {
        public string IdSystemUsers { get; set; } = null!;
        public string IdSUserProfile { get; set; } = null!;
        public string SystemUsers { get; set; } = null!;
        public string SystemUsersPass { get; set; } = null!;
        public string SitSystemUsers { get; set; } = null!;
    }
}
