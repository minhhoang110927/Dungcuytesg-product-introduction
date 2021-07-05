using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webtt.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(300)]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [RegularExpression(@"[0]+[0-9]{9}", ErrorMessage = "please enter correct number")]
        [StringLength(10)]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "please enter correct email")]
        public string ContactEmail { get; set; }

        public string Content { get; set; }
    }
}
