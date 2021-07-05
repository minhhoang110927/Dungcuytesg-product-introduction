using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webtt.Data;
using Webtt.Models;

namespace Webtt.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dataContext = dataContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Products.ToListAsync());
        }
        
        public void CategoryList(object selectCategory)
        {
            ViewBag.Categories = new SelectList(dataContext.Categories, "CategoryId", "CategoryName", selectCategory);
        }
        public IActionResult Add()
        {
            CategoryList(null);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductModels model)
        {
            CategoryList(null);
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Product product = new Product
                {
                    ProductName = model.ProductName,
                    ProductImage = uniqueFileName,
                    Description = model.Description,
                    ProductPrice = model.ProductPrice,
                    CategoryId = model.CategoryId
                };
                dataContext.Add(product);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        private string ProcessUploadedFile(ProductModels model)
        {
            string uniqueFileName = null;
            if (model.ItemImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ItemImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ItemImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await dataContext.Products.FindAsync(id);
            var productModel = new ProductModels()
            {
                Id = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Description = product.Description,
                ExistingImage = product.ProductImage,
                CategoryId = product.CategoryId
            };
            CategoryList(product.CategoryId);
            if (product == null)
            {
                return NotFound();
            }
            return View(productModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductModels model)
        {
            if (ModelState.IsValid)
            {
                var product = await dataContext.Products.FindAsync(model.Id);
                product.ProductName = model.ProductName;
                product.Description = model.Description;
                product.ProductPrice = model.ProductPrice;
                product.CategoryId = model.CategoryId;
                if (model.ItemImage != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "img", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }
                    product.ProductImage = ProcessUploadedFile(model);
                }
                dataContext.Update(product);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await dataContext.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            ViewBag.CategoryName = dataContext.Categories.FirstOrDefault(p => p.CategoryId == product.CategoryId).CategoryName;
            var productModel = new ProductModels()
            {
                Id = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                ExistingImage = product.ProductImage,
                CategoryId = product.CategoryId
            };
            if (product == null)
            {
                return NotFound();
            }
            return View(productModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await dataContext.Products.FindAsync(id);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", product.ProductImage);
            dataContext.Products.Remove(product);
            if (await dataContext.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
