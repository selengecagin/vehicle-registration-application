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
            return _context.Brands.ToList();
        }

        public Brand GetById(int id)
        {
            return _context.Brands.Find(id);
        }

        public void Add(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void Update(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var brand = _context.Brands.Find(id);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

    }
