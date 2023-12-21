using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System
{
    class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }

        public MenuItem(string name, string description, float price, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;

        }
    }
}


    
