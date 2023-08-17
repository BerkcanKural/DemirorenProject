using DemirorenProject.API.Models;

namespace DemirorenProject.API
{
    public class newsDataStore
    {
        public List<NewsDTO> News { get; set; }
        //public static newsDataStore Current { get;} = new newsDataStore();
        public newsDataStore()
        {
            News = new List<NewsDTO>()
            {
                new NewsDTO()
                {
                    Title = "Test",
                    Content = "This is the content for sports news",
                    Date = DateTime.Now,
                    CategoryID = 1
                },
                
                new NewsDTO()
                {
                    Title = "Test2",
                    Content = "This is the content for science news",
                    Date = DateTime.Now,
                    CategoryID = 2
                },
                new NewsDTO()
                {
                    Title = "Test3",
                    Content = "This is the content for politics news",
                    Date = DateTime.Now,
                    CategoryID = 3
                },
                new NewsDTO()
                {
                    Title = "Test4",
                    Content = "This is the content for another politics news",
                    Date = DateTime.Now,
                    CategoryID = 3
                }
            };
        }
    }
}