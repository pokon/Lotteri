using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lotteri.Models;

namespace Lotteri.Controllers
{
    public class LotteriController : Controller
    {
        private readonly LotteriContext _context;

        public LotteriController(LotteriContext context)
        {
            _context = context;
        }

        // GET: Lotteri
        public async Task<IActionResult> Index()
        {
            return View(await _context.LottoItemModel.ToListAsync());
        }

        // GET: Lotteri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lottoItemModel = await _context.LottoItemModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lottoItemModel == null)
            {
                return NotFound();
            }

            return View(lottoItemModel);
        }

        // GET: Lotteri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lotteri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateFrom,DateTo,IsVisible")] LottoItemModel lottoItemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lottoItemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lottoItemModel);
        }

        // GET: Lotteri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lottoItemModel = await _context.LottoItemModel.SingleOrDefaultAsync(m => m.Id == id);
            if (lottoItemModel == null)
            {
                return NotFound();
            }
            return View(lottoItemModel);
        }

        // POST: Lotteri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateFrom,DateTo,IsVisible")] LottoItemModel lottoItemModel)
        {
            if (id != lottoItemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lottoItemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LottoItemModelExists(lottoItemModel.Id))
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
            return View(lottoItemModel);
        }

        // GET: Lotteri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lottoItemModel = await _context.LottoItemModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lottoItemModel == null)
            {
                return NotFound();
            }

            return View(lottoItemModel);
        }

        // POST: Lotteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lottoItemModel = await _context.LottoItemModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.LottoItemModel.Remove(lottoItemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LottoItemModelExists(int id)
        {
            return _context.LottoItemModel.Any(e => e.Id == id);
        }
    }
}
