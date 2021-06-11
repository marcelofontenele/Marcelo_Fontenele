using MS_Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Auth.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Get(User user);
    }
}