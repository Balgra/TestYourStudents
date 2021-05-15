using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TestYourStudents.Core.Entities
{
    public class User: IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}