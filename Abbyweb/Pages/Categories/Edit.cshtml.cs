using Abbyweb.Data;
using Abbyweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abbyweb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(AppDbContext db)
        {
            _db = db;
        }
       
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);

        }
        public async Task<IActionResult> OnPost()
        {

            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "You can't add them both the same");
                return Page();
            }
            if (ModelState.IsValid)
            {
               _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
           return Page();
        }
    }
}
