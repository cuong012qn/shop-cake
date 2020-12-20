use [shop-cake]
go

select * from Customer
select * from Bills

select * from Product
select * from TypeProduct

SET IDENTITY_INSERT dbo.Product ON;  
INSERT INTO Product (ID, Name, IDType, Description, UnitPrice, PromotionPrice,Image, Unit, New , CreateAt, UpdateAt) VALUES
(1, 'Bánh Crepe Sầu riêng', 5, 'Bánh crepe sầu riêng nhà làm', 150000, 120000, '1430967449-pancake-sau-rieng-6.jpg', 'hộp', 1, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(2, 'Bánh Crepe Chocolate', 6, '', 180000, 160000, 'crepe-chocolate.jpg', 'hộp', 1, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(3, 'Bánh Crepe Sầu riêng - Chuối', 5, '', 150000, 120000, 'crepe-chuoi.jpg', 'hộp', 0, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(4, 'Bánh Crepe Đào', 5, '', 160000, 0, 'crepe-dao.jpg', 'hộp', 0, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(5, 'Bánh Crepe Dâu', 5, '', 160000, 0, 'crepedau.jpg', 'hộp', 0, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(6, 'Bánh Crepe Pháp', 5, '', 200000, 180000, 'crepe-phap.jpg', 'hộp', 0, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(7, 'Bánh Crepe Táo', 5, '', 160000, 0, 'crepe-tao.jpg', 'hộp', 1, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(8, 'Bánh Crepe Trà xanh', 5, '', 160000, 150000, 'crepe-traxanh.jpg', 'hộp', 0, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(9, 'Bánh Crepe Sầu riêng và Dứa', 5, '', 160000, 150000, 'saurieng-dua.jpg', 'hộp', 0, '2016-10-26 03:00:16', '2016-10-24 22:11:00'),
(11, 'Bánh Gato Trái cây Việt Quất', 3, '', 250000, 0, '544bc48782741.png', 'cái', 0, '2016-10-12 02:00:00', '2016-10-27 02:24:00'),
(12, 'Bánh sinh nhật rau câu trái cây', 3, '', 200000, 180000, '210215-banh-sinh-nhat-rau-cau-body- (6).jpg', 'cái', 0, '2016-10-12 02:00:00', '2016-10-27 02:24:00'),
(13, 'Bánh kem Chocolate Dâu', 3, '', 300000, 280000, 'banh kem sinh nhat.jpg', 'cái', 1, '2016-10-12 02:00:00', '2016-10-27 02:24:00'),
(14, 'Bánh kem Dâu III', 3, '', 300000, 280000, 'Banh-kem (6).jpg', 'cái', 0, '2016-10-12 02:00:00', '2016-10-27 02:24:00'),
(15, 'Bánh kem Dâu I', 3, '', 350000, 320000, 'banhkem-dau.jpg', 'cái', 1, '2016-10-12 02:00:00', '2016-10-27 02:24:00'),
(16, 'Bánh trái cây II', 3, '', 150000, 120000, 'banhtraicay.jpg', 'hộp', 0, '2016-10-12 02:00:00', '2016-10-27 02:24:00'),
(17, 'Apple Cake', 3, '', 250000, 240000, 'Fruit-Cake_7979.jpg', 'cai', 0, '2016-10-12 02:00:00', '2016-10-27 02:24:00'),
(18, 'Bánh ngọt nhân cream táo', 2, '', 180000, 0, '20131108144733.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(19, 'Bánh Chocolate Trái cây', 2, '', 150000, 0, 'Fruit-Cake_7976.jpg', 'hộp', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(20, 'Bánh Chocolate Trái cây II', 2, '', 150000, 0, 'Fruit-Cake_7981.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(21, 'Peach Cake', 2, '', 160000, 150000, 'Peach-Cake_3294.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(22, 'Bánh bông lan trứng muối I', 1, '', 160000, 150000, 'banhbonglantrung.jpg', 'hộp', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(23, 'Bánh bông lan trứng muối II', 1, '', 180000, 0, 'banhbonglantrungmuoi.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(24, 'Bánh French', 1, '', 180000, 0, 'banh-man-thu-vi-nhat-1.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(25, 'Bánh mì Australia', 1, '', 80000, 70000, 'dung-khoai-tay-lam-banh-gato-man-cuc-ngon.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(26, 'Bánh mặn thập cẩm', 1, '', 50000, 0, 'Fruit-Cake.png', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(27, 'Bánh Muffins trứng', 1, '', 100000, 80000, 'maxresdefault.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(28, 'Bánh Scone Peach Cake', 1, '', 120000, 0, 'Peach-Cake_3300.jpg', 'hộp', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(29, 'Bánh mì Loaf I', 1, '', 100000, 0, 'sli12.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(30, 'Bánh kem Chocolate Dâu I', 4, '', 380000, 350000, 'sli12.jpg', 'cái', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(31, 'Bánh kem Trái cây I', 4, '', 380000, 350000, 'Fruit-Cake.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(32, 'Bánh kem Trái cây II', 4, '', 380000, 350000, 'Fruit-Cake_7971.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(33, 'Bánh kem Doraemon', 4, '', 280000, 250000, 'p1392962167_banh74.jpg', 'cái', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(34, 'Bánh kem Caramen Pudding', 4, '', 280000, 0, 'Caramen-pudding636099031482099583.jpg', 'cái', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(35, 'Bánh kem Chocolate Fruit', 4, '', 320000, 300000, 'chocolate-fruit636098975917921990.jpg', 'cái', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(36, 'Bánh kem Coffee Chocolate GH6', 4, '', 320000, 300000, 'COFFE-CHOCOLATE636098977566220885.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(37, 'Bánh kem Mango Mouse', 4, '', 320000, 300000, 'mango-mousse-cake.jpg', 'cái', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(38, 'Bánh kem Matcha Mouse', 4, '', 350000, 330000, 'MATCHA-MOUSSE.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(39, 'Bánh kem Flower Fruit', 4, '', 350000, 330000, 'flower-fruits636102461981788938.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(40, 'Bánh kem Strawberry Delight', 4, '', 350000, 330000, 'strawberry-delight636102445035635173.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(41, 'Bánh kem Raspberry Delight', 4, '', 350000, 330000, 'raspberry.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(42, 'Beefy Pizza', 6, 'Thịt bò xay, ngô, sốt BBQ, phô mai mozzarella', 150000, 130000, '40819_food_pizza.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(43, 'Hawaii Pizza', 6, 'Sốt cà chua, ham , dứa, pho mai mozzarella', 120000, 0, 'hawaiian paradise_large-900x900.jpg', 'cái', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(44, 'Smoke Chicken Pizza', 6, 'Gà hun khói,nấm, sốt cà chua, pho mai mozzarella.', 120000, 0, 'chicken black pepper_large-900x900.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(45, 'Sausage Pizza', 6, 'Xúc xích klobasa, Nấm, Ngô, sốtcà chua, pho mai Mozzarella.', 120000, 0, 'pizza-miami.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(46, 'Ocean Pizza', 6, 'Tôm , mực, xào cay,ớt xanh, hành tây, cà chua, phomai mozzarella.', 120000, 0, 'seafood curry_large-900x900.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(47, 'All Meaty Pizza', 6, 'Ham, bacon, chorizo, pho mai mozzarella.', 140000, 0, 'all1).jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(48, 'Tuna Pizza', 6, 'Cá Ngừ, sốt Mayonnaise,sốt càchua, hành tây, pho mai Mozzarella', 140000, 0, '54eaf93713081_-_07-germany-tuna.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(49, 'Bánh su kem nhân dừa', 7, '', 120000, 100000, 'maxresdefault.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(50, 'Bánh su kem sữa tươi', 7, '', 120000, 100000, 'sukem.jpg', 'cái', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(51, 'Bánh su kem sữa tươi chiên giòn', 7, '', 150000, 0, '1434429117-banh-su-kem-chien-20.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(52, 'Bánh su kem dâu sữa tươi', 7, '', 150000, 0, 'sukemdau.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(53, 'Bánh su kem bơ sữa tươi', 7, '', 150000, 0, 'He-Thong-Banh-Su-Singapore-Chewy-Junior.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(54, 'Bánh su kem nhân trái cây sữa tươi', 7, '', 150000, 0, 'foody-banh-su-que-635930347896369908.jpg', 'hộp', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(55, 'Bánh su kem cà phê', 7, '', 150000, 0, 'banh-su-kem-ca-phe-1.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(56, 'Bánh su kem phô mai', 7, '', 150000, 0, '50020041-combo-20-banh-su-que-pho-mai-9.jpg', 'hộp', 0, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(57, 'Bánh su kem sữa tươi chocolate', 7, '', 150000, 0, 'combo-20-banh-su-que-kem-sua-tuoi-phu-socola.jpg', 'hộp', 1, '2016-10-13 02:20:00', '2016-10-19 03:20:00'),
(58, 'Bánh Macaron Pháp', 2, 'Thưởng thức macaron, người ta có thể tìm thấy từ những hương vị truyền thống như mâm xôi, chocolate, cho đến những hương vị mới như nấm và trà xanh. Macaron với vị giòn tan của vỏ bánh, béo ngậy ngọt ngào của phần nhân, với vẻ ngoài đáng yêu và nhiều màu sắc đẹp mắt, đây là món bạn không nên bỏ qua khi khám phá nền ẩm thực Pháp.', 200000, 180000, 'Macaron9.jpg', '', 0, '2016-10-26 17:00:00', '2016-10-11 17:00:00'),
(59, 'Bánh Tiramisu - Italia', 2, 'Chỉ cần cắn một miếng, bạn sẽ cảm nhận được tất cả các hương vị đó hòa quyện cùng một chính vì thế người ta còn ví món bánh này là Thiên đường trong miệng của bạn', 200000, 0, '234.jpg', '', 0, '2016-10-26 17:00:00', '2016-10-11 17:00:00'),
(60, 'Bánh Táo - Mỹ', 2, 'Bánh táo Mỹ với phần vỏ bánh mỏng, giòn mềm, ẩn chứa phần nhân táo thơm ngọt, điểm chút vị chua dịu của trái cây quả sẽ là một lựa chọn hoàn hảo cho những tín đồ bánh ngọt trên toàn thế giới.', 200000, 0, '1234.jpg', '', 0, '2016-10-26 17:00:00', '2016-10-11 17:00:00'),
(61, 'Bánh Cupcake - Anh Quốc', 6, 'Những chiếc cupcake có cấu tạo gồm phần vỏ bánh xốp mịn và phần kem trang trí bên trên rất bắt mắt với nhiều hình dạng và màu sắc khác nhau. Cupcake còn được cho là chiếc bánh mang lại niềm vui và tiếng cười như chính hình dáng đáng yêu của chúng.', 150000, 120000, 'cupcake.jpg', 'cái', 1, NULL, NULL),
(62, 'Bánh Sachertorte', 6, 'Sachertorte là một loại bánh xốp được tạo ra bởi loại&nbsp;chocholate&nbsp;tuyệt hảo nhất của nước Áo. Sachertorte có vị ngọt nhẹ, gồm nhiều lớp bánh được làm từ ruột bánh mì và bánh sữa chocholate, xen lẫn giữa các lớp bánh là mứt mơ. Món bánh chocholate này nổi tiếng tới mức thành phố Vienna của Áo đã ấn định&nbsp;tổ chức một ngày Sachertorte quốc gia, vào 5/12 hằng năm', 250000, 220000, '111.jpg', 'cái', 0, NULL, NULL);
SET IDENTITY_INSERT dbo.Product OFF;  

INSERT INTO BillDetail(IDBill, IDProduct, Quantity, UnitPrice) VALUES
(1, 62, 5, 220000),
(2, 2, 1, 160000),
(3, 60, 1, 200000),
(4, 59, 1, 200000),
(5, 60, 2, 200000),
(2, 61, 1, 120000),
(3, 61, 1, 120000);