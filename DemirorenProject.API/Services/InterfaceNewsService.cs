using DemirorenProject.API.Entities;

namespace DemirorenProject.API.Services
{
    public interface InterfaceNewsService
    { 
        Task<(IEnumerable<NewsEN>?, PaginationMetadata?)> GetNewsAsync(string? categoryName, string? Contains, int pageNum, int pageSize);

        Task<NewsEN?> GetNewByIDAsync(int newsID);

        Task<IEnumerable<CategoriesEN>> GetCategoriesAsync();

        Task<CategoriesEN> GetCategoriesByIDAsync(int categoryID);

        Task<IEnumerable<NewsEN>> GetNewByPopularityAsync();

        Task AddCategoryAsync(CategoriesEN category);

        Task AddNewsAsync(NewsEN news);

        void RemoveCategoryAsync(CategoriesEN category);

        void RemoveNewsAsync(NewsEN news);

        Task<bool> SaveChangesAsync();
       
    }
}
