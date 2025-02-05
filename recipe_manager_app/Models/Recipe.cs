// Title: Recipe Model
// Author: Ahmed Ibrahim Ahmed
// Date: 2025-02-02
// Description: Represents a recipe in the Recipe Manager App.

using System;
using System.ComponentModel.DataAnnotations;

namespace recipe_manager_app.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty; // Recipe name

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty; // Recipe description

        [Required]
        public string Ingredients { get; set; } = string.Empty; // List of ingredients

        [Required]
        public string Instructions { get; set; } = string.Empty; // Step-by-step instructions

        [Required]
        [Range(1, 600)]
        public int CookingTime { get; set; } // Cooking time in minutes

        [Required]
        [StringLength(20)]
        public string DifficultyLevel { get; set; } = string.Empty; // Difficulty level (e.g., Easy, Medium, Hard)

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty; // Recipe category (e.g., Breakfast, Lunch, Dinner)

        public string? ImageUrl { get; set; } // URL for the recipe image (optional)
    }
}
