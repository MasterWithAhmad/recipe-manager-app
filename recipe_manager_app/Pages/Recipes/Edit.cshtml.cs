// Title: Edit Recipe PageModel
// Author: Ahmed Ibrahim Ahmed
// Date: 2025-02-02
// Description: Handles the logic for editing existing recipes.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_manager_app.Models;

namespace recipe_manager_app.Pages.Recipes
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EditModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Recipe = await _context.Recipes.FindAsync(id);

            if (Recipe == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the image if a new one is uploaded
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "img");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                Recipe.ImageUrl = "/img/" + uniqueFileName;
            }

            _context.Recipes.Update(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
