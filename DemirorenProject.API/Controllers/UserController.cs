using AutoMapper;
using DemirorenProject.API.DbContexts;
using DemirorenProject.API.Entities;
using DemirorenProject.API.Models;
using DemirorenProject.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemirorenProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger _logger;
        private readonly InterfaceNewsService newsService;
        private readonly IMapper _mapper;
        private readonly NewsContext _newsContext;
        const int maxPageSize = 20;

        public UserController(ILogger<NewsController> logger, InterfaceNewsService newsDB, IMapper mapper, NewsContext context)
        {
            _newsContext = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            newsService = newsDB ?? throw new ArgumentNullException();
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<UserForCreation> Get()
        {
            var a = _newsContext.Users.ToList();
            var b = _mapper.Map<IEnumerable<UserForCreation>>(a);

            return Ok(b);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserForCreation> Get(int id)
        {
            var a = _newsContext.Users.FirstOrDefault(p=>p.UserId == id);
            _mapper.Map<UserForCreation>(a);
            return Ok(a);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserForCreation userInfo)
        {
            var newUser = _mapper.Map<UsersEN>(userInfo);
            newUser.Role = "user";
            _newsContext.Users.Add(newUser);
            _newsContext.SaveChangesAsync();
        }
    }
}
