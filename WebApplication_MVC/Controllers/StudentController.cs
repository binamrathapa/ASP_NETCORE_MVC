using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_MVC.Data;
using WebApplication_MVC.Models;

namespace WebApplication_MVC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly WebApplication_MVCContext _context;

        public StudentController(WebApplication_MVCContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index(int? departmentId, string? studentName)
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            if (string.IsNullOrEmpty(studentName))
            {
                if (departmentId == null)
                {
                    var webApplication_MVCContext = _context.Student.Include(s => s.Department);
                    return View(await webApplication_MVCContext.ToListAsync());
                }
                else
                {
                    //var webApplication_MVCContext = _context.Student.Include(s => s.Department).Where(s => s.DepartmentId == departmentId);
                    //var filterStudents = from s in _context.Student where s.DepartmentId == departmentId && s.Name.Contains(studentName) orderby s.Name select s;
                    var filterStudents = from s in _context.Student join d in _context.Department on s.DepartmentId equals d.Id where s.DepartmentId == departmentId select new { s.Name, s.Email, s.Address, DName = d.Name };
                    return View(await filterStudents.ToListAsync());
                }
            }
            else
            {
                var webApplication_MVCContext = _context.Student.Include(s => s.Department).Where(s=>s.Name.Contains(studentName));
                return View(await webApplication_MVCContext.ToListAsync());
            }
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Department)
                .FirstOrDefaultAsync(n => n.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Address,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", student.DepartmentId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", student.DepartmentId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Address,DepartmentId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", student.DepartmentId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
        public IActionResult Approve()
        {
            return View();
        }

    }
}
