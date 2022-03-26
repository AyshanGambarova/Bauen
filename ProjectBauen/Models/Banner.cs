using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Models
{
    public class Banner
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Text { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string ButtonText { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string ButtonLink { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
