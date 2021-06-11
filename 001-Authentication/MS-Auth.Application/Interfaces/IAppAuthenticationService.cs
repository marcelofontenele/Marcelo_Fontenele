using MS_Auth.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Auth.Application.Interfaces
{
    public interface IAppAuthenticationService
    {
        TokenDTO Authenticate(UserDTO user);
    }
}
