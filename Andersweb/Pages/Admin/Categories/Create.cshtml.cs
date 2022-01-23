
using Andersweb.DataAccess.Data;
using Andersweb.DataAccess.Repository.IRepository;
using Andersweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Andersweb.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository _dbCategory;
        
        public Category Category { get; set; }
        public CreateModel(ICategoryRepository dbCategory)
        {
            _dbCategory = dbCategory;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "the displayd orders can not be match to the Name");
            }
            if(ModelState.IsValid)
            { 
                _dbCategory.Add(Category);
                _dbCategory.save();
                TempData["success"] = "Category was created successfully";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
