using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserCanNotBeDuplicated(UserForRegisterDto userForRegisterDto)
        {
            IPaginate<User> users = await _userRepository.GetListAsync(u => u.Email == userForRegisterDto.Email
                                                    || u.FirstName == userForRegisterDto.FirstName
                                                    && u.LastName == userForRegisterDto.LastName);

            if (users.Items.Any()) throw new BusinessException("User already exists");
        }
    }
}
