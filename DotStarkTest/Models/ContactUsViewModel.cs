using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotStarkTest.Models
{
    public class ContactUsViewModel
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Name")]
        [RegularExpression(pattern: "[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2, 4}$",ErrorMessage ="Enter Valid Email Address")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Name")]
        [RegularExpression(pattern: "[0-9]{10}", ErrorMessage ="Enter Phone Number")]
        public long Contact { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Porpose")]
        public string Porpose { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Give some brief")]
        public string Description { get; set; }
    }
}
