﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.DBModel
{
    public class SiteSocialLink : BaseEntity
    {
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}
