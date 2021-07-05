using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webtt.Models;

namespace Webtt.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<News> Newss { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Dụng Cụ Chuyên Khoa"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Dụng Cụ Tập Đi"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Dụng Cụ Thẩm Mỹ"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Dụng Cụ Trị Liệu"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Dụng Cụ Y Tế INOX"
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Đai Nẹp Y Tế"
                },
                new Category()
                {
                    CategoryId = 7,
                    CategoryName = "Đèn Y Khoa"
                },
                new Category()
                {
                    CategoryId = 8,
                    CategoryName = "Máy Móc Y Khoa"
                },
                new Category()
                {
                    CategoryId = 9,
                    CategoryName = "Mẹ và Bé"
                },
                new Category()
                {
                    CategoryId = 10,
                    CategoryName = "Trang Thiết Bị Y Khoa"
                },
                new Category()
                {
                    CategoryId = 11,
                    CategoryName = "Vật Tư Y Tế Tiêu Hao"
                },
                new Category()
                {
                    CategoryId = 12,
                    CategoryName = "Vớ Y Khoa-Vớ Giãn Tĩnh Mạch"
                },
                new Category()
                {
                    CategoryId = 13,
                    CategoryName = "Sản Phẩm Mới"
                }
            );
            builder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Xe Tiêm 30*40 2 tầng hai vòng thâu",
                    ProductImage = "xe-tiem-thuoc-30x40-2-tang1561266976.jpg",
                    ProductPrice = 500.000,
                    CategoryId = 13,
                    Description = "Xe tiện dụng"
                },
                 new Product()
                 {
                     ProductId = 2,
                     ProductName = "Máy đo thân nhiệt",
                     ProductImage = "chuyenkhoa.jpg",
                     ProductPrice = 250.000,
                     CategoryId = 1,
                     Description = "Máy đo thân nhiệt thế hệ mới"
                 },
                 new Product()
                 {
                     ProductId = 3,
                     ProductName = "Xe tập đi",
                     ProductImage = "tapdi.jpg",
                     ProductPrice = 700.000,
                     CategoryId = 2,
                     Description = "Dụng cụ tập đi cho những người bị tật"
                 },
                 new Product()
                 {
                     ProductId = 4,
                     ProductName = "Máy thẩm mỹ",
                     ProductImage = "thammy.jpg",
                     ProductPrice = 1205.000,
                     CategoryId = 3,
                     Description = "Bộ trang thiết bị thẩm mỹ hiện đại nhất"
                 },
                 new Product()
                 {
                     ProductId = 5,
                     ProductName = "Ghế Gập Tay-Chân",
                     ProductImage = "trịlieu.jpg",
                     ProductPrice = 2400.000,
                     CategoryId = 4,
                     Description = "Ghế Gập Tay-Chân(Ba trong Một)"
                 },
                 new Product()
                 {
                     ProductId = 6,
                     ProductName = "Hộp đựng dụng cụ Inox",
                     ProductImage = "inox.jpg",
                     ProductPrice = 50.000,
                     CategoryId = 5,
                     Description = "Dùng để đựng dụng cụ y tế"
                 },
                 new Product()
                 {
                     ProductId = 7,
                     ProductName = "Đai nẹp cổ",
                     ProductImage = "dainep.jpg",
                     ProductPrice = 460.000,
                     CategoryId = 6,
                     Description = "Đai nẹp cổ thoáng khí Breathable Neck support"
                 },
                 new Product()
                 {
                     ProductId = 8,
                     ProductName = "Đèn Hồng Ngoại y Tế",
                     ProductImage = "den.jpg",
                     ProductPrice = 390.000,
                     CategoryId = 7,
                     Description = "Sử dụng phương pháp nhiệt đơn sắc, hỗ trợ kháng khuẩn, nấm.... "
                 },

                 new Product()
                 {
                     ProductId = 9,
                     ProductName = "Máy chụp CT scanner",
                     ProductImage = "maymoc.jpg",
                     ProductPrice = 15000.000,
                     CategoryId = 8,
                     Description = "Giúp chẩn đoán nhanh hơn"
                 },
                 new Product()
                 {
                     ProductId = 10,
                     ProductName = "Bộ dụng cụ ý tế trẻ em",
                     ProductImage = "treem.jpg",
                     ProductPrice = 350.000,
                     CategoryId = 9,
                     Description = "Bao gồm: Bộ hút đàm, Cặp nhiệt độ điện tử, ống hút thuốc"
                 },
                 new Product()
                 {
                     ProductId = 11,
                     ProductName = "Khẩu trang Y tế",
                     ProductImage = "trangtb.jpg",
                     ProductPrice = 50.000,
                     CategoryId = 10,
                     Description = "Khẩu trang y tế 3D kháng khuẩn 4 lớp màng lọc n95"
                 },
                 new Product()
                 {
                     ProductId = 12,
                     ProductName = "Băng cuộn Y tế",
                     ProductImage = "tieuhao.jpg",
                     ProductPrice = 20.000,
                     CategoryId = 11,
                     Description = "Kích thước 1m8 x 0,0085/cuộn. Bịch 5 cuộn"
                 },
                 new Product()
                 {
                     ProductId = 13,
                     ProductName = "Vớ y khoa điều trị suy giãn tĩnh mạch",
                     ProductImage = "vo.jpg",
                     ProductPrice = 380.000,
                     CategoryId = 12,
                     Description = "Làm giảm đường kính các tĩnh mạch ngăn máu chảy ngược xuống..."
                 }
            );
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Visitor",
                    NormalizedName = "VISITOR"
                },
               new IdentityRole
               {
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR".ToUpper()
               });           
        }
    }
}
