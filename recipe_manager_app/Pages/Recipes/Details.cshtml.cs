/*
 ****************************************************************** 
    Title: Recipe Details PageModel
    Author: Ahmed Ibrahim Ahmed
    Date: 2025-02-02
    Description: Handles the logic for displaying the details of a specific recipe.
******************************************************************
*/
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_manager_app.Models;

namespace recipe_manager_app.Pages.Recipes
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }

        public IActionResult OnGet(int id)
        {
            // Fetch the recipe from the database using the ID
            Recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);

            // If the recipe is not found, return a 404 error
            if (Recipe == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
