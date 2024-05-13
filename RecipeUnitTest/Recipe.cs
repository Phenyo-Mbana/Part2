using NUnit.Framework;
using RecipeUnitTest; // Import the namespace where the Recipe class is defined

namespace RecipeUnitTest
{
    public class Tests
    {
        [Test]
        public void TestResetQuantitiesToOriginal()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Ingredient 1", 100, "grams", 50, "Vegetables");
            recipe.AddIngredient("Ingredient 2", 200, "ml", 80, "Dairy");
            recipe.AddIngredient("Ingredient 3", 2, "cups", 120, "Grains");

            // Act
            recipe.ResetQuantitiesToOriginal();

            // Assert
            foreach (var ingredient in recipe.Ingredients)
            {
                // Check if the quantity of each ingredient has been reset to its original value
                Assert.AreEqual(ingredient.Quantity, recipe.originalIngredients.Find(i => i.Name == ingredient.Name).Quantity,
                    $"Quantity of {ingredient.Name} is not reset to original value.");
            }
        }
    }
}
