using Abbyweb.Data;
using Abbyweb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abbyweb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public IEnumerable<Category>Categories { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Category ;
        }
    }
}
