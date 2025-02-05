// Title: Delete Recipe PageModel
// Author: Ahmed Ibrahim Ahmed
// Date: 2025-02-02
// Description: Handles the logic for deleting recipes.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_manager_app.Models;

namespace recipe_manager_app.Pages.Recipes
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Recipe = await _context.Recipes.FindAsync(id);

            if (Recipe == null)
            {
                return NotFound();
            }

            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Recipe = await _context.Recipes.FindAsync(id);

            if (Recipe != null)
            {
                _context.Recipes.Remove(Recipe);
                await _context.SaveChangesAsync();
            }

            return new JsonResult(new { success = true });
        }
    }
}
