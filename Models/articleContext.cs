using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class articleContext : DbContext
    {
        public articleContext(DbContextOptions<articleContext> options)
            : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
    }
}
