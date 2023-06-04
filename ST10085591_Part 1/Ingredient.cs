using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085591_Part_1
{
    class Ingredient
    {
        public string Name { get; private set; }
        public double Quantity { get; private set; }
        public string Unit { get; private set; }
        public int Calories { get; private set; }
        public string FoodGroup { get; private set; }

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public void ScaleQuantity(double factor)
        {
            Quantity *= factor;
        }

        public void ResetQuantity()
        {
            Quantity /= 2;
        }
    }
}
