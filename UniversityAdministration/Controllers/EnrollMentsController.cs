using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityAdministration.Models;
using UniversityAdministration.Models.Entities;

namespace UniversityAdministration.Controllers
{
    public class EnrollMentsController : Controller
    {
        private readonly UniversityAdministrationContext _context;

        public EnrollMentsController(UniversityAdministrationContext context)
        {
            _context = context;
        }

        // GET: EnrollMents
        public async Task<IActionResult> Index()
        {
            var universityAdministrationContext = _context.EnrollMent.Include(e => e.Course).Include(e => e.Student);
            return View(await universityAdministrationContext.ToListAsync());
        }

        // GET: EnrollMents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollMent = await _context.EnrollMent
                .Include(e => e.Course)
                .Include(e => e.Student)
                .SingleOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollMent == null)
            {
                return NotFound();
            }

            return View(enrollMent);
        }

        // GET: EnrollMents/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            return View();
        }

        // POST: EnrollMents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,StudentId,CourseId,Grade")] EnrollMent enrollMent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollMent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", enrollMent.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", enrollMent.StudentId);
            return View(enrollMent);
        }

        // GET: EnrollMents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollMent = await _context.EnrollMent.SingleOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollMent == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", enrollMent.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", enrollMent.StudentId);
            return View(enrollMent);
        }

        // POST: EnrollMents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,StudentId,CourseId,Grade")] EnrollMent enrollMent)
        {
            if (id != enrollMent.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollMent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollMentExists(enrollMent.EnrollmentId))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", enrollMent.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", enrollMent.StudentId);
            return View(enrollMent);
        }

        // GET: EnrollMents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollMent = await _context.EnrollMent
                .Include(e => e.Course)
                .Include(e => e.Student)
                .SingleOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollMent == null)
            {
                return NotFound();
            }

            return View(enrollMent);
        }

        // POST: EnrollMents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollMent = await _context.EnrollMent.SingleOrDefaultAsync(m => m.EnrollmentId == id);
            _context.EnrollMent.Remove(enrollMent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollMentExists(int id)
        {
            return _context.EnrollMent.Any(e => e.EnrollmentId == id);
        }
    }
}
