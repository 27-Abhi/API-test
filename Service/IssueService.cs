using Microsoft.AspNetCore.Mvc;
using trackingapi.data;
using trackingapi.DTO;
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

        public async Task<List<Issue>> FilterReq(FilterDTO filterRequest)
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
            
        public async Task<IssueDTO> GetIssue(int id)
        {
            var issue = await _iIssueRepository.GetIssue(id);

            var issueDTO = new IssueDTO //mapper
            {
                Id = issue.Id,
                Title = issue.Title,
                Description = issue.Description,


            };
            return issueDTO;
           // var response ///figure this out...mappiijng issue to issue DTO...to presentable data
             //   return response;
        }

        public async Task<bool> PostIssue(IssueDTO issue)
        {
            return await _iIssueRepository.PostIssue(issue);
        }

        public async Task<bool> PutIssue(int id, IssueDTO issue)
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
