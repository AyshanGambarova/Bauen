using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Text { get; set; }
        public string Image { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Subtitle { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
