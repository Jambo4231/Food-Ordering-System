using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System
{
    class Customer
    {
        private static int nextCustomerId = 0;

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int CustomerId { get; set; }

        public List<string> OrderHistory { get; set; }

        public Customer(string name, string phonenumber, string address)
        {
            Name = name;
            PhoneNumber = phonenumber;
            Address = address;
            CustomerId = nextCustomerId++;
            OrderHistory = new List<string>();

        }
    }
    class CustomerManager

    {
        public List<Customer> customers;
        public CustomerManager()
        {
            customers = new List<Customer>();
        }
        public void RegisterCustomer(string name, string phonenumber, string address)
        {
            Customer newCustomer = new Customer(name, phonenumber, address);
            customers.Add(newCustomer);
        }
        public void RemoveCustomer(string name)
        {
            int customerToRemove = -1;

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Name == name)
                {
                    customerToRemove = i;
                    break;
                }
            }
            if (customerToRemove != -1)
            {
                customers.RemoveAt(customerToRemove);
                Console.WriteLine($"Customer '{name}' removed successfully");
            }
            else
            {
                Console.WriteLine($"Customer '{name}' not found");
            }
        }
        public void FindCustomer(string name)

        {
            bool found = false;
            while (!found)
            {

                int customerToFind = -1;

                for (int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].Name == name)
                    {
                        customerToFind = i;
                        break;
                    }
                }
                if (customerToFind != -1)
                {
                    found = true;
                    Console.WriteLine($"Customer '{name}' found successfully");
                }
                else
                {
                    Console.WriteLine($"Customer '{name}' not found");
                }
            }
        }
        public void UpdateCustomer(string name)
        {
            int customerToUpdate = -1;

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Name == name)
                {
                    customerToUpdate = i;
                    break;
                }
            }
            if (customerToUpdate != -1)
            {
                Console.WriteLine($"Customer'{name}' found.\n");
                while (true)
                {
                    Console.WriteLine("1. Change name");
                    Console.WriteLine("2. Change phone number");
                    Console.WriteLine("3. Change address");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice (1-4): ");
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("You selected Option 1.\n");
                            Console.WriteLine($"'{name}' is the name of the customer\nPlease enter an alternative name.");
                            customers[customerToUpdate].Name = Console.ReadLine();
                            Console.WriteLine($"Name updated successfully.");
                            break;

                        case "2":
                            Console.WriteLine("You selected Option 2.\n");
                            Console.WriteLine($"The phone number of '{name}' is : {customers[customerToUpdate].PhoneNumber}\nPlease enter an alternative phone number.");
                            customers[customerToUpdate].PhoneNumber = Console.ReadLine();
                            Console.WriteLine($"Phone number updated successfully.");
                            break;

                        case "3":
                            Console.WriteLine("You selected Option 3.\n");
                            Console.WriteLine($"The address of '{name}' is {customers[customerToUpdate].Address}\nPlease enter an alternative address.");
                            customers[customerToUpdate].Address = Console.ReadLine();
                            Console.WriteLine($"Address updated successfully.");
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

        }
    }
}
