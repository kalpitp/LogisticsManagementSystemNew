using LogisticsManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.DataAccess.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly CybageLogisticsContext _context;

        public AuthenticationRepository(CybageLogisticsContext dbContext)
        {
            _context = dbContext;
        }


        // get user by user id
        public User GetUserByUserId(string userId)
        {
           return  _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == userId);
        }

        // Add user to database
        public int AddUser(User user, UserDetail userDetail)
        {
            try
            {
                _context.Users.Add(user);
                _context.UserDetails.Add(userDetail);
                return _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                Console.WriteLine("An Error occured while adding user");
            }
            catch (Exception)
            {
                Console.WriteLine("An Error occured while adding user");

            }

            return -1;
        }

        // Get role Id by role name
        public int GetRoleIdByName(string roleName)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == roleName);

            // If role is found, return Id, else return a default value 
            return role?.Id ?? -1;
        }
    }
}
