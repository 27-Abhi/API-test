using trackingapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trackingapi.data;
using trackingapi.Models;
using trackingapi.Service;
using System.Collections.Generic;
using trackingapi.DTO;
using System.Linq.Expressions;
using trackingapi.Methods;

namespace trackingapi.data
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IssueDbContext _context;


        public IssueRepository(IssueDbContext context)
        {
            _context = context;

        }

        public async Task<bool> DeleteIssue(int id)
        {
            var issueToDelete = await _context.Issues.FindAsync(id);
            _context.Issues.Remove(issueToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Issue>> FilterReq(FilterDTO filterRequest)
        {
            var tot_num = await _context.Issues
                               .CountAsync(issue => issue.IssueType == filterRequest.Type);
            var issues = new List<Issue>();


                if (filterRequest.Sort == "desc") //sorting 
            {
                issues= await _context.Issues
                .Where(issue => issue.IssueType == filterRequest.Type )
                .OrderByDescending(a=>a.IssueType)
                .Skip((filterRequest.Page - 1) * filterRequest.Num)
                .Take(filterRequest.Num)
                .ToListAsync();
            }
                else
            {
                issues = await _context.Issues
                .Where(issue => issue.IssueType == filterRequest.Type)
                .OrderBy(a=>a.IssueType)
                .Skip((filterRequest.Page - 1) * filterRequest.Num)
                .Take(filterRequest.Num)
                .ToListAsync();
            }



            return issues;
        }

        private bool Ok(List<Issue> issues)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Issue>> GetAll()
        {
            return await _context.Issues.ToListAsync();
        }

        public async Task<Issue> GetIssue(int id)
        {
            return await _context.Issues.FindAsync(id);
        }

        public Task<Issue> Post(IssueDTO issue)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostIssue(IssueDTO issue)
        {
            var check = await TitleValidator.Validating(issue.Title, _context, issue.Id);

            if (check == true)
            {
                throw new InvalidOperationException("Title Already exists");
            }
            else
            {
                //exception handling for same issuetype not being present more than 3 times
                var count = await _context.Issues
                                  .CountAsync(i => i.IssueType == issue.IssueType);
                if (count >= 3)
                {
                    throw new InvalidOperationException("Issue Type already already exists more than 3 times.");

                }

                else
                {

                    await _context.AddAsync(issue);
                    // await _context.Insert
                    await _context.SaveChangesAsync();

                    return true;
                }
            }

        }

        public Task<Issue> Put(IssueDTO issue)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PutIssue(int id, IssueDTO issue)
        {
            var check = await TitleValidator.Validating(issue.Title, _context, issue.Id);
            if (check == true)
            {
                throw new InvalidOperationException("Same title already exists");

            }
            else
            {
                _context.Entry(issue).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
        }



        public Task<Issue> UpdateIssue(Issue issue)
        {
            throw new NotImplementedException();
        }


     

    }
}
