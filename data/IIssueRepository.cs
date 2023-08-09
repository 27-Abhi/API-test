using Microsoft.AspNetCore.Mvc;
using trackingapi.Models;

namespace trackingapi.data
{
    public interface IIssueRepository
    { 
            Task<Issue> GetIssue(int id);
        Task<IEnumerable<Issue>> GetAll();
        //Task<Issue> UpdateIssue(Issue issue);
        Task<bool> DeleteIssue(int id);
         Task<bool> PostIssue(Issue issue);    

        Task<bool> PutIssue(int id, Issue issue);
        //Task<Issue> Put(Issue issue);
        Task<Issue> Post(Issue issue);
        Task<List<Issue>> FilterReq(FilterRequest filterRequest);
    }

}
