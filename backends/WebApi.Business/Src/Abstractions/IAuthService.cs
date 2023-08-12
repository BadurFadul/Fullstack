using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Src.Dtos;

namespace WebApi.Business.Src.Abstractions
{
    public interface IAuthService
    {
        Task<string> VerifyCredentials(UserCredentialDto credentials);
    }
}