using Food_Ordering_System;
using System;
using System.Collections.Generic;

class Order
{
    private static int nextOrderId = 0;
    private static List<Customer> customers = new List<Customer>();



    public int OrderId { get; private set; }
    public Customer Customer { get; private set; }
    public List<MenuItem> OrderedItems { get; private set; }
    public DateTime OrderDate { get; private set; }

    public Order(Customer customer, List<MenuItem> orderedItems)
    {
        OrderId = nextOrderId++;
        Customer = customer;
        OrderedItems = orderedItems;
        OrderDate = DateTime.Now;
    }
    private bool CustomerExists(string customerName)
    {
        foreach (Customer customer in customers)
        {
            if (customer.Name == customerName)
            {
                return true;
            }
        }
        return false;
    }
    public void PlaceOrder(string name, string customerName)

    {
        Console.WriteLine("Please enter the customer's name");
        customerName = Console.ReadLine();
        if (CustomerExists(customerName))
        {

            Console.WriteLine("Please select items from the menu");
            Menu menu = new Menu();

            menu.displayMenu();

            OrderedItems = new List<MenuItem>();
            {

                while (true)
                {
                    Console.WriteLine("1. Select item");
                    Console.WriteLine("2. Remove item");
                    Console.WriteLine("3. Place order");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice (1-4): ");
                    string userInput = Console.ReadLine();


                    switch (userInput)
                    {
                        case "1":
                            {
                                int itemToSelect = -1;

                                Console.WriteLine("Enter the name of the item to select:");
                                name = Console.ReadLine();

                                MenuItem selectedMenuItem = menu.GetMenuItemByName(name);


                                if (selectedMenuItem != null)
                                {
                                    OrderedItems.Add(selectedMenuItem);
                                    Console.WriteLine($"Menu item '{name}' selected successfully");
                                }
                                else
                                {
                                    Console.WriteLine($"Menu item '{name}' not found");
                                }
                                break;
                            }
                        case "2":
                            {
                                int itemToRemove = -1;

                                Console.WriteLine("Enter the name of the item to remove:");
                                name = Console.ReadLine();

                                for (int i = 0; i < OrderedItems.Count; i++)
                                {
                                    if (OrderedItems[i].Name == name)
                                    {
                                        itemToRemove = i;
                                        break;
                                    }
                                }
                                if (itemToRemove != -1)
                                {
                                    OrderedItems.RemoveAt(itemToRemove);
                                    Console.WriteLine($"Menu item '{name}' removed successfully");
                                }
                                else
                                {
                                    Console.WriteLine($"Menu item '{name}' not found");
                                }
                            }
                            break;

                        case "3":
                            {
                                bool isValidInput = false;

                                do
                                {
                                    Console.WriteLine("Are you sure you want to place your order? y/n");
                                    string userConfirmation = Console.ReadLine();

                                    if (userConfirmation.ToLower() == "y")
                                    {
                                        List<MenuItem> orderedItems = OrderedItems;

                                        Order order = new Order(customers.Find(cust => cust.Name == customerName), OrderedItems);
                                    }
                                    else if (userConfirmation.ToLower() == "n")
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine($"Please choose y or n");
                                    }

                                } while (isValidInput);

                            }
                            break;
                        case "4":
                            {

                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;

                    }
                }

            }
        }
        else
        {
            Console.WriteLine($"Customer with name '{customerName}' does not exist");
        }
    }
}
