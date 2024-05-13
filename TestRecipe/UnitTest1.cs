using NUnit.Framework;
using System.IO;
using TestRecipe; // Import the namespace where the Recipe class is defined

namespace TestRecipe
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // No specific setup required for this test
        }

        [Test]
        public void TestResetQuantitiesToOriginal()
        {
            // Arrange
            var recipe = new Part2.Recipe("Test Recipe");
            recipe.AddIngredient("Ingredient 1", 100, "grams", 50, "Vegetables");
            recipe.AddIngredient("Ingredient 2", 200, "ml", 80, "Dairy");
            recipe.AddIngredient("Ingredient 3", 2, "cups", 120, "Grains");

            // Act
            recipe.ResetQuantitiesToOriginal();

            // Assert
            foreach (var ingredient in recipe.Ingredients)
            {
                Assert.AreEqual(ingredient.Quantity, recipe.originalIngredients.Find(i => i.Name == ingredient.Name).Quantity,
                    $"Quantity of {ingredient.Name} is not reset to original value.");
            }
        }
    }
}
