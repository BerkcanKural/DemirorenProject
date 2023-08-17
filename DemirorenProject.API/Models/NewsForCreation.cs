using System.ComponentModel.DataAnnotations;

namespace DemirorenProject.API.Models
{
    public class NewsForCreation
    {
        [MaxLength(100)]
        [Required]
        public string? Title { get; set; }
        [MaxLength(1000)]
        [Required]
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
