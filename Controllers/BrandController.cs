using Microsoft.AspNetCore.Mvc;
using System.Linq;
using vehicle_registration_app.Services;
namespace vehicle_registration_app.Controllers
{
    public class BrandController
    {
        private readonly BrandService _brandService;

        public BrandController(BrandService brandService)
        {
            _brandService = brandService;
        }
    }
}
