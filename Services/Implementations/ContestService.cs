using Majestics.Data;
using Majestics.Helpers.Enums;
using Majestics.Models.Contest;
using Majestics.Models.Data;
using Majestics.Models.Users;
using Majestics.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Majestics.Models.Contest.dto;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Majestics.Services.Implementations
{
    public class ContestService : IContestService
    {
        private readonly ApplicationDbContext _dbContext;

        public ContestService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContestViewModel> GetContestAsync(int contestId)
        {
            var result = await _dbContext.Contests
                .Include(x => x.Works)
                .Where(x => x.State != ModelState.Deleted && x.Id == contestId)
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
                    Title = x.Title,
                    ContestId = x.Id
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<ContestViewModel>> GetAllContestsAsync()
        {
            var result = await _dbContext.Contests
                .Include(x => x.Works)
                .Where(x => x.State != ModelState.Deleted)
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
                    Title = x.Title,
                    ContestId = x.Id
                }).ToListAsync();

            return result;
        }

        public async Task<bool> AddWorkAsync(AddWorkRequest request)
        {
            var contest = await _dbContext.Contests
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Id == request.ContestId);
            if (contest.IsOpen || contest.Users.Any(x => x.UserId == request.UserId))
            {
                await _dbContext.AddAsync(new Work
                {
                    UserId = request.UserId,
                    ContestId = request.ContestId,
                    Description = request.Description,
                    Title = request.Title,
                    State = ModelState.Active,
                    Source = request.Source,
                    WorkStatus = WorkState.Unmarked
                });
                
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<ContestViewModel> CreateContestAsync(ContestAddModel request)
        {
            var contest = new Contest
            {
                State = ModelState.Active,
                Description = request.Description,
                IsOpen = request.IsOpen,
                Title = request.Title,
            };

            await _dbContext.AddAsync(contest);
            await _dbContext.SaveChangesAsync();

            return new ContestViewModel
            {
                ContestId = contest.Id,
                Description = contest.Description,
                Title = contest.Title
            };
        }

        public async Task<bool> MarkWorkAsync(MarkWorkRequest request)
        {
            var currentUserExistingMark = await _dbContext.Marks.FirstOrDefaultAsync(x => x.WorkId == request.WorkId && 
                                                                                     x.CriteriaId == request.CriteriaId &&
                                                                                     (x.Ip == request.Ip || x.UserId == request.UserId));

            if (currentUserExistingMark == null)
            {
                await _dbContext.AddAsync(new Mark
                {
                    CreationDate = DateTime.Now,
                    CriteriaId = request.CriteriaId,
                    Ip = request.Ip,
                    State = ModelState.Active,
                    Value = request.Mark,
                    WorkId = request.WorkId
                });
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                currentUserExistingMark.Value = request.Mark;
            }

            return true;
        }
    }
}
