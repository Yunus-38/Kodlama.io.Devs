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

namespace Application.Features.UserGithubs.Commands.DeleteUserGithub
{
    public class DeleteUserGithubCommand : IRequest<DeletedUserGithubDto>
    {
        public int Id { get; set; }
        public string ProfileLink { get; set; }

        public class DeleteUserGithubCommandHandler : IRequestHandler<DeleteUserGithubCommand, DeletedUserGithubDto>
        {
            private readonly IUserGithubRepository _userGithubRepository;
            private readonly IMapper _mapper;

            public DeleteUserGithubCommandHandler(IUserGithubRepository userGithubRepository, IMapper mapper)
            {
                _userGithubRepository = userGithubRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserGithubDto> Handle(DeleteUserGithubCommand request, CancellationToken cancellationToken)
            {
                UserGithub userGithubToDelete = await _userGithubRepository.GetAsync(u => u.Id == request.Id);
                UserGithub deletedUserGithub = await _userGithubRepository.DeleteAsync(userGithubToDelete);
                DeletedUserGithubDto result = _mapper.Map<DeletedUserGithubDto>(deletedUserGithub);

                return result;
            }
        }
    }
}
