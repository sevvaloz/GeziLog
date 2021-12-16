﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeziLog.Models.Classes
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}