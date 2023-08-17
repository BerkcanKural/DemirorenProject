using AutoMapper;

namespace DemirorenProject.API.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<Entities.NewsEN,Models.NewsDTO>();
            CreateMap<Models.NewsForCreation, Entities.NewsEN>();
            CreateMap<Models.NewsForUpdate, Entities.NewsEN>();
            CreateMap<Entities.NewsEN, Models.NewsForUpdate>();
            CreateMap<Entities.NewsEN, Models.NewsDTOReadReceipt>();
            CreateMap<Models.NewsDTOReadReceipt, Entities.NewsEN>();
        }
    }
}
