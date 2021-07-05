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
    public class NewssController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NewssController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Newss.ToListAsync());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(NewsModels model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                News news = new News
                {
                    NewsTitle = model.NewsTitle,
                    NewsContent = model.NewsContent,
                    NewsImage = uniqueFileName
                };
                _dataContext.Add(news);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var news = await _dataContext.Newss.FindAsync(id);
            var newsModels = new NewsModels()
            {
                Id = news.NewsId,
                NewsTitle = news.NewsTitle,
                NewsContent = news.NewsContent,
                ExistingImage = news.NewsImage
            };
            if (news == null)
            {
                return NotFound();
            }
            return View(newsModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewsModels model)
        {
            if (ModelState.IsValid)
            {
                var news = await _dataContext.Newss.FindAsync(model.Id);
                news.NewsTitle = model.NewsTitle;
                news.NewsContent = model.NewsContent;
                if (model.ItemImage != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    news.NewsImage = ProcessUploadedFile(model);
                }
                _dataContext.Update(news);
                await _dataContext.SaveChangesAsync();
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
            var news = await _dataContext.Newss
                .FirstOrDefaultAsync(m => m.NewsId == id);
            var newsModels = new NewsModels()
            {
                Id = news.NewsId,
                NewsTitle = news.NewsTitle,
                NewsContent = news.NewsContent,
                ExistingImage = news.NewsImage
            };
            if (news == null)
            {
                return NotFound();
            }
            return View(newsModels);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _dataContext.Newss.FindAsync(id);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", news.NewsImage);
            _dataContext.Newss.Remove(news);
            if (await _dataContext.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private string ProcessUploadedFile(NewsModels model)
        {
            string uniqueFileName = null;
            if (model.ItemImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ItemImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ItemImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
