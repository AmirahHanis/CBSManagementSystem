using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CBSManagementSystem.Data;
using CBSManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBSManagementSystem.Controllers
{
    [Route("[controller]")]
    public class DonationsController : Controller
    {
        private readonly CBSManagementContext _context;

        public DonationsController(CBSManagementContext context)
        {
            _context = context;
        }

        // GET: Donations
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var donations = await _context.Donations.ToListAsync();
            return View(donations); // Returns the list view of Donations
        }

        // GET: Donations/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation); // Returns the details view of a specific Donations
        }

        // GET: Donations/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new Donations
        }

        // POST: Donations/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the donation list
            }
            return View(donation);
        }

        // GET: Donation/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            return View(donation); // Returns the edit view for a specific donations
        }

        // POST: Donations/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Donation donation)
        {
            if (id != donation.ItemID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the Donations list
            }
            return View(donation);
        }

        // GET: Donations/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation); // Returns the delete confirmation view
        }

        // POST: Donations/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the Donations list
        }

        private bool DonationExists(int id)
        {
            return _context.Donations.Any(e => e.ItemID == id);
        }
    }
}

