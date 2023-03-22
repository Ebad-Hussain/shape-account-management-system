using AutoMapper;
using ShapeAccountManagementSystem.Core.Entities;
using ShapeAccountManagementSystem.Models.Receivables;

namespace ShapeAccountManagementSystem.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserReceivableDto, User>().ReverseMap();
        }
    }
}
