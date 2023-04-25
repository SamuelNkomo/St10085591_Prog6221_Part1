using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085591_Part_1
{
    class Recipe
    {
        private string[] Ingredient_Name;
        private string[] Ingredient_Units;
        private string[] Steps;
        private double[] Ingredient_Quantities;

        public void EnterRecipe()
        {
            Console.Write("Fill in number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            Ingredient_Name = new string[numIngredients];
            Ingredient_Quantities = new double[numIngredients];
            Ingredient_Units = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Fill in Name of ingredient {0}: ", i + 1);
                Ingredient_Name[i] = Console.ReadLine();

                Console.Write("Fill in Quantity of ingredient : ", i + 1);
                Ingredient_Quantities[i] = double.Parse(Console.ReadLine());

                Console.Write("Fill in Unit of measurement of ingredient {0}: ", i + 1);
                Ingredient_Units[i] = Console.ReadLine();
            }
            // This is to allow the recipep to have multiple steps
            Console.Write("Fill in number of steps: ");
            int numStep = int.Parse(Console.ReadLine());

            Steps = new string[numStep];

            for (int i = 0; i < numStep; i++)
            {
                Console.Write("Fill in step {0}: ", i + 1);
                Steps[i] = Console.ReadLine();
            }
        }

        public void Display_Recipe()
        {
            //This section should be able to Display the recipe the client hae requested for
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < Ingredient_Name.Length; i++)
            {
                Console.WriteLine(" ~ {0} {1} {2}", Ingredient_Quantities[i], Ingredient_Units[i], Ingredient_Name[i]);
            }
            //Also include the numbers of steps provided
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Steps[i]);
            }
        }

        public void Scale_Recipe(double factor)
        {
            for (int i = 0; i < Ingredient_Quantities.Length; i++)
            {
                Console.WriteLine(" ~ {0}", Ingredient_Quantities[i]);
                Ingredient_Quantities[i] *= factor;
            }
        }

        public void Reset_Quantities()
        {
            // This secetion is going to reset the Quantity dividing it by 2
            for (int i = 0; i < Ingredient_Quantities.Length; i++)
            {
                //Assuming that the original quantities are always doubled when scale
                Ingredient_Quantities[i] /= 2;
                Console.WriteLine("Quantity is reset");
            }
        }

        public void Clear_Recipe()
        {
            // This secetion is going to clear the recipe that the clients caputured 
            Ingredient_Name = null;
            Ingredient_Quantities = null;
            Ingredient_Units = null;
            Steps = null;

            Console.WriteLine("Recipe is sucessfully cleared");
        }
    }
}
