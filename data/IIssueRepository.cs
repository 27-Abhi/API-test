using Microsoft.AspNetCore.Mvc;
using trackingapi.DTO;
using trackingapi.Models;

namespace trackingapi.data
{
    public interface IIssueRepository
    { 
            Task<Issue> GetIssue(int id);
        Task<IEnumerable<Issue>> GetAll();
        //Task<Issue> UpdateIssue(Issue issue);
        Task<bool> DeleteIssue(int id);
         Task<bool> PostIssue(IssueDTO issue);    

        Task<bool> PutIssue(int id, IssueDTO issue);
        //Task<Issue> Put(Issue issue);
        Task<Issue> Post(IssueDTO issue);
        Task<List<Issue>> FilterReq(FilterDTO filterRequest);
    }

}
