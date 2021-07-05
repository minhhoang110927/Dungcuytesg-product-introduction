using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Webtt.Data;
using Webtt.Models;

namespace Webtt.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext dataContext;
        public HomeController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = dataContext.Categories.ToList();
            ViewBag.ProductList = dataContext.Products.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendRecord(Contact contact, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ModelState.TryAddModelError("Contact", "Error");
                TempData["Error"] = "Vui lòng nhập đủ thông tin";
                return Redirect(returnUrl);
            }
            dataContext.Add(contact);
            await dataContext.SaveChangesAsync();
            return Redirect(returnUrl);
        }
        [HttpGet("CategoryProduct/{name}")]
        public IActionResult CategoryProduct(int id)
        {
            ViewBag.categoryName = dataContext.Categories.FirstOrDefault(p => p.CategoryId == id).CategoryName;
            return View(dataContext.Products.Where(p => p.CategoryId == id).ToList());
        }
        public IActionResult Search(string search)
        {
            List<Product> item = new List<Product>();
            if (search != null)
            { 
                if (item.Count() == 0)
                    ViewBag.message = "Không có kết quả tìm kiếm nào cho từ khóa '" + search+"'";
                item = dataContext.Products.Where(p => p.ProductName.ToLower().Contains(search.ToLower())).ToList();
                ViewBag.message = "Có " + item.Count()+ " kết quả tìm kiếm cho từ khóa '"+ search+"'";
            }
           
            return View(item);
        }
        public IActionResult AllProduct()
        {
            return View(dataContext.Products.ToList());
        }
        public IActionResult News()
        {
            return View(dataContext.Newss.ToList());
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
