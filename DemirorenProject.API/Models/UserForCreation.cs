using System.ComponentModel.DataAnnotations;

namespace DemirorenProject.API.Models
{
    public class UserForCreation
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
     
        
    }
}
