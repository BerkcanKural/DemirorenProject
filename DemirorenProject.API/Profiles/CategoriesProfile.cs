using AutoMapper;

namespace DemirorenProject.API.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Entities.CategoriesEN, Models.Categories>();
            CreateMap<Models.CategoriesForCreation, Entities.CategoriesEN>();
            CreateMap<Models.CategoriesForUpdate,Entities.CategoriesEN>();
            CreateMap<Entities.CategoriesEN, Models.CategoriesForUpdate>();
        }
    }
}
