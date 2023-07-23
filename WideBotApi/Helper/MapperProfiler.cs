using AutoMapper;
using WideBotApi.Models;

namespace WideBotApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Inorder to add a mapping between 2 classes
            CreateMap<User, FacebookGC>()
                .ForMember(des => des.Title, opt => opt.MapFrom(src => src.First_Name))
                .ForMember(des => des.Subtitle, opt => opt.MapFrom(src => src.Last_Name))
                .ForMember(des => des.Image_Uri, opt => opt.MapFrom(src => src.Avatar));
            
        }
    }
}
