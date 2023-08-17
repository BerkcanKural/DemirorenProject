using DemirorenProject.API.Models;

namespace DemirorenProject.API
{
    public class categoriesDataStore
    {
        public List<Categories> Categories { get; set; }
        //public static categoriesDataStore curent { get; } = new categoriesDataStore();
        public categoriesDataStore()
        {
            Categories = new List<Categories>()
            {
                new Categories()
                {
                    CategoryId = 1,
                    CategoryName = "sports",
                },
                new Categories()
                {
                    CategoryId = 2,
                    CategoryName = "science",
                },
                new Categories()
                {
                    CategoryId = 3,
                    CategoryName = "politics",
                },
            };
        }
    }
}
