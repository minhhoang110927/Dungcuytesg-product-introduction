using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webtt.Models
{
    public class changePasswordModel
    {
        [DataType(DataType.Password)]
        [DisplayName("Old Password")]
        [Required(ErrorMessage = "Nhập mật khẩu cũ")]
        public string oldPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("New Password")]
        public string newPassword { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("newPassword", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }
    }
}
