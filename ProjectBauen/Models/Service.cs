using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        //public string Image { get; set; }

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
        //[NotMapped]
        //public IFormFile[] ImageList { get; set; }
        public List<ServicesImage> ServicesImages { get; set; }
    }
}
