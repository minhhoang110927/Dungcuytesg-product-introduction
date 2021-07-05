using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webtt.Models;
using Webtt.Data;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Webtt.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class AccountManage : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountManage(DataContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return View(user);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, User applicationUser)
        {
            var user = await _context.Users.FindAsync(id);
            user.FullName = applicationUser.FullName;
            user.UserName = applicationUser.Email;
            user.Email = applicationUser.Email;
            user.NormalizedUserName = applicationUser.Email;
            user.NormalizedEmail = applicationUser.Email;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOSTAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult changePassword()
        {
            return View();
        }
        [HttpPost, ActionName("changePassword")]
        public async Task<IActionResult> changePassword(changePasswordModel model)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user1 = await _userManager.FindByIdAsync(userid);
            if (model.oldPassword != null)
            {
                var valid = await new PasswordValidator<User>().ValidateAsync(_userManager, user1, model.oldPassword);
                if (!valid.Succeeded)
                {
                    ModelState.TryAddModelError("ChangePassword", "Mật khẩu cũ sai");
                    return View(model);
                }
                var result = await _userManager.ChangePasswordAsync(user1, model.oldPassword, model.newPassword);
            }
            await _signInManager.RefreshSignInAsync(user1);
            return RedirectToAction(nameof(HomeAdController.Index));
        }

    }
}
