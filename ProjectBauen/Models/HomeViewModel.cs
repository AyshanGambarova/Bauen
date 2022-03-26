using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Models
{
    public class HomeViewModel
    {
        public List<Banner> Banners { get; set; }
        public About About { get; set; }
        public List<Project> Projects { get; set; }
        public List<Service> Services { get; set; }
        public List<News> News { get; set; }
        public Contact Contact { get; set; }
        public List<Testimonials> Testimonials { get; set; }
        public List<Clients> Clients { get; set; }
        public List<Navbar> Navbars { get; set; }
    }
}
