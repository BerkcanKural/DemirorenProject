namespace DemirorenProject.API.Models
{
    /// <summary>
    /// news object
    /// </summary>
    public class NewsDTO
    {
        /// <summary>
        /// id of the news(going to be created automaticaly)
        /// </summary>
        public int Id { get; set; } 
        /// <summary>
        /// title of the news
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// content of the news
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// news' post date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// number of views that the news has
        /// </summary>
        public int NoOfViews { get; set; }
        /// <summary>
        /// catehory of the news
        /// </summary>
        public int CategoryID { get; set; }
        
    }
}
