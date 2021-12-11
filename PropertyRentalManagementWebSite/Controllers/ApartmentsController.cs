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
    public class ApartmentsController : Controller
    {
        private readonly PropertyRentalManagementWebSiteDBContext _context;

        public ApartmentsController(PropertyRentalManagementWebSiteDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> WelcomeManager(string username1, string password1)
        {
            if (username1 != null && password1 != null && username1.Equals("manager1") && password1.Equals("111"))
            {
                HttpContext.Session.SetString("username1", username1);
                HttpContext.Session.SetString("password1", password1);
                return View(await _context.Apartments.ToListAsync());
            }
            else if (username1 != null && password1 != null && username1.Equals("manager2") && password1.Equals("222"))
            {
                HttpContext.Session.SetString("username1", username1);
                HttpContext.Session.SetString("password1", password1);
                return View(await _context.Apartments.ToListAsync());
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("../Home/loginAsManager");
            }
        }

        public async Task<IActionResult> WelcomeTenant(string username, string password)
        {
            if (username != null && password != null && username.Equals("test1") && password.Equals("test1"))
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("password", password);
                return View(await _context.Apartments.ToListAsync());
            }
            if (username != null && password != null && username.Equals("test2") && password.Equals("test2"))
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("password", password);
                return View(await _context.Apartments.ToListAsync());
            }
            if (username != null && password != null && username.Equals("test3") && password.Equals("test3"))
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("password", password);
                return View(await _context.Apartments.ToListAsync());
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("../Home/loginAsTenant");
            }
        }
        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apartments.ToListAsync());
        }

        public async Task<IActionResult> IndexForManager()
        {
            return View(await _context.Apartments.ToListAsync());
        }
        public async Task<IActionResult> IndexForTenant()
        {
            return View(await _context.Apartments.ToListAsync());
        }
        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }
        public async Task<IActionResult> DetailsForManager(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateForManager()
        {
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApartmentId,ApartmentType,ApartmentPrice,ApartmentAddress")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apartment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForManager([Bind("ApartmentId,ApartmentType,ApartmentPrice,ApartmentAddress")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexForManager));
            }
            return View(apartment);
        }
        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }
        public async Task<IActionResult> EditForManager(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApartmentId,ApartmentType,ApartmentPrice,ApartmentAddress")] Apartment apartment)
        {
            if (id != apartment.ApartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.ApartmentId))
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
            return View(apartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditForManager(int id, [Bind("ApartmentId,ApartmentType,ApartmentPrice,ApartmentAddress")] Apartment apartment)
        {
            if (id != apartment.ApartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.ApartmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexForManager));
            }
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartments
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }
        public async Task<IActionResult> DeleteForManager(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment1 = await _context.Apartments
                .FirstOrDefaultAsync(m => m.ApartmentId == id);
            if (apartment1 == null)
            {
                return NotFound();
            }

            return View(apartment1);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(e => e.ApartmentId == id);
        }

        [HttpPost, ActionName("DeleteForManager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedForManager(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexForManager));
        }

        private bool ApartmentExistsForManager(int id)
        {
            return _context.Apartments.Any(e => e.ApartmentId == id);
        }

    }
}
