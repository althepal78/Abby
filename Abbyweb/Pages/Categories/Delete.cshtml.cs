using Abbyweb.Data;
using Abbyweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abbyweb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);

        }
        public async Task<IActionResult> OnPost()
        {
            var category = await _db.Category.FindAsync(Category.Id);
            if (category != null)
            {
                _db.Category.Remove(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
