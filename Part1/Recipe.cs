using System;
using System.Collections.Generic;
using System.Linq;

namespace Part2
{
    public class Recipe
    {
        private List<Ingredient> originalIngredients;

        // Event to notify when the total calories exceed a threshold
        public event Action<string> RecipeExceedsCalories;

        // Properties of a recipe
        public string Name { get; }
        public List<Ingredient> Ingredients { get; }
        public List<Step> Steps { get; }

        // Constructor to initialize the recipe with a name
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            originalIngredients = new List<Ingredient>(); // Initialize the list to store original ingredients
        }

        // Method to create a new recipe by inputting details from the user
        public static Recipe CreateRecipe()
        {
            Console.WriteLine("Enter the name of the recipe:");
            string name = Console.ReadLine();
            Recipe recipe = new Recipe(name);

            // Loop to input ingredients
            bool addMoreIngredients = true;
            while (addMoreIngredients)
            {
                Console.WriteLine("Enter the name of the ingredient:");
                string ingredientName = Console.ReadLine();

                Console.WriteLine("Enter the quantity:");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter the unit of measurement:");
                string unit = Console.ReadLine();

                Console.WriteLine("Enter the number of calories:");
                double calories = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter the food group:");
                string foodGroup = Console.ReadLine();

                recipe.AddIngredient(ingredientName, quantity, unit, calories, foodGroup);

                Console.WriteLine("Do you want to add more ingredients? (yes/no)");
                addMoreIngredients = Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);
            }

            // Loop to input cooking steps
            bool addMoreSteps = true;
            while (addMoreSteps)
            {
                Console.WriteLine("Enter a step:");
                string stepDescription = Console.ReadLine();
                recipe.AddStep(stepDescription);

                Console.WriteLine("Do you want to add more steps? (yes/no)");
                addMoreSteps = Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);
            }

            return recipe;
        }

        // Method to display a list of recipes
        public static void DisplayRecipeList(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("List of Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            originalIngredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup }); // Add to original ingredients list for resetting
        }

        // Method to add a cooking step to the recipe
        public void AddStep(string description)
        {
            Steps.Add(new Step { Description = description });
        }

        // Method to reset quantities of ingredients to their original values
        public void ResetQuantitiesToOriginal()
        {
            Ingredients.Clear();                        // Clear current ingredients
            Ingredients.AddRange(originalIngredients); // Reset to original ingredients
        }

        // Method to clear all data of the recipe
        public void ClearRecipeData()
        {
            Ingredients.Clear(); // Clear ingredients
            Steps.Clear();       // Clear cooking steps
            originalIngredients.Clear(); // Clear original ingredients
        }

        // Method to display the details of the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i].Description}");
            }

            double totalCalories = Ingredients.Sum(i => i.Calories);
            Console.WriteLine($"Total Calories: {totalCalories}");

            // Notify if total calories exceed threshold
            if (totalCalories > 300)
                RecipeExceedsCalories?.Invoke(Name);
        }
    }
}
