using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Data;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDBContext _dbContext;

		public BookController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

        public IActionResult Index()
        {
            var listBooks = _dbContext.Books.Include(b => b.Category).ToList(); // Load cả thông tin Category
            return View(listBooks);
        }

        public IActionResult Add()
        {
            ViewBag.Categories = _dbContext.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View();
        }

        [HttpPost]
		public IActionResult Add(Book book)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Books.Add(book);
				_dbContext.SaveChanges();
				TempData["success"] = "Book is added successfully";
				return RedirectToAction("Index");
			}

			return View();
		}

        public IActionResult Edit(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _dbContext.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(book);
        }

        [HttpPost]
		public IActionResult Edit(Book book)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Books.Update(book);
				_dbContext.SaveChanges();
				TempData["success"] = "Book is updated successfully";
				return RedirectToAction("Index");
			}

			TempData["failed"] = "Book cannot be updated";
			return View();
		}

        public IActionResult Delete(int id)
        {
            var book = _dbContext.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id); // Load cả Category
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
		public IActionResult Delete(Book book)
		{
			_dbContext.Books.Remove(book);
			_dbContext.SaveChanges();
			TempData["success"] = "Book is deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
