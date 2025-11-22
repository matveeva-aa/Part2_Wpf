using System;

namespace Task_8_1
{
    public enum ProductCategory
    {
        Food,
        Appliances
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public ProductCategory Category { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Price} ₽, {Category})";
        }
    }
}
