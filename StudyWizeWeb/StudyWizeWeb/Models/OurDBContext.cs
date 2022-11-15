using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudyWizeWeb.Models
{
    public class OurDBContext : DbContext
    {
        public DbSet<StudentAccount> userAccount{ get; set; }
    }
}
