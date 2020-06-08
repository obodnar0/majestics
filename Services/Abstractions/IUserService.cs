using Majestics.Models.Users;
using System.Threading.Tasks;

namespace Majestics.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserInfoViewModel> GetInfo(string userId);

        Task<UserInfoViewModel> UpdateInfo(UserInfoViewModel request, string userId);
    }
}
