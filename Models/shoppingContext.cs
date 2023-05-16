using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class shoppingContext : DbContext
    {
        public shoppingContext(DbContextOptions<shoppingContext> options)
            : base(options)
        {

        }

        public DbSet<Shopping> Shoppings { get; set; }
    }
}
