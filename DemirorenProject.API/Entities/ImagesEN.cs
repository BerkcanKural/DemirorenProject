using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemirorenProject.API.Entities
{
    public class ImagesEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? filename { get; set; }
        public string? filepath { get; set; }
        [ForeignKey("Id")]
        [Required]
        public int newsID { get; set; }
    }
}
