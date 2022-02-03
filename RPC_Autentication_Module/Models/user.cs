using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPC_Autentication_Module.Models
{
    public class User
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public String Username { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public String Password { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public String Firstname { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public String Lastname { get; set; }

        [Display(Name = "Birth Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

    }
}