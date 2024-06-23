using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST10072500_CLDV6211_Part2.Data;
using ST10072500_CLDV6211_Part2.Models;
using ST10072500_CLDV6211_Part2.ViewModels;


namespace CLDV_Part_2_ST10072500_Priya.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var transactions = await _context.Transaction
                .Include(t => t.Product)
                .Include(t => t.User)
                .ToListAsync();
            var products = await _context.Product.ToListAsync();

            var viewModel = new TrasactionProductViewModel
            {
                Transactions = transactions,
                Products = products
            };

            return View(viewModel);
        }



        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.User)
                .Include(t => t.Product)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["ArtId"] = new SelectList(_context.Set<Product>(), "ArtId", "ArtId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,UserId,ArtId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtId"] = new SelectList(_context.Set<Product>(), "ArtId", "ArtId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["ArtId"] = new SelectList(_context.Set<Product>(), "ArtId", "ArtId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,UserId,ArtId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["ArtId"] = new SelectList(_context.Set<Product>(), "ArtId", "ArtId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> TransactionHistory(TransactionHistoryViewModel model) { 
        
        
        var query = _context.Transaction.Include(t => t.User).Include(t => t.Product).AsQueryable();

           if (model.FilterArtID.HasValue) {

               query = query.Where(t => t.ArtId == model.FilterArtID.Value);
            
            }
            if (model.FilterUserID.HasValue)
            {

                query = query.Where(t => t.ArtId == model.FilterUserID.Value);

            }
            if (model.FilerOrderDate.HasValue) { 
            
                query = query.Where(t => t.TransactionDate >= model.FilerOrderDate.Value);

            }
            if (model.FilterDeliveryDate.HasValue)
            {

                query = query.Where(t => t.TransactionDate <= model.FilterDeliveryDate.Value);

            }

            model.Transactions = await query.OrderByDescending(t => t.ModifiedDate).ToListAsync();

            return View(model);

        }












        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}
