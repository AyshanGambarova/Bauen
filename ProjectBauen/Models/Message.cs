using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad və soyad daxil olunmayıb."), MaxLength(100)]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Email daxil olunmayıb."), MaxLength(100)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Rəy daxil olunmayıb."), MaxLength(100)]
        public string Text { get; set; }
        public Message()
        { }

        public Message(string FullName, string Email, string Text)
        {
            this.FullName = FullName;
            this.Email = Email;
            this.Text = Text;
        }
    }
}
