using AutoMapper;
using DemirorenProject.API.DbContexts;
using DemirorenProject.API.Entities;
using DemirorenProject.API.Models;
using DemirorenProject.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace DemirorenProject.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/news")]

    public class NewsController : Controller
    {
        private readonly ILogger _logger;
        private readonly InterfaceNewsService newsService;
        private readonly IMapper _mapper;
        private readonly NewsContext _newsContext;
        const int maxPageSize = 20;

        public NewsController(ILogger<NewsController> logger, InterfaceNewsService newsDB, IMapper mapper, NewsContext context) {
            _newsContext = context??throw new ArgumentNullException(nameof(context));
            _logger = logger??throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            newsService = newsDB ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// gets the news based on (if there is any)filters defined by the curent user.
        /// </summary>
        /// <param name="Category">filtering by category</param>
        /// <param name="Contains">word search (in title and/or content)</param>
        /// <param name="pageNum">page number user wants to be in</param>
        /// <param name="pageSize">number of news that the page contains</param>
        /// <returns>an IEnumerable of news</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<NewsDTOReadReceipt>>> GetNews(string? Category,string? Contains,int pageNum = 1,int pageSize = 10) {
            var userID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value);
         
            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }                                                                                                       
            var (news,paginationMetaData) = await newsService.GetNewsAsync(Category,Contains,pageNum,pageSize);
            Response.Headers.Add("X-pagination", JsonSerializer.Serialize(paginationMetaData));
            if (news == null) { return NotFound(); }
            
            var readNews = _newsContext.NewsRead.Where(p => p.UserID == userID).ToList();
            var c = _mapper.Map<IEnumerable<NewsDTOReadReceipt>>(news);
            //var col = new List<NewsDTOReadReceipt>();
            if (readNews != null)
            {
                foreach (var read in c)
                {
                    //var a = _mapper.Map<NewsDTOReadReceipt>(read);
                    foreach (var item in readNews)
                    {
                        if (item.NewsID == read.Id)
                        {
                            read.IsRead = true;
                            break;
                        }
                        read.IsRead = false;
                    }
                    //col.Add(a);
                }
            }
            else
            {
                foreach(var item in c)
                {
                    item.IsRead = false;
                }
            }
            
            _logger.LogInformation($"News have been succesfuly retrieved.");
            return Ok(c/*col*/); /*_mapper.Map<IEnumerable<NewsDTO>>(news)*/
        }
        /// <summary>
        /// gets the popular news
        /// </summary>
        /// <returns>an IActionResult</returns>
        [HttpGet("popular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNewsBypopularity()
        {
            var selectedNew = await newsService.GetNewByPopularityAsync();
            if (selectedNew == null)
            {
                return NotFound();
            }
           
            return Ok(selectedNew);
        }
        /// <summary>
        /// gets the news by given id
        /// </summary>
        /// <param name="id">id of the news that user requests</param>
        /// <returns>an IActionResult</returns>
        [HttpGet("{id}",Name = "getNews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNew(int id)
        {
            var userID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value);
            var selectedNew = await newsService.GetNewByIDAsync(id);
            if (selectedNew == null) { 
                return NotFound(); 
            }

            selectedNew.NoOfViews += 1;
            var finalnew = _mapper.Map<NewsDTOReadReceipt>(selectedNew);
            var read = new NewsReadEN
            {
                NewsID = id,
                UserID = userID
            };
            var readNews = _newsContext.NewsRead.Where(p => p.UserID == userID).ToList();
            for (int i = 0; i < readNews.Count;i++)
            {
                if (readNews[i].NewsID == id)
                {
                    finalnew.IsRead = true;
                    return Ok(finalnew);
                }

            }
            finalnew.IsRead = false;
            _newsContext.NewsRead.Add(read);


            await newsService.SaveChangesAsync();
            return Ok(finalnew);
        }
        /// <summary>
        /// creates a new news object and saves it to database
        /// </summary>
        /// <param name="newNews">NewsForCreation object needed to create new news</param>
        /// <returns>an ActionResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NewsDTO>> CreateNews([FromBody] NewsForCreation newNews)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Cannot validate model state please check your input.");
                return BadRequest();
            }
            

            var finalNews = _mapper.Map<Entities.NewsEN>(newNews);
            finalNews.Date = DateTime.Now;

            await newsService.AddNewsAsync(finalNews);
            await newsService.SaveChangesAsync();

            var createdNews = _mapper.Map<Models.NewsDTO>(finalNews);

            _logger.LogInformation($"Successfuly created the news with id {createdNews.Id}.");
            return CreatedAtRoute("getNews",
                new
                {
                    Id = createdNews.Id,
                },createdNews);
        }
        /// <summary>
        /// updates all values of the news with the given id
        /// </summary>
        /// <param name="newsId">id of the requested news</param>
        /// <param name="updatedNews">NewsForUpdate object to patch the values to retrieved news object</param>
        /// <returns>an ActionResult</returns>
        [HttpPut("{newsId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult> updateNews(int newsId, [FromBody] NewsForUpdate updatedNews)
        {
            var news = await newsService.GetNewByIDAsync(newsId);
            if (news == null)
            {
                _logger.LogInformation($"News with given id ({newsId}) cannot be found!");
                return NotFound();
            }

            updatedNews.Date = DateTime.Now;
            _mapper.Map(updatedNews,news);
            await newsService.SaveChangesAsync();

            _logger.LogInformation($"Successfuly updated news with the given id ({newsId}) with values {updatedNews.Title}, {updatedNews.Content}," +
                $"{updatedNews.CategoryID}. ");
            return NoContent();

        }
        /// <summary>
        /// partialy updates the values of the news with the given id
        /// </summary>
        /// <param name="newsID">id of the requested news</param>
        /// <param name="newsForpatch">NewsForUpdate object to patch the values to retrieved news object</param>
        /// <returns>an ActionResult</returns>
        [HttpPatch("{newsID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> patchNews(int newsID, [FromBody] JsonPatchDocument<NewsForUpdate> newsForpatch)
        {
            var news = await newsService.GetNewByIDAsync(newsID); //retrieve a news object 
            if (news == null) { _logger.LogInformation($"News with given id ({newsID}) cannot be found!"); return NotFound(); }

            var newsToPatch = _mapper.Map<NewsForUpdate>(news); //map retrieved news object to an instance of "NewsForUpdate"
            
            newsForpatch.ApplyTo(newsToPatch, ModelState);     //apply inputs to recently mapped object
            

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!TryValidateModel(newsToPatch))
            {
                _logger.LogInformation($"Cannot validate model state please check your input.");
                return BadRequest(ModelState);
            }
            _mapper.Map(newsToPatch, news);                     //map updated values to retrieved news object
            await newsService.SaveChangesAsync();               //apply changes to database

            

            _logger.LogInformation($"Successfuly updated news with the given id ({newsID}) with values {newsToPatch.Title}, {newsToPatch.Content}," +
                $"{newsToPatch.CategoryID}. ");
            return NoContent();
        }

        /// <summary>
        /// deletes the news with the given id
        /// </summary>
        /// <param name="newsID">id of the news that to be deleted</param>
        /// <returns>an ActionResult</returns>
        [HttpDelete("{newsID}")]
        [Authorize(Policy = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> deleteNews(int newsID)
        {
            
            
            var newToDelete = await newsService.GetNewByIDAsync(newsID);
            if (newToDelete == null) { return NotFound(); }

            newsService.RemoveNewsAsync(newToDelete);
            await newsService.SaveChangesAsync();

            _logger.LogInformation($"Successfuly deleted news with the given id ({newsID}).");
            return NoContent();

        }
    }
}
 