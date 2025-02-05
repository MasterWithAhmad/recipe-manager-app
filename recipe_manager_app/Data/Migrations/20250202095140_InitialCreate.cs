using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace recipe_manager_app.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Category", "CookingTime", "Description", "DifficultyLevel", "ImageUrl", "Ingredients", "Instructions", "Name" },
                values: new object[,]
                {
                    { 1, "Dinner", 30, "A classic Italian pasta dish.", "Medium", "wwwroot\\img\\spaghetti-carbonara.jpg", "Spaghetti, Eggs, Parmesan Cheese, Pancetta, Garlic, Black Pepper", "1. Cook spaghetti. 2. Fry pancetta. 3. Mix eggs and cheese. 4. Combine everything.", "Spaghetti Carbonara" },
                    { 2, "Dessert", 20, "A rich, gooey chocolate cake with a molten center.", "Intermediate", "wwwroot\\img\\chocolate-lava-cake.jpg", "Butter, Dark Chocolate, Sugar, Eggs, Flour", "1. Preheat oven. 2. Melt butter and chocolate. 3. Whisk in sugar, eggs, and flour. 4. Bake for 12 minutes.", "Chocolate Lava Cake" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
