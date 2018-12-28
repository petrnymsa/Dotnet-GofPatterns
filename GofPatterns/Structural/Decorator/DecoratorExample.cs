using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GofPatterns.Structural.Decorator
{
    // Component
    abstract class Item
    {
        public int CopiesTotal { get; set; }

        public abstract void Display();
    }

    // Concrete component
    class Book : Item
    {
        public string Title { get; set; }

        public override void Display()
        {
            Console.WriteLine($"Book: {Title}");
        }
    }

    // Decorator
    abstract class LibraryDecorator : Item
    {
        protected Item Item;

        protected LibraryDecorator(Item item)
        {
            Item = item;
        }

        public override void Display()
        {
           Item.Display();
        }
    }

    // concrete decorator
    class Borrowable : LibraryDecorator
    {
        private List<string> customers = new List<string>();

        public Borrowable(Item item) : base(item)
        {
        }

        public bool Borrow(string name)
        {
            if (Item.CopiesTotal == 0)
                return false;

            Item.CopiesTotal--;
            customers.Add(name);

            return true;
        }

        public void Return(string name)
        {
            var cust = customers.FirstOrDefault(x => x.Equals(name));

            if(cust == null)
                return;

            Item.CopiesTotal++;
            customers.Remove(cust);
        }

        public override void Display()
        {
            base.Display();

            foreach (var customer in customers)
            {
                Console.WriteLine($" customer: {customer}");
            }
        }
    }

    // client
    public class DecoratorExample
    {
        public void Example()
        {
            var lotr = new Book() {CopiesTotal = 5, Title = "LOTR"};
            var hp = new Book() {CopiesTotal = 4, Title = "HP 1"};

            lotr.Display();
            hp.Display();

            // borrow lotr
            var borrowedLotr = new Borrowable(lotr);
            borrowedLotr.Borrow("Jack");
            borrowedLotr.Borrow("Peter");

            borrowedLotr.Display();
        }
    }
}
