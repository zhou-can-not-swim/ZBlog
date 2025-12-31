using AutoMapper;
using Entities;
using Entities.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<UserForCreationDto, User>();
            CreateMap<ContentToBlog, Blog>();

        }
    }
}
