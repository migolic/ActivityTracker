using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using miha.Models;
using miha.Models.activiti;

namespace miha.Controllers
{
    public class activitiesController : Controller
    {
        private readonly activityContext _context;

        public activitiesController(activityContext context)
        {
            _context = context;
        }

        // GET: activities
        public async Task<IActionResult> Index()
        {
            return View(await _context.activity.ToListAsync());
        }

        // GET: activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Tezina,Visina,Puls,Spavanje")] activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        // GET: activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activity.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Tezina,Visina,Puls,Spavanje")] activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!activityExists(activity.Id))
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
            return View(activity);
        }

        // GET: activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.activity.FindAsync(id);
            _context.activity.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool activityExists(int id)
        {
            return _context.activity.Any(e => e.Id == id);

        }
		public IActionResult byname()
		{
			var Ime = from e in _context.activity orderby e.Ime select e;
			return View(Ime);
		}
		public IActionResult byvisina()
		{
			var visina = from e in _context.activity orderby e.Visina select e;
			return View(visina);
		}
		public IActionResult bytezina()
		{
			var tezina = from e in _context.activity orderby e.Tezina select e;
			return View(tezina);
		}
		public IActionResult visokpuls()
		{
			var puls = from e in _context.activity orderby e.Puls select e;
			return View(puls);
		}
		public IActionResult byspavanje()
		{
			var spavanje = from e in _context.activity orderby e.Spavanje select e;
			return View(spavanje);
		}
	}
}
