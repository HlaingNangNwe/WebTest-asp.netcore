using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebTest.Models;

namespace MyWebTest.Controllers
{
    public class BookController : Controller
    {
        private readonly MyWebTestContext _context;

        public BookController(MyWebTestContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index(string bookCate, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> catteQuery = from b in _context.Books
                                            join c in _context.Categories on b.CategoryId equals c.CategoryId
                                            select b.Name;

            var books = from b in _context.Books
                        select b;


            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookCate))
            {
                books = books.Where(b => b.Name == bookCate);
            }
            var bcVM = new BookCategoryViewModel
            {
                Cate = new SelectList(await catteQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };
            ViewBag.books = _context.Books.Include(b => b.Category);

            return View(bcVM);
        }
        /* public async Task<IActionResult> IActionResult Index(string BookCate, string searchString)
         {
             //var myWebTestContext = 
             IQueryable<string> catteQuery = from b in _context.Books
                                             join c in _context.Categories on b.CategoryId equals c.CategoryId
                                             select b.Name;

             var books = from b in _context.Books
                          select b;


             if (!string.IsNullOrEmpty(searchString))
             {
                 books = books.Where(b => b.Name.Contains(searchString));
             }

             if (!string.IsNullOrEmpty(BookCate))
             {
                 books = books.Where(b => b.Name == BookCate);
             }
             var bVM = new BookCategoeyViewModel

             {
                 Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                  Movies = await movies.ToListAsync()
             };

             return View(bVM);



         }*/


        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.bookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bookId,Name,Author,Price,CategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bookId,Name,Author,Price,CategoryId")] Book book)
        {
            if (id != book.bookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.bookId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.bookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.bookId == id);
        }
    }
}
