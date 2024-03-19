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

        public Vehicle GetById(int id)
        {
            return _context?.Vehicles?.Include(v => v.Brand).FirstOrDefault(v => v.Id == id)
                   ?? throw new Exception("Vehicle not found.");
        }

        public void Add(Vehicle vehicle)
        {
            _context?.Vehicles?.Add(vehicle);
            _context?.SaveChanges();
        }

        public void Update(Vehicle vehicle)
        {
            var entry = _context?.Entry(vehicle);
            if (entry != null)
            {
                entry.State = EntityState.Modified;
                _context?.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            var vehicle = _context?.Vehicles?.Find(id);
            if (vehicle != null)
            {
                _context?.Vehicles?.Remove(vehicle);
                _context?.SaveChanges();
            }
            else
            {
                // Optionally handle the case where the vehicle with the specified ID is not found
                throw new Exception($"Vehicle with ID {id} not found.");
            }
        }




    }
}
