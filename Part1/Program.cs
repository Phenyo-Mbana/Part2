using System;
using System.Collections.Generic;
using System.Linq;

namespace Part2
{
    public class Program
    {
        // Main method to run the recipe management program
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Display List of Recipes");
                Console.WriteLine("3. Choose Recipe to Display");
                Console.WriteLine("4. Reset Quantities to Original Values");
                Console.WriteLine("5. Clear All Data");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Recipe newRecipe = Recipe.CreateRecipe();
                            newRecipe.RecipeExceedsCalories += NotifyExceedingCalories; 
                            recipes.Add(newRecipe);
                            break;
                        case 2:
                            Recipe.DisplayRecipeList(recipes);
                            break;
                        case 3:
                            Console.WriteLine("Enter the name of the recipe to display:");
                            string recipeName = Console.ReadLine();
                            Recipe chosenRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
                            if (chosenRecipe != null)
                                chosenRecipe.DisplayRecipe();
                            else
                                Console.WriteLine("Recipe not found.");
                            break;
                        case 4:
                            Console.WriteLine("Enter the name of the recipe to reset quantities:");
                            string resetRecipeName = Console.ReadLine();
                            Recipe recipeToReset = recipes.FirstOrDefault(r => r.Name.Equals(resetRecipeName, StringComparison.OrdinalIgnoreCase));
                            if (recipeToReset != null)
                                recipeToReset.ResetQuantitiesToOriginal();
                            else
                                Console.WriteLine("Recipe not found.");
                            break;
                        case 5:
                            recipes.Clear(); // Clear all recipes
                            Console.WriteLine("All data cleared. Enter a new recipe.");
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input is too large. Please enter a smaller number.");
                }
            }
        }

        // Method to notify when a recipe's total calories exceed a threshold
        static void NotifyExceedingCalories(string recipeName)
        {
            Console.WriteLine($"Warning: Total calories for recipe '{recipeName}' exceed 300!");
        }
    }
}
