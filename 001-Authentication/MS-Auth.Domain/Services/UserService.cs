using MS_Auth.Domain.Entities;
using MS_Auth.Domain.Interfaces.Repositories;
using MS_Auth.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Auth.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository ?? throw new NullReferenceException(nameof(IUserRepository));
        }
        public User Get(User user)
        {
            return this.userRepository.Get(user);
        }
    }
}
