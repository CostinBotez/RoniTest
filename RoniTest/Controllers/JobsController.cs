using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoniTest.Data;
using RoniTest.Models;

namespace RoniTest.Controllers
{
    public class JobsController : Controller
    {
        private readonly TestDbContext _context;
        private readonly ILogger<JobsController> _logger;

        public JobsController(
            TestDbContext context,
            ILogger<JobsController> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var jobs = _context.Jobs
                .Include(j => j.RoomType);
            return View(await jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ContractorID,Name,Status,Floor,Room,DelayReason,DateCreated,DateCompleted,DateDelayed,StatusNum,RJobID,RoomTypeId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("ID,ContractorID,Name,Status,Floor,Room,DelayReason,DateCreated,DateCompleted,DateDelayed,StatusNum,RJobID,RoomTypeId")] Job job)
        {
            if (id != job.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.ID))
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
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var job = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Jobs/MarkAsComplete/
        [HttpPost, ActionName("MarkAsComplete")]
        public async Task<IActionResult> MarkAsComplete(Guid? id)
        {
            try
            {
                var job = await _context.Jobs.FindAsync(id);
                job.Status = "Complete";
                _context.Update(job);
                await _context.SaveChangesAsync();
                return new JsonResult(new
                {
                    status = "success"
                });
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e.Message);

                return new JsonResult(new
                {
                    status = "fail"
                });
            }
        }

        private bool JobExists(Guid id)
        {
            return _context.Jobs.Any(e => e.ID == id);
        }
    }
}
