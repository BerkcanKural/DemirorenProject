namespace DemirorenProject.API.Models
{
    public class NewsDTOReadReceipt
    {
        public int Id { get; set; } 
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public int CategoryID { get; set; }
        public bool? IsRead { get; set; }
        
    }
}
