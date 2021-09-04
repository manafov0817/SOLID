using SOLID.Models;
using System;
using static System.Console;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            //var j = new Journal();
            //j.AddEntry("I cried today."); 
            //j.AddEntry("I ate a bug.");

            //var apple = new Product("Apple", Color.Green, Size.Small);
            //var tree = new Product("Tree", Color.Green, Size.Large);
            //var house = new Product("House", Color.Blue, Size.Large);

            //Product[] products = { apple, tree, house };

            //var bf = new BetterFilter();

            //var pf = new ProductFilter();

            //WriteLine("Green products:");

            ////foreach (var p in pf.FilterByColor(products, Color.Green))
            ////    WriteLine($" - {p.Name} is green");


            //ColorSpecification colorSpecification = new ColorSpecification(Color.Blue);
            //SizeSpecification sizeSpecification = new SizeSpecification(Size.Large);

            ////var largeGreenSpec = colorSpecification & sizeSpecification;

            //var largeGreenSpec = Color.Green.And(Size.Large);          

            //foreach (var p in bf.Filter(products, largeGreenSpec))
            //{
            //    WriteLine($"{p.Name} is large and green");
            //}

            var rc = new Rectangle(2, 3);

            UseIt(rc);

            var sq = new Square(5);
            UseIt(sq);
            // Expected area of 50, got 100
        }
        public static void UseIt(Rectangle r)
        {
            r.Height = 10;

            WriteLine($"Expected area of {10 * r.Width}, got {r.Area}");
        }
    }
}
