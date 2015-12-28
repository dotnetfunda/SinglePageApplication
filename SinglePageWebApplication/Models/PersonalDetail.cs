using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PersonalDetail
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        [Display(Name= "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please write your LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int? Age { get; set; }

        [Display(Name = "Is Active?")]
        public bool? Active { get; set; }
    }
}