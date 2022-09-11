using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var userToCheck = _userRepository.Get(u => u.Email == request.UserForLoginDto.Email);

                if (userToCheck == null)
                {
                    throw new BusinessException("User not found");
                }
                if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                {
                    throw new BusinessException("Password incorrect");
                }

                var claims = _userRepository.GetClaims(userToCheck);
                var accessToken = _tokenHelper.CreateToken(userToCheck, claims);

                return accessToken;
            }
        }
    }
}
