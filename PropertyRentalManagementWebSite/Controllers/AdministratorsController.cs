using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyRentalManagementWebSite.Models;

namespace PropertyRentalManagementWebSite.Controllers
{
    public class AdministratorsController : Controller
    {
        private readonly PropertyRentalManagementWebSiteDBContext _context;

        public AdministratorsController(PropertyRentalManagementWebSiteDBContext context)
        {
            _context = context;
        }


        // GET: Administrators
        public async Task<IActionResult> Welcome(string username, string password)
        {
            if (username != null && password != null && username.Equals("admin1") && password.Equals("111"))
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("password", password);
                return View(await _context.Administrators.ToListAsync());
            }
            else if (username != null && password != null && username.Equals("admin2") && password.Equals("222"))
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("password", password);
                return View(await _context.Administrators.ToListAsync());
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("../Home/Index");
            }
        }
        public async Task<IActionResult> Index()
        {

                return View(await _context.Administrators.ToListAsync());
        }
        // GET: Administrators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // GET: Administrators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,AdminUsername,AdminPassword")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrator);
        }

        // GET: Administrators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }
            return View(administrator);
        }

        // POST: Administrators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,AdminUsername,AdminPassword")] Administrator administrator)
        {
            if (id != administrator.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministratorExists(administrator.AdminId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(administrator);
        }

        // GET: Administrators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrator = await _context.Administrators.FindAsync(id);
            _context.Administrators.Remove(administrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministratorExists(int id)
        {
            return _context.Administrators.Any(e => e.AdminId == id);
        }
    }
}
