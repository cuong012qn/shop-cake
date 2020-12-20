namespace shop_cake.Extensions
{
    using shop_cake.Models;
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
