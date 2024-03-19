using System.Collections.Generic;
using vehicle_registration_app.Models;
using vehicle_registration_app.Repositories;
namespace vehicle_registration_app.Services
{
    public class BrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _brandRepository.GetAll();
        }

        public Brand GetBrandById(int id)
        {
            return _brandRepository.GetById(id);
        }

        public void AddBrand(Brand brand)
        {
            _brandRepository.Add(brand);
        }

        public void UpdateBrand(Brand brand)
        {
            _brandRepository.Update(brand);
        }

        public void DeleteBrand(int id)
        {
            _brandRepository.Delete(id);
        }
    }
}
