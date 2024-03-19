using vehicle_registration_app.Models;

namespace vehicle_registration_app.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        Brand GetById(int id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(int id);
    }
}
