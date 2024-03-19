using Microsoft.EntityFrameworkCore;
using vehicle_registration_app.AppDB;
using vehicle_registration_app.Models;

namespace vehicle_registration_app.Repositories
{
    public class VehicleRepo(ApplicationDbContext context) : IVehicleRepository
    {
        private readonly ApplicationDbContext? _context = context;

        public IEnumerable<Vehicle> GetAll()
        {
            return _context?.Vehicles?.Include(v => v.Brand).ToList() ?? Enumerable.Empty<Vehicle>();
        }
    }
}
