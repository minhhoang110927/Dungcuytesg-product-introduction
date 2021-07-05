using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webtt.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        [Display(Name = "Title")]
        [StringLength(100)]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "Please enter Content")]
        public string NewsContent { get; set; }

        [Required(ErrorMessage = "Please choose image")]
        public string NewsImage { get; set; }
    }
}
