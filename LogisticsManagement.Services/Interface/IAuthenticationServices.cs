using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.Services.Interface
{
    public interface IAuthenticationServices
    {

        bool Login(string userid, string password);

        bool SignUp(UserInfo user, string role);

        UserSession CurrentUser { get; }

    }
}
