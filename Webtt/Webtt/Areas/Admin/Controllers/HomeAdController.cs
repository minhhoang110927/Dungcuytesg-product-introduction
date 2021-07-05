using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webtt.Data;
using Webtt.Models;

namespace Webtt.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdController : Controller
    {
        private readonly DataContext _dataContext;
        public HomeAdController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }
        }
        public async Task<IActionResult> ViewRecord()
        {
            return View(await _dataContext.Contacts.ToListAsync());
        }
        public async Task<IActionResult> DeleteRecord(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = await _dataContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost, ActionName("DeleteRecord")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _dataContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return RedirectToAction(nameof(ViewRecord));
            }

            try
            {
                _dataContext.Contacts.Remove(contact);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(ViewRecord));
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(DeleteRecord), new { id = id, saveChangesError = true });
            }
        }
    }
}
