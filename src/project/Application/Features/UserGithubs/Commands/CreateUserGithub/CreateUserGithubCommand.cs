using Application.Features.UserGithubs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Commands.CreateUserGithub
{
    public class CreateUserGithubCommand : IRequest<CreatedUserGithubDto>
    {
        public int UserId { get; set; }
        public string ProfileLink { get; set; }

        public class CreateUserGithubCommandHandler : IRequestHandler<CreateUserGithubCommand, CreatedUserGithubDto>
        {
            private readonly IUserGithubRepository _userGithubRepository;
            private readonly IMapper _mapper;

            public CreateUserGithubCommandHandler(IUserGithubRepository userGithubRepository, IMapper mapper)
            {
                _userGithubRepository = userGithubRepository;
                _mapper = mapper;
            }

            public async Task<CreatedUserGithubDto> Handle(CreateUserGithubCommand request, CancellationToken cancellationToken)
            {
                UserGithub userGithub = _mapper.Map<UserGithub>(request);
                UserGithub addedUserGithub = await _userGithubRepository.AddAsync(userGithub);
                CreatedUserGithubDto result = _mapper.Map<CreatedUserGithubDto>(addedUserGithub);

                return result;
            }
        }
    }
}
