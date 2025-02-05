// Title: Application Database Context
// Author: Ahmed Ibrahim Ahmed
// Date: 2025-02-02
// Description: Manages the database connection and tables for the Recipe Manager App.

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using recipe_manager_app.Models;

namespace recipe_manager_app.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Represents the Recipes table in the database
        public DbSet<Recipe> Recipes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data (optional)
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Spaghetti Carbonara",
                    Description = "A classic Italian pasta dish.",
                    Ingredients = "Spaghetti, Eggs, Parmesan Cheese, Pancetta, Garlic, Black Pepper",
                    Instructions = "1. Cook spaghetti. 2. Fry pancetta. 3. Mix eggs and cheese. 4. Combine everything.",
                    CookingTime = 30,
                    DifficultyLevel = "Medium",
                    Category = "Dinner",
                    ImageUrl = "wwwroot\\img\\spaghetti-carbonara.jpg"
                },
                new Recipe
                {
                    Id = 2,
                    Name = "Chocolate Lava Cake",
                    Description = "A rich, gooey chocolate cake with a molten center.",
                    Ingredients = "Butter, Dark Chocolate, Sugar, Eggs, Flour",
                    Instructions = "1. Preheat oven. 2. Melt butter and chocolate. 3. Whisk in sugar, eggs, and flour. 4. Bake for 12 minutes.",
                    CookingTime = 20,
                    DifficultyLevel = "Intermediate",
                    Category = "Dessert",
                    ImageUrl = "wwwroot\\img\\chocolate-lava-cake.jpg"
                }
            );
        }
    }
}
