using MS_Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Auth.Domain.Interfaces.Services
{
    public interface IUserService
    {
        User Get(User user);
    }
}