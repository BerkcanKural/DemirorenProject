using DemirorenProject.API.DbContexts;
using DemirorenProject.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace DemirorenProject.API.Controllers
{
    [Route("api/Files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _FileExtensionContentTypeProvider;
        private readonly NewsContext _newsContext;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider, IWebHostEnvironment webHostEnvironment,NewsContext context)
        {
            _newsContext = context;
            _FileExtensionContentTypeProvider = fileExtensionContentTypeProvider
             ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
            _webHostEnvironment = webHostEnvironment; 
        }


        [HttpGet("{fileId}")]
        public IActionResult Getfile(string fileId) {

            var pathtoFile = "";
            if(!System.IO.File.Exists(pathtoFile)) {
                return NotFound();          
            }
            if(!_FileExtensionContentTypeProvider.TryGetContentType(pathtoFile,out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(pathtoFile);
            return File(bytes,"text/plain",Path.GetFileName(pathtoFile));
        }
        [HttpPost("upload")]
        public IActionResult Postfile([FromForm] UploadPhotoRequest file)
        {
            
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\upload\\" + file.filepath))  //check if the folder which user has typed exists
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\upload\\" + file.filepath); //if not,create the folder
            }
            using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + $"\\upload\\{file.filepath}\\" + file.File.FileName)) //create file path
            {
                file.File.CopyTo(filestream); //add file to file path
                filestream.Flush();
                //  return "\\Upload\\" + objFile.files.FileName;
            }
            var image = new ImagesEN        
            {
                filename = Guid.NewGuid().ToString(),   
                filepath = "\\upload\\" + file.filepath + $"\\{file.File.FileName}",
                newsID = file.newsId
            };
            _newsContext.Add(image);
            _newsContext.SaveChangesAsync();
            return Ok(true);
        }
        public class UploadPhotoRequest
        {
            public IFormFile? File { get; set; }
            public string? filepath { get; set; }
            public int newsId { get; set; }

        }

        
    }
}
