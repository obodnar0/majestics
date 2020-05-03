using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Majestics.Data;
using Majestics.Helpers.Enums;
using Majestics.Models.Contest;
using Majestics.Models.Users;
using Majestics.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Majestics.Services.Implementations
{
    public class ContestService : IContestService
    {
        private readonly ApplicationDbContext _dbContext;

        public ContestService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ContestViewModel>> GetContests()
        {
            try
            {
                return await _dbContext.Contests.Where(x => x.State != ModelState.Deleted)
                    .Select(x => new ContestViewModel
                    {
                        Works = x.Works.Select(q => new WorkViewModel
                        {
                            User = new UserViewModel
                            {
                                FirstName = q.User.FirstName,
                                Institute = q.User.Institute,
                                LastName = q.User.LastName
                            },
                            Description = q.Description,
                            Title = q.Title,
                            AnonMark = q.AnonMark,
                            AverageMark = q.AverageMark,
                            JuryMark = q.JuryMark,
                            Source = q.Source,
                            UsersMark = q.UsersMark
                        }).ToList(),
                        Description = x.Description,
                        Title = x.Title
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ContestViewModel> CreateContest()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PublishWork()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MarkWork()
        {
            throw new NotImplementedException();
        }
    }
}
