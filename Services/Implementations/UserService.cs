using Majestics.Data;
using Majestics.Models.Users;
using Majestics.Services.Abstractions;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Majestics.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserInfoViewModel> GetInfo(string userId)
        {
            return await _dbContext.Users
                .Where(x => x.Id == userId)
                .Select(x => new UserInfoViewModel
                {
                    Name = x.FirstName,
                    Email = x.Email,
                    Address = x.Address,
                    BirthDate = x.BirthDate.ToString(CultureInfo.InvariantCulture),
                    Institution = x.Institute,
                    Phone = x.Phone,
                    Surname = x.LastName
                }).FirstOrDefaultAsync();
        }

        public async Task<UserInfoViewModel> UpdateInfo(UserInfoViewModel request, string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            user.FirstName = request.Name;
            user.Email = request.Email;
            user.Address = request.Address;
            user.BirthDate = string.IsNullOrEmpty(request.BirthDate)
                ? DateTime.MinValue
                : DateTime.Parse(request.BirthDate);
            user.Institute = request.Institution;
            user.Phone = request.Phone;
            user.LastName = request.Surname;

            await _dbContext.SaveChangesAsync();

            return await GetInfo(userId);
        }
    }
}
