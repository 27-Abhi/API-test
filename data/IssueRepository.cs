using trackingapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trackingapi.data;
using trackingapi.Models;
using trackingapi.Service;
using System.Collections.Generic;

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

        public async Task<List<Issue>> FilterReq(FilterRequest filterRequest)
        {
            var tot_num = await _context.Issues
                               .CountAsync(issue => issue.IssueType == filterRequest.Type);

            var issues = await _context.Issues
                .Where(issue => issue.IssueType == filterRequest.Type)
                .Skip((filterRequest.Page - 1) * filterRequest.Num)
                .Take(filterRequest.Num)
                .ToListAsync();



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

        public Task<Issue> Post(Issue issue)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostIssue(Issue issue)
        {
            await _context.AddAsync(issue);
            // await _context.Insert
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<Issue> Put(Issue issue)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PutIssue(int id, Issue issue)
        {
            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;

        }



        public Task<Issue> UpdateIssue(Issue issue)
        {
            throw new NotImplementedException();
        }
    }
}
