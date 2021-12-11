using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyRentalManagementWebSite.Models;

namespace PropertyRentalManagementWebSite.Controllers
{
    public class AppointmentAssignmentsController : Controller
    {
        private readonly PropertyRentalManagementWebSiteDBContext _context;

        public AppointmentAssignmentsController(PropertyRentalManagementWebSiteDBContext context)
        {
            _context = context;
        }

        // GET: AppointmentAssignments
        public async Task<IActionResult> Index()
        {
            var propertyRentalManagementWebSiteDBContext = _context.AppointmentAssignments.Include(a => a.Apartment).Include(a => a.Manager).Include(a => a.Tenant);
            return View(await propertyRentalManagementWebSiteDBContext.ToListAsync());
        }
        public async Task<IActionResult> IndexForManager()
        {
            var propertyRentalManagementWebSiteDBContext = _context.AppointmentAssignments.Include(a => a.Apartment).Include(a => a.Manager).Include(a => a.Tenant);
            return View(await propertyRentalManagementWebSiteDBContext.ToListAsync());
        }
        public async Task<IActionResult> IndexForTenant()
        {
            var propertyRentalManagementWebSiteDBContext = _context.AppointmentAssignments.Include(a => a.Apartment).Include(a => a.Manager).Include(a => a.Tenant);
            return View(await propertyRentalManagementWebSiteDBContext.ToListAsync());
        }

        // GET: AppointmentAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentAssignment = await _context.AppointmentAssignments
                .Include(a => a.Apartment)
                .Include(a => a.Manager)
                .Include(a => a.Tenant)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (appointmentAssignment == null)
            {
                return NotFound();
            }

            return View(appointmentAssignment);
        }

        public async Task<IActionResult> DetailsForManager(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentAssignment = await _context.AppointmentAssignments
                .Include(a => a.Apartment)
                .Include(a => a.Manager)
                .Include(a => a.Tenant)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (appointmentAssignment == null)
            {
                return NotFound();
            }

            return View(appointmentAssignment);
        }

        // GET: AppointmentAssignments/Create
        public IActionResult Create()
        {
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress");
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername");
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName");
            return View();
        }
        public IActionResult CreateForManager()
        {
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress");
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername");
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName");
            return View();
        }
        public IActionResult CreateForTenant()
        {
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress");
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername");
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName");
            return View();
        }
        // POST: AppointmentAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentId,ManagerId,TenantId,ApartmentId,Date,NoteMessage")] AppointmentAssignment appointmentAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress", appointmentAssignment.ApartmentId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername", appointmentAssignment.ManagerId);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName", appointmentAssignment.TenantId);
            return View(appointmentAssignment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForManager([Bind("AssignmentId,ManagerId,TenantId,ApartmentId,Date,NoteMessage")] AppointmentAssignment appointmentAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexForManager));
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress", appointmentAssignment.ApartmentId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername", appointmentAssignment.ManagerId);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName", appointmentAssignment.TenantId);
            return View(appointmentAssignment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForTenant([Bind("AssignmentId,ManagerId,TenantId,ApartmentId,Date,NoteMessage")] AppointmentAssignment appointmentAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexForTenant));
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress", appointmentAssignment.ApartmentId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername", appointmentAssignment.ManagerId);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName", appointmentAssignment.TenantId);
            return View(appointmentAssignment);
        }
        // GET: AppointmentAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentAssignment = await _context.AppointmentAssignments.FindAsync(id);
            if (appointmentAssignment == null)
            {
                return NotFound();
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress", appointmentAssignment.ApartmentId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername", appointmentAssignment.ManagerId);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName", appointmentAssignment.TenantId);
            return View(appointmentAssignment);
        }
        public async Task<IActionResult> EditForManager(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentAssignment = await _context.AppointmentAssignments.FindAsync(id);
            if (appointmentAssignment == null)
            {
                return NotFound();
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress", appointmentAssignment.ApartmentId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername", appointmentAssignment.ManagerId);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName", appointmentAssignment.TenantId);
            return View(appointmentAssignment);
        }

        // POST: AppointmentAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId,ManagerId,TenantId,ApartmentId,Date,NoteMessage")] AppointmentAssignment appointmentAssignment)
        {
            if (id != appointmentAssignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentAssignmentExists(appointmentAssignment.AssignmentId))
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
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress", appointmentAssignment.ApartmentId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername", appointmentAssignment.ManagerId);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName", appointmentAssignment.TenantId);
            return View(appointmentAssignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditForManager(int id, [Bind("AssignmentId,ManagerId,TenantId,ApartmentId,Date,NoteMessage")] AppointmentAssignment appointmentAssignment)
        {
            if (id != appointmentAssignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentAssignmentExists(appointmentAssignment.AssignmentId))
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
            ViewData["ApartmentId"] = new SelectList(_context.Apartments, "ApartmentId", "ApartmentAddress", appointmentAssignment.ApartmentId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "ManagerId", "ManagerUsername", appointmentAssignment.ManagerId);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "TenantId", "TenantFirstName", appointmentAssignment.TenantId);
            return View(appointmentAssignment);
        }

        // GET: AppointmentAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentAssignment = await _context.AppointmentAssignments
                .Include(a => a.Apartment)
                .Include(a => a.Manager)
                .Include(a => a.Tenant)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (appointmentAssignment == null)
            {
                return NotFound();
            }

            return View(appointmentAssignment);
        }

        // POST: AppointmentAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentAssignment = await _context.AppointmentAssignments.FindAsync(id);
            _context.AppointmentAssignments.Remove(appointmentAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentAssignmentExists(int id)
        {
            return _context.AppointmentAssignments.Any(e => e.AssignmentId == id);
        }

        public async Task<IActionResult> DeleteForManager(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentAssignment = await _context.AppointmentAssignments
                .Include(a => a.Apartment)
                .Include(a => a.Manager)
                .Include(a => a.Tenant)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (appointmentAssignment == null)
            {
                return NotFound();
            }

            return View(appointmentAssignment);
        }

        [HttpPost, ActionName("DeleteForManager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedForManageer(int id)
        {
            var appointmentAssignment = await _context.AppointmentAssignments.FindAsync(id);
            _context.AppointmentAssignments.Remove(appointmentAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexForManager));
        }

        private bool AppointmentAssignmentExistsForManager(int id)
        {
            return _context.AppointmentAssignments.Any(e => e.AssignmentId == id);
        }



    }
}
