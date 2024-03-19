using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using vehicle_registration_app.Models;

namespace vehicle_registration_app.AppDB
{
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }

}
