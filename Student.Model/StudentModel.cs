using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Student.Model
{   
    public class StudentModel
    {
        [Display(Name ="First Name")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="First Name Must be Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Must be Required")]
        public string LastName { get; set; }

        [Display(Name = "Father's Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Father Name Must be Required")]
        public string FatherName { get; set; }

        [Display(Name = "Mother's Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mother Name Must be Required")]
        public string MotherName { get; set; }

        [Display(Name = "Country Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country Name Must be Required")]
        public string Country { get; set; }

        [Display(Name = "Email Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id Must be Required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Display(Name = "Age")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Age Must be Required")]
        [DataType(DataType.DateTime)]
        public int Age { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Must be Required")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Password Must be Less Than 6")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password Must be Required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Confirm Password Must be Matched With Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of Birth Must be Required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public bool IsEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
    }
}
