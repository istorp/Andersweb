
using Andersweb.DataAccess.Data;
using Andersweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Andersweb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet( int id)
        {
            Category = _db.Category.Find(id);
            //Category = _db.Category.FirstOrDefault(u=>u.Id== id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u=>u.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "the displayd orders can not be match to the Name");
            }
            if(ModelState.IsValid)
            { 
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category was updated successfully";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
