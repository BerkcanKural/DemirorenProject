using AutoMapper;
using DemirorenProject.API.Models;
using DemirorenProject.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DemirorenProject.API.Controllers
{
    [Route("api/news/categories")]
    [Authorize]
    [ApiController]
    public class categoriesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly InterfaceNewsService _newsService;
        private readonly IMapper _mapper;
        public categoriesController(ILogger<categoriesController> logger,InterfaceNewsService newsService,IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
        }

        [HttpGet("", Name = "getCategory")]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories(int categoryID)
        {
            var categories = await _newsService.GetCategoriesAsync();

            _logger.LogInformation($"Categories have been succesfuly retrieved.");
            return Ok(_mapper.Map<IEnumerable<Categories>>(categories));

        }
        [HttpPost]
        public async Task<ActionResult<Categories>> CreateNews([FromBody] CategoriesForCreation newCategory)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Cannot validate model state please check your input.");
                return BadRequest();
            }


            var finalcategory = _mapper.Map<Entities.CategoriesEN>(newCategory);
            

            await _newsService.AddCategoryAsync(finalcategory);
            await _newsService.SaveChangesAsync();

            var createdCategory = _mapper.Map<Models.Categories>(finalcategory);
            _logger.LogInformation($"Successfuly created the entry.");
            return CreatedAtRoute("getCategory",
                new
                {
                    CategoryId = createdCategory.CategoryId,
                }, createdCategory);
        }
        [HttpPut("{categoryID}")]
        public async Task<ActionResult> updateCategory(int categoryID, [FromBody] CategoriesForUpdate updateValues)
        {
            var Categories = await _newsService.GetCategoriesByIDAsync(categoryID);
            if (Categories == null)
            {
                _logger.LogInformation($"News with given id ({categoryID}) cannot be found!");
                return NotFound();
            }

            _mapper.Map(updateValues, Categories);
            await _newsService.SaveChangesAsync();

            _logger.LogInformation($"Successfuly updated category.");
            return NoContent();

        }
        [HttpPatch("{categoryID}")]
        public async Task<ActionResult> patchCategory(int categoryID, [FromBody] JsonPatchDocument<CategoriesForUpdate> CategoryForPatch)
        {
            var category = await _newsService.GetCategoriesByIDAsync(categoryID); //retrieve a category object 
            if (category == null) { _logger.LogInformation($"News with given id ({categoryID}) cannot be found!"); return NotFound(); }

            var CategoriesToPatch = _mapper.Map<CategoriesForUpdate>(category); //map retrieved news object to an instance of "CategoriesForUpdate" object

            CategoryForPatch.ApplyTo(CategoriesToPatch, ModelState);     //apply inputs to recently mapped object


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!TryValidateModel(CategoriesToPatch))
            {
                _logger.LogInformation($"Cannot validate model state please check your input.");
                return BadRequest(ModelState);
            }
            _mapper.Map(CategoriesToPatch, category);             //map updated values to retrieved category object
            await _newsService.SaveChangesAsync();               //apply changes to database
        
            return NoContent();
        }
        [HttpDelete("{categoryID}")]
        public async Task<ActionResult> deleteNews(int categoryID)
        {
            var category = await _newsService.GetCategoriesByIDAsync(categoryID);
            if (category == null) { return NotFound(); }

            _newsService.RemoveCategoryAsync(category);

            await _newsService.SaveChangesAsync();
            _logger.LogInformation($"Successfuly deleted the category with given id {category.CategoryId}");
            return NoContent();

        }
    }
   
}
