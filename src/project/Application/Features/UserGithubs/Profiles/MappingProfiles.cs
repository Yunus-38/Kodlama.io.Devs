using Application.Features.UserGithubs.Commands.CreateUserGithub;
using Application.Features.UserGithubs.Commands.DeleteUserGithub;
using Application.Features.UserGithubs.Commands.UpdateUserGithub;
using Application.Features.UserGithubs.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUserGithubCommand, UserGithub>().ReverseMap();
            CreateMap<UserGithub, CreatedUserGithubDto>().ReverseMap();

            CreateMap<UpdateUserGithubCommand, UserGithub>().ReverseMap();
            CreateMap<UserGithub, UpdatedUserGithubDto>().ReverseMap();

            //CreateMap<DeleteUserGithubCommand, UserGithub>().ReverseMap();
            CreateMap<UserGithub, DeletedUserGithubDto>().ReverseMap();
        }
    }
}
