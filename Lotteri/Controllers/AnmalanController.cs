using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lotteri.Models;
using System.Security.Principal;

namespace Lotteri.Controllers
{
    public class AnmalanController : Controller
    {
        private readonly LotteriContext _context;

        public AnmalanController(LotteriContext context)
        {
            _context = context;
        }

        // GET: Anmalan
        public async Task<IActionResult> Index()
        {
            return View(await _context.LottoItemModel.ToListAsync());
        }

        // GET: Anmalan/Details/5
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

        // GET: Anmalan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anmalan/Create
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

        // GET: Anmalan/Edit/5
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

        // POST: Anmalan/Edit/5
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

        // GET: Anmalan/Delete/5
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

        // POST: Anmalan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lottoItemModel = await _context.LottoItemModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.LottoItemModel.Remove(lottoItemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("Subscribe")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(int id,string name)
        {
            string user;
            user = name;
            //if (system.security.claims.claimsprincipal.current.identity.name == null) {
            //   user = "bosse";
            //}
            //else
            //{
            //    user = system.security.claims.claimsprincipal.current.identity.name;

            //}

            //user = "bosse";

            var lottoItemModel = await _context.LottoItemModel.Include(m => m.Subscribers)
                .SingleOrDefaultAsync(m => m.Id == id);

            //_context.LottoItemModel.Remove(lottoItemModel);
            var subscriber = new Subscriber
            {
                Name = "bosse",
                Email = "bosse@bosse.com",
                Uid = user
            };


            var found = false;

            if (lottoItemModel.Subscribers == null || lottoItemModel.Subscribers.Count == 0)
            {
                List<Subscriber> tlist = new List<Subscriber> { subscriber };
                lottoItemModel.Subscribers = tlist;
            }
            else
            {

                
                foreach (Subscriber s in lottoItemModel.Subscribers)
                {
                    if (s.Uid == subscriber.Uid) found = true;
                }
                if (!found)
                {
                    lottoItemModel.Subscribers.Add(subscriber);
                }
                
            }

            if (found) {
                
                return View("Fel");

            } else {
                await _context.SaveChangesAsync();
                return View("Klart");
            }
            
            



        }

        private bool LottoItemModelExists(int id)
        {
            return _context.LottoItemModel.Any(e => e.Id == id);
        }
    }
}
