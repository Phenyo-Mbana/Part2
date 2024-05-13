namespace TestProject1
{
    [TestFixture]
    public class recipe
    {
        [Test]
        public void TotalCaloriesCalculation()
        {
            // Arrange
            Recipe recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Ingredient 1", 100, "g", 50, "Group1");
            recipe.AddIngredient("Ingredient 2", 200, "ml", 30, "Group2");
            recipe.AddIngredient("Ingredient 3", 150, "g", 80, "Group1");

            // Act
            double totalCalories = recipe.Ingredients.Sum(i => i.Calories);

            // Assert
            Assert.That(totalCalories, Is.EqualTo(100 * 50 + 200 * 30 + 150 * 80));
        }
    }
}
