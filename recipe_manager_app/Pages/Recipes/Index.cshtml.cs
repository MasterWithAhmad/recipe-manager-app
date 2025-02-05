/*
 ******************************************************************
    Title: Recipe List PageModel
    Author: Ahmed Ibrahim Ahmed
    Date: 2025-02-02
    Description: Handles the logic for displaying a list of recipes.
 ******************************************************************
*/
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using recipe_manager_app.Models;

namespace recipe_manager_app.Pages.Recipes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Recipe> Recipes { get; set; }
        public string NameSort { get; set; }
        public string CookingTimeSort { get; set; }
        public string DifficultySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = sortOrder == "Name" ? "name_desc" : "Name";
            CookingTimeSort = sortOrder == "CookingTime" ? "cookingtime_desc" : "CookingTime";
            DifficultySort = sortOrder == "DifficultyLevel" ? "difficulty_desc" : "DifficultyLevel";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            var recipes = _context.Recipes.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(r => r.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    recipes = recipes.OrderByDescending(r => r.Name);
                    break;
                case "CookingTime":
                    recipes = recipes.OrderBy(r => r.CookingTime);
                    break;
                case "cookingtime_desc":
                    recipes = recipes.OrderByDescending(r => r.CookingTime);
                    break;
                case "DifficultyLevel":
                    recipes = recipes.OrderBy(r => r.DifficultyLevel);
                    break;
                case "difficulty_desc":
                    recipes = recipes.OrderByDescending(r => r.DifficultyLevel);
                    break;
                default:
                    recipes = recipes.OrderBy(r => r.Name);
                    break;
            }

            const int pageSize = 6; // Number of recipes per page
            Recipes = await PaginatedList<Recipe>.CreateAsync(recipes.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
