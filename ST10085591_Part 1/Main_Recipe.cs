namespace ST10085591_Part_1
{
    class Main_Recipe
    {
        static void Main(string[] args)
        {
            //Call the over the class into the main program
            Recipe recipe = new Recipe();
            bool exit = false;

            while (!exit)
            {
                // This will the display of the menu
                Console.WriteLine();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        recipe.EnterRecipe();
                        break;

                    case "2":
                        recipe.Display_Recipe();
                        break;

                    case "3":
                        Console.Write("Enter scale factor: ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.Scale_Recipe(factor);
                        break;

                    case "4":
                        recipe.Reset_Quantities();
                        break;

                    case "5":
                        recipe.Clear_Recipe();
                        break;

                    case "6":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
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
