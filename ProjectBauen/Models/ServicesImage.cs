using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Models
{
    public class ServicesImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
