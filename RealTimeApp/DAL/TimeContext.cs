using RealTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealTimeApp.DAL
{
    public class TimeContext:DbContext
    {

        public TimeContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Month> Months { set; get; }
    }
}