using AutoMapper;

namespace DemirorenProject.API.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Entities.UsersEN, Models.UserForCreation>();
            CreateMap<Models.UserForCreation, Entities.UsersEN>();
        }
    }
}
