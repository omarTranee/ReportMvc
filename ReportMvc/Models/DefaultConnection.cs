using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReportMvc.Models
{
    public class DefaultConnection:DbContext
    {
        public DbSet<Student> Students { get; set; }

    }
}