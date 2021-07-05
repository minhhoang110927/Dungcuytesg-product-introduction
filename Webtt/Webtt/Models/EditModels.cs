using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webtt.Models
{
    public class EditModels: UploadModels
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
    }
}
