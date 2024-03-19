using Microsoft.EntityFrameworkCore;
using vehicle_registration_app.AppDB;
using vehicle_registration_app.Models;

namespace vehicle_registration_app.Repositories
{
    public class BrandRepo(ApplicationDbContext context) : IBrandRepository
    {
        private readonly ApplicationDbContext? _context = context;

        public IEnumerable<Brand> GetAll()
        {
            return _context?.Brands?.ToList() ?? new List<Brand>();
        }

        public Brand GetById(int id)
        {
            return _context?.Brands?.Find(id) ?? throw new Exception("Brands collection or context is null.");
        }

        public void Add(Brand brand)
        {
            _context?.Brands?.Add(brand);
            _context?.SaveChanges();
        }

        public void Update(Brand brand)
        {
            var entry = _context?.Entry(brand);
            if (entry != null)
            {
                entry.State = EntityState.Modified;
                _context?.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var brand = _context?.Brands?.Find(id);
            _context?.Brands?.Remove(brand ?? throw new Exception("Brand not found."));
            _context?.SaveChanges();
        }

    }
}
