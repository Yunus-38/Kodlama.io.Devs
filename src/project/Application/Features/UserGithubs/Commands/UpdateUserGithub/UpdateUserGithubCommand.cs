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

namespace Application.Features.UserGithubs.Commands.UpdateUserGithub
{
    public class UpdateUserGithubCommand : IRequest<UpdatedUserGithubDto>
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string ProfileLink { get; set; }

        public class UpdateUserGithubCommandHandler : IRequestHandler<UpdateUserGithubCommand,UpdatedUserGithubDto>
        {
            private readonly IUserGithubRepository _userGithubRepository;
            private readonly IMapper _mapper;

            public UpdateUserGithubCommandHandler(IUserGithubRepository userGithubRepository, IMapper mapper)
            {
                _userGithubRepository = userGithubRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedUserGithubDto> Handle(UpdateUserGithubCommand request, CancellationToken cancellationToken)
            {
                //UserGithub userGithub = _mapper.Map<UserGithub>(request);
                //UserGithub updatedUserGithub = await _userGithubRepository.UpdateAsync(userGithub);
                //UpdatedUserGithubDto result = _mapper.Map<UpdatedUserGithubDto>(updatedUserGithub);

                UserGithub userGithubToUpdate = await _userGithubRepository.GetAsync(u => u.Id == request.Id);
                UserGithub updatedUserGithub = await _userGithubRepository.UpdateAsync(userGithubToUpdate);
                UpdatedUserGithubDto result = _mapper.Map<UpdatedUserGithubDto>(updatedUserGithub);

                return result;
            }
        }
    }
}
