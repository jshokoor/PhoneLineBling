using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhoneLineBling.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [StringLength(50, MinimumLength = 7)]
        [Required]
        public string EmailAddress { get; set; }

        [Display(Name = "Sexual Orientation")]
        [StringLength(50)]
        public string SexualOrientation { get; set; }

        [Display(Name = "Membership Plan")]
        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string MembershipPlan { get; set; }

    }
}
