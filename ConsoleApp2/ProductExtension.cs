using System;

namespace ConsoleApp2
{
    public static class ProductExtension
    {
        public static void Display(this Product p, Product product)
        {
            Console.WriteLine($"{product.Name}");
        }
    }
}