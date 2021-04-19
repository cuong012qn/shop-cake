namespace shop_cake_API.Extensions
{
    using shop_cake_API.Models;
    using System;

    public class RandomCustomer
    {
        public static Customer GetCustomer()
        {
            Random r = new Random();
            RandomName rn = new RandomName(r);
            Sex EnumSex = (Sex)r.Next(0, 2);
            string name = rn.Generate(EnumSex, r.Next(0, 3));
            return new Customer(name, EnumSex.ToString(), name.Replace(" ", "") + "@gmail.com", "", "", "");
        }
    }
}
