using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using UploadImages.Data;
using UploadImages.ViewModels;

namespace UploadImages.Controllers
{
    public class ProductController : Controller
    {

        private readonly UploadImagesContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(UploadImagesContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ProductOverviewViewModel viewmodel = new ProductOverviewViewModel();
            viewmodel.Producten = _context.Producten.ToList();
            return View(viewmodel);
        }

        public IActionResult Details(int? id)
        {
            ProductDetailsViewModel viewmodel = new ProductDetailsViewModel();

            if (id == null)
            {
                return NotFound();
            }

            viewmodel.Product = _context.Producten.FirstOrDefault(m => m.ProductID == id);

            if (viewmodel.Product == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }


        public IActionResult Create()
        {
            CreateProductViewModel viewmodel = new CreateProductViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(viewmodel.Afbeelding.FileName);
                string fileExtension = Path.GetExtension(viewmodel.Afbeelding.FileName);
                viewmodel.Product.Bestandsnaam = fileName + fileExtension;

                string fullPath = Path.Combine(webRootPath + "/Images/", viewmodel.Product.Bestandsnaam);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await viewmodel.Afbeelding.CopyToAsync(fileStream);
                }

                _context.Add(viewmodel.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewmodel);
        }

    }
}
