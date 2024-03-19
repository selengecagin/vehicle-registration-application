using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using vehicle_registration_app.Models;
using vehicle_registration_app.Services;
namespace vehicle_registration_app.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;
        private readonly BrandService _brandService;

        public VehicleController(VehicleService vehicleService, BrandService brandService)
        {
            _vehicleService = vehicleService;
            _brandService = brandService;
        }


        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetAllVehicles();
            return View(vehicles);
        }
        public IActionResult Create()
        {
            ViewBag.Brands = _brandService.GetAllBrands().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name });
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.AddVehicle(vehicle);
                return RedirectToAction("Index");
            }
            ViewBag.Brands = _brandService.GetAllBrands().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name });
            return View(vehicle);
        }

        public IActionResult Edit(int id)
        {
            var vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewBag.Brands = _brandService.GetAllBrands().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name });
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.UpdateVehicle(vehicle);
                return RedirectToAction("Index");
            }
            ViewBag.Brands = _brandService.GetAllBrands().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name });
            return View(vehicle);
        }

        public IActionResult Delete(int id)
        {
            _vehicleService.DeleteVehicle(id);
            return RedirectToAction("Index");
        }

    }
}
