using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetListUser
{
    public class GetListUserQuery : IRequest<UserListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserGithubRepository _userGithubRepository;
            private readonly IMapper _mapper;

            public GetListUserQueryHandler(IUserRepository userRepository, IUserGithubRepository userGithubRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _userGithubRepository = userGithubRepository;
                _mapper = mapper;
            }

            public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserGithub> userGitHubs = await _userGithubRepository.GetListAsync(include:
                                                                                 u => u.Include(a => a.User),
                                                                                 index: request.PageRequest.Page,
                                                                                 size: request.PageRequest.PageSize
                                                                                 );
                UserListModel result = _mapper.Map<UserListModel>(userGitHubs);
                return result;
            }
        }
    }
}
