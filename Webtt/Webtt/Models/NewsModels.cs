using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webtt.Models
{
    public class NewsModels: EditModels
    {

        [DisplayName("News Title")]
        [Required(ErrorMessage = "Not null")]
        public string NewsTitle { get; set; }
        
        [DisplayName("News Content")]
        [Required(ErrorMessage = "Not null")]
        public string NewsContent { get; set; }
    }
}
