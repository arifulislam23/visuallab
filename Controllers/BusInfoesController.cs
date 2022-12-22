using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusSchedule.Data;

namespace BusSchedule.Controllers
{
    public class BusInfoesController : Controller
    {
        private readonly BusScheduleContext _context;

        public BusInfoesController(BusScheduleContext context)
        {
            _context = context;
        }

        // GET: BusInfoes
        public async Task<IActionResult> Index()
        {
            var driver = _context.Driver.OrderByDescending(x => x.DriverID);
            ViewBag.driver = driver;
            return View(await _context.BusInfo.ToListAsync());
        }

        // GET: BusInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var driver = _context.Driver.OrderByDescending(x => x.DriverID);
            ViewBag.driver = driver;
            if (id == null)
            {
                return NotFound();
            }

            var busInfo = await _context.BusInfo
                .FirstOrDefaultAsync(m => m.Busid == id);
            if (busInfo == null)
            {
                return NotFound();
            }

            return View(busInfo);
        }

        // GET: BusInfoes/Create
        public IActionResult Create()
        {
            var driver = _context.Driver.OrderByDescending(x => x.DriverID);
            ViewBag.driver = driver;
            return View();
        }

        // POST: BusInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Busid,BusNumber,busName,BusSit")] BusInfo busInfo)
        {
            if (ModelState.IsValid)
            {
                
                    _context.Add(busInfo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                 
               
            }
            return View(busInfo);
        }

        // GET: BusInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var driver = _context.Driver.OrderByDescending(x => x.DriverID);
            ViewBag.driver = driver;
            if (id == null)
            {
                return NotFound();
            }

            var busInfo = await _context.BusInfo.FindAsync(id);
            if (busInfo == null)
            {
                return NotFound();
            }
            return View(busInfo);
        }

        // POST: BusInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Busid,BusNumber,busName,BusSit")] BusInfo busInfo)
        {
            if (id != busInfo.Busid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusInfoExists(busInfo.Busid))
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
            return View(busInfo);
        }

        // GET: BusInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busInfo = await _context.BusInfo
                .FirstOrDefaultAsync(m => m.Busid == id);
            if (busInfo == null)
            {
                return NotFound();
            }

            return View(busInfo);
        }

        // POST: BusInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busInfo = await _context.BusInfo.FindAsync(id);
            _context.BusInfo.Remove(busInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusInfoExists(int id)
        {
            return _context.BusInfo.Any(e => e.Busid == id);
        }
    }
}
