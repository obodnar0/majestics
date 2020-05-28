using Majestics.Models.Contest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Majestics.Services.Abstractions
{
    public interface IContestService
    {
        Task<List<ContestViewModel>> GetAllContestsAsync();

        Task<bool> AddWorkAsync(AddWorkRequest request);

        Task<ContestViewModel> CreateContestAsync(ContestAddModel request);

        Task<bool> MarkWorkAsync(MarkWorkRequest request);
    }
}
