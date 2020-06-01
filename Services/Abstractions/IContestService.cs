using Majestics.Models.Contest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Majestics.Models.Data;

namespace Majestics.Services.Abstractions
{
    public interface IContestService
    {
        Task<List<ContestViewModel>> GetAllContestsAsync();

        Task<ContestViewModel> GetContestAsync(int contestId);

        Task<List<Criteria>> GetCriteriasAsync();

        Task<WorkViewModel> GetWorkAsync(int workId);

        Task<bool> AddWorkAsync(AddWorkRequest request);

        Task<ContestViewModel> CreateContestAsync(ContestAddModel request);

        Task<bool> MarkWorkAsync(MarkWorkRequest request);
    }
}
