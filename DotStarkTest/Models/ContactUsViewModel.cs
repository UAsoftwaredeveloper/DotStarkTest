using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotStarkTest.Models
{
    public class ContactUsViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Name")]

        public string Name { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Phone number")]
        public long Contact { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Porpose")]
        public string Porpose { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Give some brief")]
        public string Description { get; set; }
    }
}
