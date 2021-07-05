using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webtt.Models
{
    public class ProductModels: EditModels
    {
        [DisplayName("ProductName")]
        [Required(ErrorMessage = "Nhập tên sản phẩm")]       
        public string ProductName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Vui lòng nhập giá hợp lệ")]
        public double ProductPrice { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Bạn chưa chọn danh mục")]
        public int CategoryId { get; set; }
        
    }
}
