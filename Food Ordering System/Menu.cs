using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Food_Ordering_System
{
    class Menu
    {

        private List<MenuItem> items;
        public Menu()
        {
            items = new List<MenuItem>();
        }
        public void AddMenuItem(string name, string description, float price, string category)
        {
            MenuItem newItem = new MenuItem(name, description, price, category);
            items.Add(newItem);
        }
        public void RemoveMenuItem(string name)
        {
            int itemToRemove = -1;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    itemToRemove = i;
                    break;
                }
            }
            if (itemToRemove != -1)
            {
                items.RemoveAt(itemToRemove);
                Console.WriteLine($"Menu item '{name}' removed successfully");
            }
            else
            {
                Console.WriteLine($"Menu item '{name}' not found");
            }
        }
        public void UpdateMenuItem(string name)
        {
            int itemToUpdate = -1;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    itemToUpdate = i;
                    break;
                }
            }
            if (itemToUpdate != -1)
            {
                Console.WriteLine($"Menu item '{name}' found.\n");
                while (true)
                {
                    Console.WriteLine("1. Change description");
                    Console.WriteLine("2. Change price");
                    Console.WriteLine("3. Change category");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice (1-4): ");
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("You selected Option 1.\n");
                            Console.WriteLine($"The description of '{name}' is : {items[itemToUpdate].Description}\nPlease enter an alternative description.");
                            items[itemToUpdate].Description = Console.ReadLine();
                            Console.WriteLine($"Description updated successfully.");
                            break;

                        case "2":
                            Console.WriteLine("You selected Option 2.\n");
                            Console.WriteLine($"The price of '{name}' is : {items[itemToUpdate].Price}\nPlease enter an alternative price.");

                            while (true)
                            {
                                if (float.TryParse(Console.ReadLine(), out float newPrice))
                                {
                                    items[itemToUpdate].Price = newPrice;
                                    Console.WriteLine($"Price updated successfully.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for price. Please enter a valid number.");
                                }
                            }
                            break;

                        case "3":
                            Console.WriteLine("You selected Option 3.\n");
                            Console.WriteLine($"The category of '{name}' is {items[itemToUpdate].Category}\nPlease enter an alternative category.");
                            items[itemToUpdate].Category = Console.ReadLine();
                            Console.WriteLine($"Category updated successfully.");
                            break;

                        case "4":
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.\n");
                            break;
                    }
                }


            }
            else
            {
                Console.WriteLine($"Menu item '{name}' not found.");
            }
        }
        public void displayMenu()
        {

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"Name: {items[i].Name}");
                Console.WriteLine($"Price: {items[i].Price}");
                Console.WriteLine($"Description: {items[i].Description}");
                Console.WriteLine($"Category: {items[i].Category}\n");
            }
        }
        public MenuItem GetMenuItemByName(string itemName)
        {
            return items.FirstOrDefault(item => item.Name == itemName);
        }
    }
}


