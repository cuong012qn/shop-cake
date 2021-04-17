using Microsoft.EntityFrameworkCore;
using shop_cake.Areas.Admin.ViewModels;
using shop_cake.Data;
using shop_cake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake.Extensions
{
    public class OrderHelper
    {
        public static async Task SetOrder(ShopCakeDBContext context, List<Product> products, Customer customer)
        {
            //Get total of products
            //If Promotion Price != 0 sum += Quantity * Promotion Price or otherwise
            double total = products.Sum(
                x => x.PromotionPrice != 0 ? x.PromotionPrice : x.UnitPrice * x.Quantity);

            //Save customer
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            //Create bil
            var bill = new Bill(DateTime.Now, total, "Momo", customer.Note, customer.ID);

            //Save bill
            context.Bills.Add(bill);
            await context.SaveChangesAsync();

            //Add bill details
            foreach (Product item in products)
            {
                context.BillDetails.Add(new BillDetail()
                {
                    IDProduct = item.ID,
                    IDBill = bill.ID,
                    Quantity = item.Quantity,
                    UnitPrice = item.PromotionPrice != 0 ? item.PromotionPrice : item.UnitPrice
                });
            }

            await context.SaveChangesAsync();
        }

        public static async Task<OrderViewModel> GetOrder(int idBill, ShopCakeDBContext context)
        {
            OrderViewModel order = new OrderViewModel();
            List<BillDetail> getBillDetail = await context.BillDetails
                .Include(bill => bill.Bill)
                .ThenInclude(customer => customer.Customer)
                .Include(product => product.Product)
                .Where(x => x.IDBill.Equals(idBill))
                .ToListAsync();

            order.IDBill = idBill;
            order.Customer = getBillDetail.First().Bill.Customer;
            order.Bill = getBillDetail.First().Bill;
            order.BillDetail = getBillDetail;
            return order;
        }
    }
}
