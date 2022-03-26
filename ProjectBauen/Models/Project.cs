using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Subtitle { get; set; }
        public string ProjectName { get; set; }
        public  int Year { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
      
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public IFormFile[] ImageFiles { get; set; }


        public List<ProjectImage> ProjectImages { get; set; }
    }
}
