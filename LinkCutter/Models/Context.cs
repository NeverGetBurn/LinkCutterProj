using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter.Models
{
    public class Context : DbContext
    {
        public DbSet<Link> Links { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
