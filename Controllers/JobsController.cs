using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearchPortal.Data;
using JobSearchPortal.Models;

namespace JobSearchPortal.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            try
            {
                // Retrieve all jobs from the database
                var jobs = await _context.Jobs.ToListAsync();
                return View(jobs);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the retrieval of jobs
                return View("Error", ex.Message);
            }
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Find the job with the specified id
                var job = await _context.Jobs.FirstOrDefaultAsync(m => m.Id == id);
                if (job == null)
                {
                    return NotFound();
                }

                return View(job);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PositionID,PositionTitle,PositionURI,Location,OrganizationName,DepartmentName,QualificationSummary,PositionStartDate,PositionEndDate,ApplicationCloseDate")] Job job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Add the new job to the database
                    _context.Add(job);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(job);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Find the job with the specified id
                var job = await _context.Jobs.FindAsync(id);
                if (job == null)
                {
                    return NotFound();
                }
                return View(job);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PositionID,PositionTitle,PositionURI,Location,OrganizationName,DepartmentName,QualificationSummary,PositionStartDate,PositionEndDate,ApplicationCloseDate")] Job job)
        {
            try
            {
                if (id != job.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    // Update the job in the database
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(job);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(job.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Find the job with the specified id
                var job = await _context.Jobs.FirstOrDefaultAsync(m => m.Id == id);
                if (job == null)
                {
                    return NotFound();
                }

                return View(job);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Find the job with the specified id
                var job = await _context.Jobs.FindAsync(id);
                if (job != null)
                {
                    // Remove the job from the database
                    _context.Jobs.Remove(job);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
