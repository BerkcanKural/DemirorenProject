using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemirorenProject.API.Entities
{
    public class NewsEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string? Title { get; set; }
        [MaxLength(1000)]
        [Required]
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public int NoOfViews { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        
    }
}
