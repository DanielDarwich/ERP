using Microsoft.EntityFrameworkCore;
using ERP.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Data
{
    public class ERPDbContext : DbContext
    {
        public ERPDbContext(DbContextOptions<ERPDbContext> options)
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
