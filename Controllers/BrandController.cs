using Microsoft.AspNetCore.Mvc;
using System.Linq;
using vehicle_registration_app.Models;
using vehicle_registration_app.Services;
namespace vehicle_registration_app.Controllers
{
    public class BrandController : Controller
    {
        private readonly BrandService _brandService;

        public BrandController(BrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var brands = _brandService.GetAllBrands();
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.AddBrand(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        public IActionResult Edit(int id)
        {
            var brand = _brandService.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.UpdateBrand(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        public IActionResult Delete(int id)
        {
            _brandService.DeleteBrand(id);
            return RedirectToAction("Index");
        }
    }
}
