using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10085591_Prog6221_Poe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the recipe name from the text box
            string recipeName = RecipeNameTextBox.Text.Trim();
            // Check if the recipe name is valid
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid Recipe name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Create a new Recipe object with the given name
            Recipe newRecipe = new Recipe(recipeName);

            // Get the steps from the StepsTextBox and split them into a list
            string stepsText = StepsTextBox.Text.Trim();
            List<string> steps = stepsText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            newRecipe.Steps = steps;

            // Add the new recipe to the list
            recipes.Add(newRecipe);
            // Update the RecipeListBox to display the recipes in alphabetical order
            RecipeListBox.ItemsSource = recipes.OrderBy(r => r.Name);

            // Clear the text boxes for recipe input
            RecipeNameTextBox.Clear();
            StepsTextBox.Clear();
        }


        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected recipe from the RecipeListBox
            Recipe selectedRecipe = RecipeListBox.SelectedItem as Recipe;
            // Check if a recipe is selected
            if (selectedRecipe != null)
            {
                // Get the ingredient name from the text box
                string ingredientName = IngredientNameTextBox.Text.Trim();
                // Check if the ingredient name is valid
                if (string.IsNullOrWhiteSpace(ingredientName))
                {
                    MessageBox.Show("Please enter a valid Ingredient name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Parse the calories value from the CaloriesTextBox
                if (!int.TryParse(CaloriesTextBox.Text, out int calories))
                {
                    MessageBox.Show("Please enter a valid Calories value.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Get the food group from the FoodGroupTextBox
                string foodGroup = FoodGroupTextBox.Text.Trim();
                // Check if the food group is valid
                if (string.IsNullOrWhiteSpace(foodGroup))
                {
                    MessageBox.Show("Please enter a valid Food group.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    // Create a new Ingredient object with the given values
                    Ingredient newIngredient = new Ingredient(ingredientName, calories, foodGroup);
                    // Add the new ingredient to the selected recipe
                    selectedRecipe.AddIngredient(newIngredient);

                    // Update the steps for the selected recipe
                    selectedRecipe.Steps = selectedRecipe.Steps ?? new List<string>();
                    selectedRecipe.Steps.AddRange(StepsTextBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

                    // Update the IngredientListBox to display the ingredients of the selected recipe
                    IngredientListBox.ItemsSource = selectedRecipe.Ingredients;
                    // Update the total calories for the selected recipe
                    UpdateTotalCalories(selectedRecipe);
                    // Clear the text boxes for ingredient input
                    IngredientNameTextBox.Clear();
                    CaloriesTextBox.Clear();
                    FoodGroupTextBox.Clear();
                    StepsTextBox.Clear();
                }
                catch (Exception)
                {
                    // Display an error message if an exception occurs while adding the ingredient
                    MessageBox.Show("Error has occured please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    // Clear the text boxes for ingredient input and recipe name
                    IngredientNameTextBox.Clear();
                    CaloriesTextBox.Clear();
                    FoodGroupTextBox.Clear();
                    RecipeNameTextBox.Clear();
                }
            }
        }
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected recipe from the RecipeListBox
            Recipe selectedRecipe = RecipeListBox.SelectedItem as Recipe;
            // Check if a recipe is selected
            if (selectedRecipe != null)
            {
                // Get the step from the StepsTextBox
                string step = StepsTextBox.Text.Trim();
                // Check if the step is valid
                if (string.IsNullOrWhiteSpace(step))
                {
                    MessageBox.Show("Please enter a valid Step.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Add the step to the selected recipe
                selectedRecipe.AddStep(step);
                // Update the StepsListBox to display the steps of the selected recipe
                StepsListBox.ItemsSource = selectedRecipe.Steps;
                // Clear the text box for step input
                StepsTextBox.Clear();
            }
        }


        private void UpdateTotalCalories(Recipe recipe)
        {
            // Calculate the total calories for the recipe by summing the calories of all ingredients
            int totalCalories = recipe.Ingredients.Sum(i => i.Calories);
            // Update the TotalCalories property of the recipe
            recipe.TotalCalories = totalCalories;
            // Update the TotalCaloriesLabel to display the new total calories
            TotalCaloriesLabel.Content = $"Total Calories: {totalCalories}";
            // Display a warning message if the total calories exceed 300
            if (totalCalories > 300)
            {
                MessageBox.Show("Caution: This recipe exceeds 300 calories!", "Calorie Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        

        private void IngredientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // This event handler is triggered when the selection in the IngredientListBox changes
            // You can add any necessary logic here if needed
        }
    }

    public class Recipe : INotifyPropertyChanged
    {
        private string name;
        private List<Ingredient> ingredients;
        
        private int totalCalories;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                NotifyPropertyChanged("Ingredients");
            }
        }
        public List<string> Steps { get; set; }

        public int TotalCalories
        {
            get { return totalCalories; }
            set
            {
                totalCalories = value;
                NotifyPropertyChanged("TotalCalories");
            }
        }

        public Recipe(string name)
        {
           
            Name = name;
            Ingredients = new List<Ingredient>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }
        public void AddStep(string step)
        {
            Steps.Add(step);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, int calories, string foodGroup)
        {
            Name = name;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}