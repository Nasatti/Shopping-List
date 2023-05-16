using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class familyContext : DbContext
    {
        public familyContext(DbContextOptions<familyContext> options)
            : base(options)
        {

        }

        public DbSet<Family> Familys { get; set; }
    }
}
