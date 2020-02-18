using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using miha.Models.activiti;

namespace miha.Models
{
    public class activityContext : DbContext
    {
        public activityContext (DbContextOptions<activityContext> options)
            : base(options)
        {
        }

        public DbSet<miha.Models.activiti.activity> activity { get; set; }
    }
}
