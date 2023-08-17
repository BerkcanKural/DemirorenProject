namespace DemirorenProject.API.Models
{
    /// <summary>
    /// categories object
    /// </summary>
    public class Categories
    {
        /// <summary>
        /// id of the category(going to be created automaticaly)
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// name of the category
        /// </summary>
        public string? CategoryName { get; set; }
    }
}
