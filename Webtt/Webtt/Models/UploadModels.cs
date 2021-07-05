using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webtt.Models
{
    public class UploadModels
    {
        [Required]
        [Display(Name = "Image")]
        public IFormFile ItemImage { get; set; }
    }
}
