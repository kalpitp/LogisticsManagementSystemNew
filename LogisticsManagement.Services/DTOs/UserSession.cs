﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.Services.DTOs
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string Role { get; set; }
    }
}
