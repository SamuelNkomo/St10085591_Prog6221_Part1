using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085591_Part_
{
    class Recipe
    {
        public string Name { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<string> Steps { get; private set; }
        public int TotalCalories { get; private set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            TotalCalories = 0;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            TotalCalories += ingredient.Calories; // Update the total calories
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe: {0}", Name);
            Console.WriteLine("Ingredients:");

            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine(" - {0} {1} {2}, Calories: {3}, Food Group: {4}",
                    ingredient.Quantity, ingredient.Unit, ingredient.Name, ingredient.Calories, ingredient.FoodGroup);
            }

            Console.WriteLine("Steps:");

            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Steps[i]);
            }

            Console.WriteLine("Total Calories: {0}", TotalCalories);
            Console.WriteLine();

            

            if (TotalCalories > 300)
            {
                Console.WriteLine("Warning: This recipe exceeds 300 calories.");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ScaleQuantity(factor); // Scale the ingredient quantity
            }

            Console.WriteLine("Recipe '{0}' successfully scaled by a factor of {1}.", Name, factor);
        }

        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ResetQuantity(); // Reset the ingredient quantity
            }

            Console.WriteLine("Recipe '{0}' quantities successfully reset.", Name);
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