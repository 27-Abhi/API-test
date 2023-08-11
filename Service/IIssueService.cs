using Microsoft.AspNetCore.Mvc;
using trackingapi.DTO;
using trackingapi.Models;

namespace trackingapi.Service
{
    public interface IIssueService
    {
        Task<IssueDTO> GetIssue(int id);
        Task<bool> PutIssue(int id, IssueDTO issue);
        Task<IEnumerable<Issue>> GetAll();
  
        Task<bool> PostIssue(IssueDTO issue);
      //  Task<Issue> UpdateIssue(Issue issue);
        
        Task<bool> DeleteIssue(int id);
        Task AddAsync(Issue issue);
        Task SaveChangesAsync();
        object Entry(Issue issue);
        Task FindAsync(int id);
        Task<List<Issue>> FilterReq(FilterDTO filterRequest);
    }
}
