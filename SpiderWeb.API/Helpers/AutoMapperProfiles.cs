using System.Linq;
using AutoMapper;
using SpiderWeb.API.Dtos;
using SpiderWeb.API.Models;

namespace SpiderWeb.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>{
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opt =>{
                opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            } );
            CreateMap<User, UserDetailedDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>{
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opt =>{
                opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            } );
              CreateMap<Photo, PhotosForDetailedDto>();

              CreateMap<UserForUpdateDtos,User>();

              CreateMap<PhotoForCreationDto, Photo>();

              CreateMap<UserForRegisterDto,User>();
        }
        
    }
}