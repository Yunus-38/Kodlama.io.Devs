using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, LoggedInUserDto>().ReverseMap();
            CreateMap<User, RegisteredUserDto>().ReverseMap();

            CreateMap<UserGithub, UserListDto>()
                .ForMember(c => c.Id, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(c=>c.Email, opt=>opt.MapFrom(c=>c.User.Email))
                .ForMember(c=>c.FirstName, opt=>opt.MapFrom(c=>c.User.FirstName))
                .ForMember(c=>c.LastName, opt=>opt.MapFrom(c=>c.User.LastName))
                .ReverseMap();
            CreateMap<IPaginate<UserGithub>, UserListModel>().ReverseMap();
        }
    }
}
