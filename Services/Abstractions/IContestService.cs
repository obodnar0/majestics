using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Majestics.Models.Contest;

namespace Majestics.Services.Abstractions
{
    public interface IContestService
    {
        Task<List<ContestViewModel>> GetAllContestsAsync();

    }
}
