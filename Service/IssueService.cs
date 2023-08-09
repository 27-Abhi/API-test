using Microsoft.AspNetCore.Mvc;
using trackingapi.data;
using trackingapi.Models;

namespace trackingapi.Service
{
    public class IssueService : IIssueService
    {

        private readonly IIssueRepository _iIssueRepository;

        public IssueService(IIssueRepository iIssueRepository)
        { 
            _iIssueRepository = iIssueRepository;

        }

        public Task AddAsync(Issue issue)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteIssue(int id)
        {
            return await _iIssueRepository.DeleteIssue(id);
        }

        public object Entry(Issue issue)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Issue>> FilterReq(FilterRequest filterRequest)
        {
            return await _iIssueRepository.FilterReq(filterRequest);
        }

        public Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Issue>> GetAll()
        {
            return await _iIssueRepository.GetAll();
        }

        public async Task<Issue> GetIssue(int id)
        {
            return await _iIssueRepository.GetIssue(id);
        }

        public async Task<bool> PostIssue(Issue issue)
        {
            return await _iIssueRepository.PostIssue(issue);
        }

        public async Task<bool> PutIssue(int id, Issue issue)
        {
            return await _iIssueRepository.PutIssue(id,issue);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<Issue> UpdateIssue(Issue issue)
        //{
        //    return await _iIssueRepository.UpdateIssue(issue);
        //}
    }
}
