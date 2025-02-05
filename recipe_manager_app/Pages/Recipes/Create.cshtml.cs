using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_manager_app.Models;
using System.ComponentModel.DataAnnotations;

namespace recipe_manager_app.Pages.Recipes
{

    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please upload an image.")]
        public IFormFile ImageFile { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            // Save the image to the wwwroot/img folder
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

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true });
        }
    }
}
