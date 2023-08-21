using DemirorenProject.API.DbContexts;
using DemirorenProject.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SQLitePCL;
using System.Security.AccessControl;
using DemirorenProject.API.Models;
namespace DemirorenProject.API.Services
{
    public class NewsService : InterfaceNewsService
    {
        private readonly NewsContext _newsContext;
        public NewsService(NewsContext context)
        {
            _newsContext = context ?? throw new ArgumentNullException(nameof(context));   
        }
         async Task<IEnumerable<CategoriesEN>> InterfaceNewsService.GetCategoriesAsync()
        {
            return await _newsContext.Categories.ToListAsync();
        }

        async Task<CategoriesEN> InterfaceNewsService.GetCategoriesByIDAsync(int categoryID)
        {
            return await _newsContext.Categories.Where(c => c.CategoryId == categoryID).FirstOrDefaultAsync();
        }

        async Task<NewsEN?> InterfaceNewsService.GetNewByIDAsync(int newsID)
        {
            return await _newsContext.News.Where(c => c.Id == newsID).FirstOrDefaultAsync();
        }


        async Task<(IEnumerable<NewsEN>?, PaginationMetadata?)> InterfaceNewsService.GetNewsAsync(string? CategoryName, string? Contains, int pageNum, int pageSize)
        {
            var collection = _newsContext.News as IQueryable<NewsEN>;    // retrieve news 

            if (string.IsNullOrEmpty(CategoryName )&& string.IsNullOrWhiteSpace(Contains))
            {
                var ItemCount = await collection.CountAsync();
                var ToReturn = collection.Skip(pageSize * (pageNum - 1)).Take(pageSize);                               //add skip method TODO
                var metadata = new PaginationMetadata(ItemCount, pageSize,pageNum);
                return (ToReturn, metadata);  // check if any filter or search paramater have applied.If not,return retrieved news
            }

          
            if (!string.IsNullOrWhiteSpace(CategoryName))
            {
                var category = _newsContext.Categories.Where(c => c.CategoryName == CategoryName).FirstOrDefault();   
                if (category == null)
                {
                    return(null,null);
                }
                collection = collection.Where(p => p.CategoryId == category.CategoryId);// filter out the news that doesnt match the category based on user input

            }
            if (!string.IsNullOrWhiteSpace(Contains))
            {
                    Contains = Contains.Trim();                                     // further filter out the news that does not contain user input
                    collection = collection.Where(p => (p.Title != null && p.Title.Contains(Contains)) || (p.Content != null && p.Content.Contains(Contains)));
            }
           
          

            var totalItemCount = await collection.CountAsync();
            var paginationMetaData = new PaginationMetadata(totalItemCount,pageSize,pageNum);
            var collectionToReturn = collection.Skip(pageSize *(pageNum-1)).Take(pageSize);                              // return the results left in collection
            return (collectionToReturn, paginationMetaData);
        }
        
        async Task<IEnumerable<NewsEN>> InterfaceNewsService.GetNewByPopularityAsync()
        {
            return await _newsContext.News.Where(p => p.NoOfViews >= 5 && p.Date.Month - DateTime.Today.Month < 1).ToListAsync(); 
        }
        async Task InterfaceNewsService.AddNewsAsync(NewsEN news)
        {
            _newsContext.Add(news);
        }

        async Task InterfaceNewsService.AddCategoryAsync(CategoriesEN category)
        {
            _newsContext.Add(category);
        }
        void InterfaceNewsService.RemoveNewsAsync(NewsEN news)
        {
            _newsContext.Remove(news);
        }
        void InterfaceNewsService.RemoveCategoryAsync(CategoriesEN category)
        {
            _newsContext.Remove(category);
        }
        async Task<bool> InterfaceNewsService.SaveChangesAsync()
        {
            return(await _newsContext.SaveChangesAsync() >= 0);
        }
        bool InterfaceNewsService.IsRead(int newsid, int userID)
        {
            var readNews = _newsContext.NewsRead.Where(p => p.UserID == userID).ToList();


            if(readNews != null)
            {
                foreach (var read in readNews)
                {
                    if (read.NewsID == newsid)
                    {
                        return true;
                    }
                }
            }
            return(false);
        }
        async Task InterfaceNewsService.addNewsToReadList(int newsid, int userID)
        {
            var read = new NewsReadEN
            {
                NewsID = newsid,
                UserID = userID
            };
            _newsContext.NewsRead.Add(read);
        }
    }
}
