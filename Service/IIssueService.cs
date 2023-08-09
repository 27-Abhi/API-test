using Microsoft.AspNetCore.Mvc;
using trackingapi.Models;

namespace trackingapi.Service
{
    public interface IIssueService
    {
        Task<Issue> GetIssue(int id);
        Task<bool> PutIssue(int id, Issue issue);
        Task<IEnumerable<Issue>> GetAll();
  
        Task<bool> PostIssue(Issue issue);
      //  Task<Issue> UpdateIssue(Issue issue);
        
        Task<bool> DeleteIssue(int id);
        Task AddAsync(Issue issue);
        Task SaveChangesAsync();
        object Entry(Issue issue);
        Task FindAsync(int id);
        Task<List<Issue>> FilterReq(FilterRequest filterRequest);
    }
}
