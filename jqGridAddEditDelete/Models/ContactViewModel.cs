
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace jqGridAddEditDelete.Models
{
    public class ContactViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public System.Guid ContactId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [DisplayName("Name")]
        [StringLength(50, ErrorMessage = "Name must be less than or equal to 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DisplayName("E-mail")]
        [StringLength(50, ErrorMessage = "Email must be less than or equal to 50 characters")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\s*;?\s*)+$", ErrorMessage = "Email must be valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [DisplayName("Phone Number")]
        [StringLength(50, ErrorMessage = "Phone must be less than or equal to 50 characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth Required")]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Is Married")]
        public bool IsMarried { get; set; }
    }
}