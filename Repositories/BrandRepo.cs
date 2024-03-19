using vehicle_registration_app.AppDB;
using vehicle_registration_app.Models;

namespace vehicle_registration_app.Repositories
{
    public class BrandRepo : IBrandRepository
    {
        private readonly ApplicationDbContext? _context;

        public IEnumerable<Brand> GetAll()
        {
            return _context.Brands.ToList();



        }
    }
