using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModelLayer
{
    public class Account
    {
        public int AccountId { get; set; }
        public int PersonId { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        [RegularExpression(@"[^\s]+", ErrorMessage = "No spaces in username")]
        public string? UserName { get; set; }
        
        [Required]
        [RegularExpression(@"[^\s]+", ErrorMessage = "No spaces in password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public UserRole Role
        {
            get
            {
                return IsAdmin ? UserRole.Administrator : UserRole.User;
            }
            set
            {
                IsAdmin = value == UserRole.Administrator;
            }
        }

    }

}
