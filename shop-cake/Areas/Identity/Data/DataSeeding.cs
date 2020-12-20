using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake.Models;
using shop_cake.Data;
using shop_cake.Extensions;

namespace shop_cake.Data
{
    public class DataSeeding
    {
        private readonly ShopCakeDBContext context;

        public DataSeeding(ShopCakeDBContext _context)
        {
            context = _context;
        }

        private DataSeeding()
        {

        }

        public void SeedData()
        {
            SeedNew();
            SeedSlide();
            SeedCustomer();
            SeedBill();
            SeedTypeProducts();
        }

        private void SeedTypeProducts()
        {
            if (context != null)
            {
                if (!context.TypeProducts.Any())
                {
                    List<TypeProduct> typeProducts = new List<TypeProduct>()
                    {
                        new TypeProduct(
                            name: "Bánh mặn",
                            description: "Nếu từng bị mê hoặc bởi các loại tarlet ngọt thì chắn chắn bạn không thể bỏ qua những loại tarlet mặn. Ngoài hình dáng bắt mắt, lớp vở bánh giòn giòn cùng với nhân mặn như thịt gà, nấm, thị heo ,… của bánh sẽ chinh phục bất cứ ai dùng thử.",
                            image: "banh-man-thu-vi-nhat-1.jpg"),
                        new TypeProduct(
                            name: "Bánh ngọt",
                            description: "Bánh ngọt là một loại thức ăn thường dưới hình thức món bánh dạng bánh mì từ bột nhào, được nướng lên dùng để tráng miệng. Bánh ngọt có nhiều loại, có thể phân loại dựa theo nguyên liệu và kỹ thuật chế biến như bánh ngọt làm từ lúa mì, bơ, bánh ngọt dạng bọt biển. Bánh ngọt có thể phục vụ những mục đính đặc biệt như bánh cưới, bánh sinh nhật, bánh Giáng sinh, bánh Halloween..",
                            image: "20131108144733.jpg"),
                        new TypeProduct(
                            name: "Bánh trái cây",
                            description: "Bánh trái cây, hay còn gọi là bánh hoa quả, là một món ăn chơi, không riêng gì của Huế nhưng khi 'lạc' vào mảnh đất Cố đô, món bánh này dường như cũng mang chút tinh tế, cầu kỳ và đặc biệt. Lấy cảm hứng từ những loại trái cây trong vườn, qua bàn tay khéo léo của người phụ nữ Huế, món bánh trái cây ra đời - ngọt thơm, dịu nhẹ làm đẹp lòng biết bao người thưởng thức.",
                            image: "banhtraicay.jpg"),
                        new TypeProduct(
                            name: "Bánh kem",
                            description: "Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem. Tuy nhiên, cốt bánh kem thực ra có rất nhiều loại với hương vị, kết cấu và phương thức làm khác nhau chứ không chỉ đơn giản là “bánh bông lan” chung chung đâu nhé!",
                            image: "banhkem.jpg"),
                        new TypeProduct(
                            name: "Bánh crepe",
                            description: @"Crepe là một món bánh nổi tiếng của Pháp, nhưng từ khi du nhập vào Việt Nam món bánh đẹp mắt, ngon miệng này đã làm cho biết bao bạn trẻ phải “xiêu lòng”",
                            image: "crepe.jpg"),
                        new TypeProduct(
                            name: "Bánh Pizza",
                            description: "Pizza đã không chỉ còn là một món ăn được ưa chuộng khắp thế giới mà còn được những nhà cầm quyền EU chứng nhận là một phần di sản văn hóa ẩm thực châu Âu. Và để được chứng nhận là một nhà sản xuất pizza không hề đơn giản. Người ta phải qua đủ mọi các bước xét duyệt của chính phủ Ý và liên minh châu Âu nữa… tất cả là để đảm bảo danh tiếng cho món ăn này.",
                            image: "pizza.jpg"),
                        new TypeProduct(
                            name: "Bánh su kem",
                            description: "Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... đánh đều tạo thành một hỗn hợp và sau đó bằng thao tác ép và phun qua một cái túi để định hình thành những bánh nhỏ và cuối cùng được nướng chín. Bánh su kem có thể thêm thành phần Sô cô la để tăng vị hấp dẫn. Bánh có xuất xứ từ nước Pháp.",
                            image: "sukemdau.jpg")
                    };
                    context.TypeProducts.AddRange(typeProducts);
                    context.SaveChanges();
                }
            }
        }

        private void SeedBill()
        {
            if (context != null)
            {
                if (!context.Bills.Any())
                {
                    Random r = new Random();
                    var cusomters = context.Customers.Select(x => x.ID).ToArray();
                    List<Bill> bills = new List<Bill>();
                    for (int i = 0; i < 5; i++)
                    {
                        bills.Add(new Bill(
                            dateOrder: DateTime.Now.AddDays(-1 * r.Next(0, 12)),
                            total: Math.Round(r.NextDouble() * r.Next(100000, 100000)),
                            payment: "COD",
                            note: "",
                            iDCustomer: cusomters[r.Next(0, cusomters.Length)]
                            ));
                    }
                    context.Bills.AddRange(bills);
                    context.SaveChanges();
                }
            }
        }

        private void SeedSlide()
        {
            if (context != null)
            {
                if (!context.Slides.Any())
                {
                    List<Slide> slides = new List<Slide>()
                    {
                        new Slide() { Image = "banner1.jpg", Link = "" },
                        new Slide() { Image = "banner2.jpg", Link = "" },
                        new Slide() { Image = "banner3.jpg", Link = "" },
                        new Slide() { Image = "banner4.jpg", Link = "" }
                    };

                    context.Slides.AddRange(slides);
                    context.SaveChanges();
                }
            }
        }

        private void SeedNew()
        {
            if (context != null)
            {
                if (!context.News.Any())
                {
                    List<New> news = new List<New>()
                {
                    new New()
                    {
                        Content = "Những ý tưởng dưới đây sẽ giúp bạn sắp xếp tủ quần áo trong phòng ngủ chật hẹp của mình một cách dễ dàng và hiệu quả nhất. ",
                        Image = "sample1.jpg" ,
                        Title = "Những ý tưởng dưới đây sẽ giúp bạn sắp xếp tủ quần áo trong phòng ngủ chật hẹp của mình một cách dễ dàng và hiệu quả nhất."
                    },
                    new New(){
                        Content = "Chúng tôi sẽ tư vấn cải tạo và bố trí nội thất để giúp phòng ngủ của chàng trai độc thân thật thoải mái, thoáng mát và sáng sủa nhất. ",
                        Title = "Tư vấn cải tạo phòng ngủ nhỏ sao cho thoải mái và thoáng mát" ,
                        Image = "sample2.jpg"
                    },
                    new New()
                    {
                        Title = "Đồ gỗ nội thất và nhu cầu, xu hướng sử dụng của người dùng",
                        Content = "Đồ gỗ nội thất ngày càng được sử dụng phổ biến nhờ vào hiệu quả mà nó mang lại cho không gian kiến trúc. Xu thế của các gia đình hiện nay là muốn đem thiên nhiên vào nhà",
                        Image = "sample3.jpg"
                    },
                    new New()
                    {
                        Title = "Hướng dẫn sử dụng bảo quản đồ gỗ, nội thất.",
                        Content = "Ngày nay, xu hướng chọn vật dụng làm bằng gỗ để trang trí, sử dụng trong văn phòng, gia đình được nhiều người ưa chuộng và quan tâm. Trên thị trường có nhiều sản phẩm mẫu",
                        Image = "sample4.jpg"
                    },
                    new New()
                    {
                        Title = "Phong cách mới trong sử dụng đồ gỗ nội thất gia đình",
                        Content = "Đồ gỗ nội thất gia đình ngày càng được sử dụng phổ biến nhờ vào hiệu quả mà nó mang lại cho không gian kiến trúc. ",
                        Image = "sample5.jpg"
                    }
                };
                    context.News.AddRange(news);
                    context.SaveChanges();
                }
            }
        }

        private void SeedCustomer()
        {
            if (context != null)
            {
                if (!context.Customers.Any())
                {
                    List<Customer> customers = new List<Customer>();
                    for (int i = 0; i < 10; i++)
                    {
                        customers.Add(RandomCustomer.GetCustomer());
                    }
                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                }
            }
        }
    }
}