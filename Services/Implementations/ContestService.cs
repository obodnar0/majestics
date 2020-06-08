using Majestics.Data;
using Majestics.Helpers.Enums;
using Majestics.Models.Contest;
using Majestics.Models.Contest.dto;
using Majestics.Models.Data;
using Majestics.Models.Users;
using Majestics.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        WorkId = q.Id,
                        User = new UserViewModel
                        {
                            FirstName = q.User.FirstName,
                            Institute = q.User.Institute,
                            LastName = q.User.LastName
                        },
                        Description = q.Description,
                        Title = q.Title,
                        Source = q.Source
                    }).ToList(),
                    Description = x.Description,
                    Title = x.Title,
                    ContestId = x.Id
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Criteria>> GetCriteriasAsync(int contestId)
        {
            return await _dbContext.Criterias
                .Where(x => x.ContestId == contestId)
                .ToListAsync();
        }

        public async Task<bool> AddCriterion(AddCriteria criteria)
        {
            try
            {
                _dbContext.Criterias.Add(new Criteria
                {
                    ContestId = int.Parse(criteria.ContestId),
                    Description = criteria.Description,
                    Name = criteria.Name
                });

                await _dbContext.SaveChangesAsync();
                 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ContestViewModel>> GetAllContestsAsync()
        {
            var result = await _dbContext.Contests
                .Include(x => x.Works)
                .Include(x => x.Users)
                .Where(x => x.State != ModelState.Deleted)
                .Select(x => new ContestViewModel
                {
                    Description = x.Description,
                    Title = x.Title,
                    ContestId = x.Id
                }).ToListAsync();

            return result;
        }

        public async Task<List<WorkViewModel>> GetTopWorks()
        {
            return await _dbContext.Works   
                .OrderByDescending(x => x.Marks.Average(q => q.Value))
                .Take(8)
                .Where(x => x.State == ModelState.Active)
                .Select(x => new WorkViewModel
            {
                    User = new UserViewModel
                    {
                        FirstName = x.User.FirstName,
                        Institute = x.User.Institute,
                        LastName = x.User.LastName
                    },
                    Description = x.Description,
                    ContestId = x.ContestId,
                    Title = x.Title,
                    Source = x.Source,
                    WorkId = x.Id
                }).ToListAsync();
        }

        public async Task<bool> AddWorkAsync(AddWorkRequest request)
        {
            var contest = await _dbContext.Contests
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Id == int.Parse(request.ContestId));
            if (contest.IsOpen || contest.Users.Any(x => x.UserId == request.UserId))
            {
                await _dbContext.AddAsync(new Work
                {
                    UserId = request.UserId,
                    ContestId = int.Parse(request.ContestId),
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
            var currentUserExistingMark = await _dbContext.Marks.FirstOrDefaultAsync(x => x.WorkId == int.Parse(request.WorkId) &&
                                                                                     x.CriteriaId == int.Parse(request.CriteriaId) &&
                                                                                     x.State == ModelState.Active &&
                                                                                     (x.IdCode == request.IdCode || x.UserId == request.UserId));

            var currentUserType = (await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId))?.UserType;

            if (currentUserExistingMark == null)
            {
                await _dbContext.AddAsync(new Mark
                {
                    CreationDate = DateTime.Now,
                    CriteriaId = int.Parse(request.CriteriaId),
                    IdCode = request.IdCode,
                    UserType = currentUserType,
                    State = ModelState.Active,
                    Value = byte.Parse(request.Mark),
                    WorkId = int.Parse(request.WorkId),
                    UserId = request.UserId
                });
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                currentUserExistingMark.Value = byte.Parse(request.Mark);
            }

            return true;
        }

        public async Task<WorkViewModel> GetWorkAsync(int workId)
        {
            try
            {
                var result = await _dbContext.Works
                    .Include(x => x.User)
                    .Include(x => x.Marks)
                    .Where(x => x.Id == workId && x.State == ModelState.Active)
                    .Select(x => new WorkViewModel
                    {
                        User = new UserViewModel
                        {
                            FirstName = x.User.FirstName,
                            Institute = x.User.Institute,
                            LastName = x.User.LastName
                        },
                        Description = x.Description,
                        ContestId = x.ContestId,
                        Title = x.Title,
                        Source = x.Source,
                        WorkId = x.Id
                    }).FirstOrDefaultAsync();

                var marks = _dbContext.Marks.Where(x => x.WorkId == workId).ToList();
                var juryMarks = marks.Where(a => a.UserType.HasValue && a.UserType == UserType.Jury).ToList();
                var userMarks = marks.Where(a => a.UserType.HasValue && a.UserType == UserType.User).ToList();
                var anonMarks = marks.Where(a => !a.UserType.HasValue).ToList();

                result.AnonMark = anonMarks.Any() ? Convert.ToInt32(anonMarks.Average(x => x.Value)) : 0;
                result.JuryMark = juryMarks.Any() ? Convert.ToInt32(juryMarks.Average(x => x.Value)) : 0;
                result.UsersMark = userMarks.Any() ? Convert.ToInt32(userMarks.Average(x => x.Value)) : 0;

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
