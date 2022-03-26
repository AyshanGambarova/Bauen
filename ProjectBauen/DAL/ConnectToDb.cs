using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectBauen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.DAL
{
    public class ConnectToDb:IdentityDbContext<AppUser>
    {
        public ConnectToDb(DbContextOptions<ConnectToDb> options) : base(options)
        { }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicesImage> ServicesImages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Navbar> Navbars { get; set; }

    }
}
