using ST10085591_Part_1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10085591_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>(); // Create a list to store recipes
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display recipe by name");
                Console.WriteLine("4. Scale recipes");
                Console.WriteLine("5. Reset quantities");
                Console.WriteLine("6. Clear recipe");
                Console.WriteLine("7. Exit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateRecipe(recipes); // Call the method to create a new recipe
                        break;
                    case "2":
                        DisplayAllRecipes(recipes); // Call the method to display all recipes
                        break;
                    case "3":
                        DisplayRecipeByName(recipes); // Call the method to display a recipe by name
                        break;
                    case "4":
                        Console.Write("Enter scale factor: ");
                        double factor = double.Parse(Console.ReadLine());
                        ScaleRecipe(recipes, factor); // Call the method to scale all recipes
                        break;
                    case "5":
                        ResetQuantities(recipes); // Call the method to reset quantities in all recipes
                        break;
                    case "6":
                        ClearRecipe(recipes); // Call the method to clear a recipe
                        break;
                    case "7":
                        exit = true; // Set the exit flag to true to end the loop
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateRecipe(List<Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Recipe recipe = new Recipe(name); // Create a new recipe object

            Console.Write("Fill in the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Fill in Name of ingredient {0}: ", i + 1);
                string ingredientName = Console.ReadLine();

                Console.Write("Fill in Quantity of ingredient {0}: ", i + 1);
                double ingredientQuantity = double.Parse(Console.ReadLine());

                Console.Write("Fill in Unit of measurement of ingredient {0}: ", i + 1);
                string ingredientUnit = Console.ReadLine();

                Console.Write("Fill in Calories of ingredient {0}: ", i + 1);
                int ingredientCalories = int.Parse(Console.ReadLine());

                Console.Write("Fill in Food group of ingredient {0}: ", i + 1);
                string ingredientFoodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient(ingredientName, ingredientQuantity, ingredientUnit, ingredientCalories, ingredientFoodGroup);
                recipe.AddIngredient(ingredient); // Add the ingredient to the recipe
            }

            Console.Write("Fill in the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("Fill in step {0}: ", i + 1);
                string step = Console.ReadLine();
                recipe.AddStep(step); // Add the step to the recipe
            }

            recipes.Add(recipe); // Add the recipe to the list of recipes
            Console.WriteLine("Recipe '{0}' successfully created.", recipe.Name);
        }

        static void DisplayAllRecipes(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("All Recipes:");

            foreach (Recipe recipe in recipes.OrderBy(r => r.Name)) // Sort recipes by name
            {
                Console.WriteLine(" - {0}", recipe.Name);
            }
        }

        static void DisplayRecipeByName(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.Write("Enter the name of the recipe to display: ");
            string name = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)); // Find the recipe by name

            if (recipe != null)
            {
                recipe.DisplayRecipe(); // Display the recipe details
            }
            else
            {
                Console.WriteLine("Recipe '{0}' not found.", name);
            }
        }

        static void ScaleRecipe(List<Recipe> recipes, double factor)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            foreach (Recipe recipe in recipes)
            {
                recipe.ScaleRecipe(factor); // Scale the recipe quantities
            }

            Console.WriteLine("Recipes successfully scaled by a factor of {0}.", factor);
        }

        static void ResetQuantities(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            foreach (Recipe recipe in recipes)
            {
                recipe.ResetQuantities(); // Reset the recipe quantities
            }

            Console.WriteLine("Quantities successfully reset.");
        }

        static void ClearRecipe(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.Write("Enter the name of the recipe to clear: ");
            string name = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)); // Find the recipe by name

            if (recipe != null)
            {
                recipes.Remove(recipe); // Remove the recipe from the list
                Console.WriteLine("Recipe '{0}' successfully cleared.", recipe.Name);
            }
            else
            {
                Console.WriteLine("Recipe '{0}' not found.", name);
            }
        }
    }
}

/***************************************************************************************
*    Title: <Pro C# 9 with .NET 5 : foundational principles and practices in programming>
*    Author: <(Troelsen and Japikse, 2021)>
*    Date: <2021>
*    Code version: <c#>
*    Availability: <Textbook>
*
***************************************************************************************/
