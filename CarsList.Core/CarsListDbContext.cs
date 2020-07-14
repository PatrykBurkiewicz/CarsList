using CarsList.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsList.Core
{
    public class CarsListDbContext : DbContext
    {
        public CarsListDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
    }
}
