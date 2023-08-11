using Microsoft.EntityFrameworkCore;
using trackingapi.data;

namespace trackingapi.Methods
{

    public static class TitleValidator
    {


        public static async Task<bool> Validating(string title, IssueDbContext _context, int? Id = null)
        {
       // var query = _context.Issues.Where(issue => issue.Title == title);

            var isTitleAvailable = await _context.Issues
            .Where(issue => issue.Title == title && (issue.Id != Id))  /// 1st condituion checks if title is already present elsewhere 2nd condition is for update condition...check
            .AnyAsync();

            return isTitleAvailable;
        }
    }


}